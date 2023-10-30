using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Reloaded.Memory;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Readers;
using Sewer56.BitStream;
using Sewer56.BitStream.ByteStreams;
using Sewer56.BitStream.Interfaces;
using Sewer56.SonicRiders.Parser.Archive.Helpers;
using Sewer56.SonicRiders.Utility;
using Sewer56.SonicRiders.Utility.Stream;

namespace Sewer56.SonicRiders.Parser.Archive
{
    /// <summary>
    /// Provides support for basic compression and decompression of archives.
    /// Supports PC, Xbox and GameCube.
    /// </summary>
    public class ArchiveCompression
    {
        /*
            Decompression code ported from sonic_riders_lzss by romhack.
            https://github.com/romhack/sonic_riders_lzss
        */

        /// <summary> Present at the start of each compressed file. </summary>
        private const uint Signature = 0x80000001;
        
        /// <summary> Template data for an OOCH header. </summary>
        private static byte[] OochTemplate = {
            0x4F, 0x4F, 0x43, 0x48, 0x01, 0x00, 0x00, 0x08, 0xF3, 0x46, 0x2B, 0x00, 0xA0, 0x7A, 0x59, 0x00,
            0x18, 0x00, 0x1C, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00,
            0x08, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00 
        };

        /// <summary>
        /// Determines whether this is a compressed archive and returns true or false.
        /// Does not advance stream.
        /// </summary>
        /// <param name="stream">The stream, with the current position set to the first byte of the compressed file..</param>
        /// <param name="bigEndian">Whether to use big endian or not.</param>
        public static bool IsCompressed(Stream stream, bool bigEndian)
        {
            var pos = stream.Position;
            using var streamReader = GetStreamFromEndian(stream, bigEndian, 8);
            bool isCompressed = IsCompressed(streamReader);
            stream.Seek(pos, SeekOrigin.Begin);
            return isCompressed;
        }

        /// <summary>
        /// Determines whether this is a compressed archive and returns true or false.
        /// Does not advance stream.
        /// </summary>
        /// <param name="reader">The stream reader.</param>
        public static bool IsCompressed(EndianStreamReader reader)
        {
            var pos = reader.Position();
            bool isCompressed = reader.Read<uint>() == Signature;
            reader.Seek(pos, SeekOrigin.Begin);
            return isCompressed;
        }

        /// <summary>
        /// Gets the maximum possible compressed size of file for an uncompressed file.
        /// </summary>
        /// <param name="uncompressedSize">The uncompressed size of the file.</param>
        /// <returns>Maximum compressed size. Does not include compression header.</returns>
        public static int GetMaxCompressedSize(int uncompressedSize) => (int) Math.Ceiling(uncompressedSize * 1.125f);

        /// <summary>
        /// Compresses the contents of a stream
        /// </summary>
        /// <param name="source">The source of where the data should be compressed from.</param>
        /// <param name="numBytes">Number of bytes from the stream that should be compressed.</param>
        /// <param name="options">Options for the file compressor.</param>
        public static unsafe Span<byte> CompressFast(Stream source, int numBytes, ArchiveCompressorOptions options)
        {
            // TODO: Optimize this.

            // Read the data to be compressed into memory.
            var dataToCompress = GC.AllocateUninitializedArray<byte>(numBytes);
            source.TryReadSafe(dataToCompress);

            // Initialize Writer.
            var maxCompSize = GetMaxCompressedSize(dataToCompress.Length) + options.StartOffset;
            var compressedData = GC.AllocateUninitializedArray<byte>(maxCompSize);
            fixed (byte* compressedDataPtr = compressedData)
            {
                var byteStream = new PointerByteStream(compressedDataPtr);
                var writer = new BitStream<PointerByteStream>(byteStream);

                // Write header
                // Writer is big endian by nature, so we inverse it.
                if (!options.UseOochHeader)
                {
                    writer.Write(!options.BigEndian ? Endian.Reverse(Signature) : Signature);
                    writer.Write(!options.BigEndian ? Endian.Reverse(numBytes) : numBytes);
                }
                else
                {
                    writer.Write(OochTemplate);
                    writer.Seek(12);
                    writer.Write(Endian.Reverse(numBytes)); // little endian
                }
                writer.Seek(options.StartOffset);

                // Compress the data.
                fixed (byte* dataPtr = &dataToCompress[0])
                {
                    int pointer = 0;
                    int maxPointer = dataToCompress.Length;
                    while (pointer < maxPointer)
                    {
                        var match = Lz77GetLongestMatch(dataPtr, maxPointer, pointer, byte.MaxValue, byte.MaxValue);

                        /*
                            1 XXXXXXXX YYYYYYYY
                            | |        |
                            | |        1 byte length
                            | 1 byte offset.
                            compression flag 
                        */

                        // Compressed 2 bytes:   17 / 16 = 1.0625 bits 
                        // Uncompressed 2 bytes: 18 / 16 = 1.125 bits
                        // Conclusion: Compression effective if length >= 2.
                        if (match.Length >= 2)
                        {
                            writer.WriteBit(1);
                            writer.Write((byte)(match.Offset * -1));
                            writer.Write((byte)match.Length);
                            pointer += match.Length;
                        }
                        else
                        {
                            writer.WriteBit(0);
                            writer.Write(dataPtr[pointer++]);
                        }
                    }
                }

                if (options.UseOochHeader)
                {
                    var offset = writer.NextByteIndex;
                    var compLength = writer.NextByteIndex - options.StartOffset;
                    writer.Seek(8);
                    writer.Write(Endian.Reverse(compLength)); // little endian
                    writer.Seek(offset);
                }
                
                return compressedData.AsSpan(0, writer.NextByteIndex);
            }
        }

