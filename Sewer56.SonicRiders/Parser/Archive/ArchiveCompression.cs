using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Readers;
using Sewer56.BitStream;
using Sewer56.BitStream.ByteStreams;
using Sewer56.BitStream.Interfaces;
using Sewer56.SonicRiders.Parser.Archive.Helpers;

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
        private const uint _signature = 0x80000001;
        private const int _decompSizeOffset = 4;

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
            bool isCompressed = reader.Read<uint>() == _signature;
            reader.Seek(pos, SeekOrigin.Begin);
            return isCompressed;
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
            var byteStream = new ArrayByteStream(compressedData);
            var bitStream  = new BitStream<ArrayByteStream>(byteStream);

            // Start decompressing
            fixed (byte* resultPtr = decompressedBuffer)
                Decompress_Internal(resultPtr, decompressedBuffer.Length, options.StartOffset, ref bitStream);

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
            var byteStream = new BufferedStreamReaderByteStream(endianByteStream);
            var bitStream = new BitStream<BufferedStreamReaderByteStream>(byteStream);

            // Start decompressing
            fixed (byte* resultPtr = decompressedBuffer)
                Decompress_Internal(resultPtr, decompressedBuffer.Length, options.StartOffset, ref bitStream);

            stream.Position = endianByteStream.Position();
            return decompressedBuffer;
        }

        private static BufferedStreamReader Decompress_Internal_Init(Stream stream, ArchiveCompressorOptions options, out byte[] decompressedBuffer)
        {
            var endianByteStream = GetStreamFromEndian(stream, options.BigEndian, options.BufferSize, out var bufferedStreamReader);
            endianByteStream.Seek(_decompSizeOffset, SeekOrigin.Current);
            decompressedBuffer = new byte[endianByteStream.Read<int>()];
            return bufferedStreamReader;
        }

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

        private static EndianStreamReader GetStreamFromEndian(Stream stream, bool bigEndian, int bufferSize, out BufferedStreamReader streamReader)
        {
            streamReader = new BufferedStreamReader(stream, bufferSize);
            return bigEndian ? new BigEndianStreamReader(streamReader) : new LittleEndianStreamReader(streamReader);
        }

        private static EndianStreamReader GetStreamFromEndian(Stream stream, bool bigEndian, int bufferSize) => GetStreamFromEndian(stream, bigEndian, bufferSize, out _);
    }

    public struct ArchiveCompressorOptions
    {
        public static ArchiveCompressorOptions PC = new(0x80, false); // and Xbox
        public static ArchiveCompressorOptions GameCube = new(0x20, true);

        /// <summary>
        /// The offset to the start of the compressed data.
        /// </summary>
        public int StartOffset;

        /// <summary>
        /// True if the source file is big endian, else false.
        /// </summary>
        public bool BigEndian;

        /// <summary>
        /// Size of the buffer used for caching the contents of the passed in stream to be compressed/decompressed..
        /// Recommend using 2048 if stream sources its data from memory (E.g. MemoryStream, UnmanagedMemoryStream) and
        /// 65536 if the data is sourced from external storage (e.g. FileStream).
        /// </summary>
        public int BufferSize;

        public ArchiveCompressorOptions(int startOffset, bool bigEndian)
        {
            StartOffset = startOffset;
            BigEndian = bigEndian;
            BufferSize = 65536;
        }
    }
}
