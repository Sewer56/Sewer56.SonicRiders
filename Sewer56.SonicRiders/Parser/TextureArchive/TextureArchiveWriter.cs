using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Writers;
using Sewer56.SonicRiders.Parser.TextureArchive.Structs;

namespace Sewer56.SonicRiders.Parser.TextureArchive
{
    public class TextureArchiveWriter
    {
        /// <summary>
        /// Contains a list of all files.
        /// </summary>
        public List<PackTextureFile> Files = new List<PackTextureFile>(128);

        /// <summary>
        /// Adds a file from an arbitrary location.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="data">Data associated with the file.</param>
        public void AddFile(string fileName, byte[] data)
        {
            Files.Add(new PackTextureFile() { Name = fileName, Data = data });
        }

        /// <summary>
        /// Writes the contents of the archive to be generated to the stream.
        /// </summary>
        public void Write(Stream writeStream, TextureArchiveWriterSettings options) => writeStream.Write(Write(options));

        /// <summary>
        /// Writes the contents of the archive to be generated to a byte array.
        /// </summary>
        public byte[] Write(TextureArchiveWriterSettings options)
        {
            using var stream = new ExtendedMemoryStream(EstimateFileSize(options));
            using EndianMemoryStream endianStream = options.BigEndian ? (EndianMemoryStream)new BigEndianMemoryStream(stream) : new LittleEndianMemoryStream(stream);

            // Precompute Offsets
            var fileNameSize = Files.Sum(x => x.Name.Length) + (Files.Count);
            Span<int> offsets = stackalloc int[Files.Count];
            PrecomputeFileOffsets(offsets, fileNameSize, options);

            // Texture Count
            endianStream.Write<short>((short)Files.Count);
            endianStream.Write((byte)0);
            endianStream.Write(options.WriteFlagsSection ? (byte)1 : (byte)0);

            // Texture Offsets
            for (int x = 0; x < offsets.Length; x++)
                endianStream.Write(offsets[x]);

            // Texture Flags
            if (options.WriteFlagsSection)
                for (int x = 0; x < Files.Count; x++)
                    endianStream.Write((byte)0x11);

            // Texture Names
            Span<byte> currentString = stackalloc byte[1024];
            foreach (var file in Files)
            {
                int numEncoded = Encoding.ASCII.GetBytes(file.Name, currentString);
                currentString[numEncoded] = 0x00;
                stream.Write(currentString.Slice(0, numEncoded + 1));
            }

            // Texture Data
            stream.AddPadding(options.Alignment);
            for (int x = 0; x < Files.Count; x++)
            {
                stream.Write(Files[x].Data);
                stream.AddPadding(options.Alignment);
            }

            return stream.ToArray();
        }

        /// <summary>
        /// Estimates the file size of the output file.
        /// Note: Not accurate, but will return equal or slightly more than actual file.
        /// </summary>
        public int EstimateFileSize(TextureArchiveWriterSettings options)
        {
            var estimateFileSize = 0;
            estimateFileSize += sizeof(int); // Header
            estimateFileSize += (sizeof(int) + 1 * Files.Count); // Offsets + Flags
            estimateFileSize += Files.Sum(x => x.Data.Length + x.Name.Length + 1); // Names and Data
            estimateFileSize += (options.Alignment * Files.Count); // Alignment
            return estimateFileSize;
        }

        private void PrecomputeFileOffsets(Span<int> offsets, int stringDataSize, TextureArchiveWriterSettings options)
        {
            const int headerSize = sizeof(int);
            int fileOffsetArraySize  = Files.Count * sizeof(int);
            int unknownFlagArraySize = options.WriteFlagsSection ? Files.Count * sizeof(byte) : 0;
            
            // Get offset for first file, aligned.
            int currentFileDataOffset = Utilities.RoundUp(headerSize + fileOffsetArraySize + unknownFlagArraySize + stringDataSize, options.Alignment);

            // Populate offsets for every file.
            for (int x = 0; x < Files.Count; x++)
            {
                offsets[x] = currentFileDataOffset;
                currentFileDataOffset += Utilities.RoundUp(Files[x].Data.Length, options.Alignment);
            }
        }
    }
}