        /// <summary>
        /// Looks for a match in the search buffer and finds the longest match of repeating bytes.
        /// </summary>
        /// <param name="source">The array in which we will be looking for matches.</param>
        /// <param name="sourceLength">Length of the source array.</param>
        /// <param name="pointer">Current offset from the start of the array used for matching symbols from.</param>
        /// <param name="searchBufferSize">The amount of bytes to search backwards in order to find the matching pattern.</param>
        /// <param name="maxLength">The maximum number of bytes to match in a found pattern searching backwards. This number is inclusive, i.e. includes the passed value.</param>
        [SkipLocalsInit]
        private static unsafe Lz77Match Lz77GetLongestMatch(byte* source, int sourceLength, int pointer, int searchBufferSize, int maxLength)
        {
            // Remembers our current best LZ77 match.
            var bestLZ77Match = new Lz77Match();
            
            // Length of the current match.
            int currentLength = 0;
            
            // Minimum pointer position we can access.
            int minimumPointerPosition = pointer - searchBufferSize;
            if (minimumPointerPosition < 0)
                minimumPointerPosition = 0;

            // Speedup: If cannot exceed source length, do not check it on every loop iteration. (else clause) 
            if (pointer + maxLength + sizeof(int) >= sourceLength) // length is 1 indexed, our reads are not.
            {
                for (int currentPointer = pointer - 1; currentPointer >= minimumPointerPosition; currentPointer--)
                {
                    if (source[currentPointer] != source[pointer])
                        continue;

                    // We've matched a symbol: Count matching symbols.
                    currentLength = 1;
                    while ((pointer + currentLength < sourceLength) && (source[currentPointer + currentLength] == source[pointer + currentLength]))
                        currentLength++;

                    /* 
                        Cap at the limit of repeated bytes if it's over the limit of what format allows.
                        We can also stop our search here.
                    */
                    if (currentLength > maxLength)
                    {
                        currentLength = maxLength;
                        bestLZ77Match.Length = currentLength;
                        bestLZ77Match.Offset = currentPointer - pointer;
                        return bestLZ77Match;
                    }

                    /* Set the best match if acquired. */
                    if (currentLength > bestLZ77Match.Length)
                    {
                        bestLZ77Match.Length = currentLength;
                        bestLZ77Match.Offset = currentPointer - pointer;
                    }
                }
            }
            else
            {
                // Since minimum bytes for compression effectiveness is 2 for this algorithm, start by trying to match
                // 2 bytes.
                short initialMatch = *(short*)(&source[pointer]);

                // Iterate over each individual byte backwards to find the longest match. 
                for (int currentPointer = pointer - 1; currentPointer >= minimumPointerPosition; currentPointer--)
                {
                    // Check for initial 2 byte match.
                    if (*(short*)(&source[currentPointer]) != initialMatch) 
                        continue;
                    
                    currentLength = sizeof(short);
                    while (source[currentPointer + currentLength] == source[pointer + currentLength])
                    {
                        currentLength++;

                        // This check needs to be here, otherwise the search might go into uninitialised memory as 
                        // the loop will not cap before maxLength
                        if (currentLength > maxLength)
                        {
                            currentLength = maxLength;
                            bestLZ77Match.Length = currentLength;
                            bestLZ77Match.Offset = currentPointer - pointer;
                            return bestLZ77Match;
                        }
                    }

                    // Set the best match if acquired.
                    if (currentLength > bestLZ77Match.Length)
                    {
                        bestLZ77Match.Length = currentLength;
                        bestLZ77Match.Offset = currentPointer - pointer;
                    }
                }
            }
            
            return bestLZ77Match;
        }

        /// <summary>
        /// Reads a compressed archive and decompresses its contents.
        /// </summary>
        /// <param name="stream">The originating stream. Start of stream should be at start of file.</param>
        /// <param name="fileLength">The length between the first byte of the file in the stream and the last byte.</param>
        /// <param name="options">The options to use for decompressing.</param>
        public static unsafe byte[] DecompressFast(Stream stream, int fileLength, ArchiveCompressorOptions options)
        {
            var startPos = stream.Position;

            // Get Decompressed File Buffer
            using var endianByteStream = Decompress_Internal_Init(stream, options, out var decompressedBuffer);

            // Setup compressed buffer reading
            var compressedData = endianByteStream.ReadBytes(startPos, fileLength);

            fixed (byte* resultPtr = decompressedBuffer)
            fixed (byte* compressedPtr = compressedData)
            {
                var byteStream = new PointerByteStream(compressedPtr);
                var bitStream = new BitStream<PointerByteStream>(byteStream);

                // Start decompressing
                Decompress_Internal(resultPtr, decompressedBuffer.Length, options.StartOffset, ref bitStream);
            }

            // Advance underlying stream
            stream.Position = startPos + fileLength;
            return decompressedBuffer;
        }

        /// <summary>
        /// Reads a compressed archive and decompresses its contents.
        /// Also see <see cref="DecompressFast"/> for a slightly
        /// better performance version; should you know the file length.
        /// </summary>
        /// <param name="stream">The originating stream. Start of stream should be at start of file.</param>
        /// <param name="options">The options to use for decompressing.</param>
        public static unsafe byte[] DecompressSlow(Stream stream, ArchiveCompressorOptions options)
        {
            // Get Decompressed File Buffer
            using var endianByteStream = Decompress_Internal_Init(stream, options, out var decompressedBuffer);

            // Setup compressed buffer reading
            var byteStream = new BufferedStreamReaderByteStream(endianByteStream.Reader);
            var bitStream = new BitStream<BufferedStreamReaderByteStream>(byteStream);

            // Start decompressing
            fixed (byte* resultPtr = decompressedBuffer)
                Decompress_Internal(resultPtr, decompressedBuffer.Length, options.StartOffset, ref bitStream);

            stream.Position = endianByteStream.Position();
            return decompressedBuffer;
        }

        private static EndianStreamReader Decompress_Internal_Init(Stream stream, ArchiveCompressorOptions options, out byte[] decompressedBuffer)
        {
            var endianByteStream = GetStreamFromEndian(stream, options.UseOochHeader ? false : options.BigEndian, options.BufferSize);
            endianByteStream.Seek(options.CompSizeOffset, SeekOrigin.Current);
            decompressedBuffer = GC.AllocateUninitializedArray<byte>(endianByteStream.Read<int>());
            return endianByteStream;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static unsafe void Decompress_Internal<T>(byte* decompPtr, int decompSize, int startOffset, ref BitStream<T> compressedStream) where T : IByteStream
        {
            /*
             * Note: We use a byte* here for the decompressed buffer so we can avoid bounds checks in our copy operations.
             * We shouldn't require bounds checks as long as the file is valid and buffer is sufficiently sized.
             * Which it should be as we know the exact size of decompressed data already.
             */
            
            // Seek to compressed data
            compressedStream.Seek(startOffset);
            int decompIndex = 0;

            while (decompIndex < decompSize)
            {
                byte isCompressed = compressedStream.ReadBit();
                if (isCompressed == 1)
                {
                    // LZ77 Copy, with 8 bit offset, 8 bit length.
                    byte offset = compressedStream.Read<byte>();
                    byte length = compressedStream.Read<byte>();
                    LZ77Copy(length, offset, decompPtr, ref decompIndex);
                }
                else
                {
                    // Raw byte copy.
                    decompPtr[decompIndex++] = compressedStream.Read<byte>();
                }
            }
        }

        /// <summary>
        /// Performs a copy from an earlier point in the array to a later point in the array.
        /// </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        private static unsafe void LZ77Copy(int length, int offset, byte* destination, ref int destinationIndex)
        {
            // After some benchmarking, Span<T> should be the most
            // optimal for any size > 6 bytes. This is somewhat common, so it's okay to use here.
            int copyStartPos = destinationIndex - offset;
            var overlap = copyStartPos + length - destinationIndex;

            if (overlap <= 0)
            {
                // Hot path: No overlap. Happens around 97% of the time.
                Unsafe.CopyBlockUnaligned(destination + destinationIndex, destination + copyStartPos, (uint)length);
            }
            else
            {
                // Cold path: Has overlap.
                // Executed around 3% of the time.
                if (length >= 14)
                {
                    // Mix unaligned copy and byte copy. 
                    // Statistically speaking, average overlap ratio is 0.5; and with that, length 14 and over presents
                    // better performance when block copy and byte copy are mixed over pure byte copy.
                    var nonOverlap = length - overlap;
                    Unsafe.CopyBlockUnaligned(destination + destinationIndex, destination + copyStartPos, (uint)nonOverlap);

                    for (int x = 0; x < length; x++)
                        destination[destinationIndex + x] = destination[copyStartPos + x];
                }
                else
                {
                    // If the overlap is small, a direct byte copy will often be faster.
                    for (int x = 0; x < length; x++)
                        destination[destinationIndex + x] = destination[copyStartPos + x];
                }
            }

            destinationIndex += length;
        }

        private static EndianStreamReader GetStreamFromEndian(Stream stream, bool bigEndian, int bufferSize)
        {
            var streamReader = new BufferedStreamReader(stream, bufferSize);
            return bigEndian ? new BigEndianStreamReader(streamReader) : new LittleEndianStreamReader(streamReader);
        }
    }

    public struct ArchiveCompressorOptions
    {
        public static ArchiveCompressorOptions PC = new(0x80, 4, false, false); // and Xbox
        public static ArchiveCompressorOptions GameCube = new(0x20, 4, true, false);

        public static ArchiveCompressorOptions ZG_WII = new(0x800, 12, true, true);
        public static ArchiveCompressorOptions ZG_PS2 = new(0x800, 12, false, true);
        
        /// <summary>
        /// The offset to the start of the compressed data.
        /// </summary>
        public int StartOffset;

        /// <summary>
        /// The offset to the compressed data size.
        /// </summary>
        public int CompSizeOffset;

        /// <summary>
        /// True if the source file is big endian, else false.
        /// </summary>
        public bool BigEndian;

        /// <summary>
        /// Uses the 'OOCH' header. (Only used in Zero Gravity)
        /// </summary>
        public bool UseOochHeader;

        /// <summary>
        /// Size of the buffer used for caching the contents of the passed in stream to be compressed/decompressed..
        /// Recommend using 2048 if stream sources its data from memory (E.g. MemoryStream, UnmanagedMemoryStream) and
        /// 65536 if the data is sourced from external storage (e.g. FileStream).
        /// </summary>
        public int BufferSize;

        public ArchiveCompressorOptions(int startOffset, int compSizeOffset, bool bigEndian, bool useOoch)
        {
            StartOffset = startOffset;
            CompSizeOffset = compSizeOffset;
            BigEndian = bigEndian;
            BufferSize = 65536;
            UseOochHeader = true;
        }
        
        /// <summary>
        /// Returns the preset for the given parameters.
        /// </summary>
        /// <param name="isBigEndian">True for 'Big Endian'.</param>
        /// <param name="isZg">True if the game is 'zero gravity'.</param>
        public static ArchiveCompressorOptions GetPreset(bool isBigEndian, bool isZg)
        {
            return !isZg ? 
                isBigEndian ? GameCube : PC 
                : isBigEndian ? ZG_WII : ZG_PS2;
        }
    }

    struct Lz77Match
    {
        /// <summary>
        /// Offset from the current pointer.
        /// </summary>
        public int Offset;
        
        /// <summary>
        /// Length of the found match.
        /// </summary>
        public int Length;
    }
}
