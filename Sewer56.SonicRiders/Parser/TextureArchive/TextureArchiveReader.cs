using System;
using System.IO;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Readers;
using Sewer56.SonicRiders.Parser.TextureArchive.Structs;

namespace Sewer56.SonicRiders.Parser.TextureArchive
{
    /// <summary>
    /// Reads an individual Riders Texture Archive.
    /// </summary>
    public class TextureArchiveReader : IDisposable
    {
        /// <summary>
        /// Stores the information about the internal texture files.
        /// </summary>
        public UnpackTextureFile[] Files { get; private set; }
        private Stream _stream;

        /// <summary>
        /// Reads an archive from a stream.
        /// </summary>
        /// <param name="stream">Stream pointing to the start of the archive.</param>
        /// <param name="archiveSize">Size of the archive file.</param>
        /// <param name="bigEndian">True if big endian.</param>
        public TextureArchiveReader(Stream stream, int archiveSize, bool bigEndian)
        {
            _stream = stream;

            // Extract Data.
            using var streamReader = new BufferedStreamReader(stream, 2048);
            using EndianStreamReader endianStreamReader = bigEndian ? (EndianStreamReader) new BigEndianStreamReader(streamReader) : new LittleEndianStreamReader(streamReader);
            
            // Texture Count
            endianStreamReader.Read(out short texCount);
            endianStreamReader.Read(out byte pad);
            endianStreamReader.Read(out byte hasFlags);
            Files = new UnpackTextureFile[texCount];

            // Get Texture Offsets
            for (int x = 0; x < texCount; x++)
                Files[x].Offset = endianStreamReader.Read<int>();

            // Get texture Sizes
            // Note: We are actually reading some extra bytes as files are padded to 32 bytes.
            for (int x = 0; x < texCount - 1; x++) 
                Files[x].Size = Files[x + 1].Offset - Files[x].Offset;

            Files[texCount - 1].Size = (archiveSize - Files[texCount - 1].Offset);

            // Read Texture Flags
            if (hasFlags > 0)
            {
                for (int x = 0; x < texCount; x++)
                    Files[x].PadFlag = endianStreamReader.Read<byte>();
            }

            // Read Texture Names
            for (int x = 0; x < texCount; x++)
                Files[x].Name = streamReader.ReadString();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _stream?.Dispose();
        }

        /// <summary>
        /// Gets the data belonging to an individual file.
        /// </summary>
        /// <param name="file">The file to get the data from.</param>
        public byte[] GetFile(UnpackTextureFile file)
        {
            using var streamReader = new BufferedStreamReader(_stream, 2048);
            return streamReader.ReadBytes(file.Offset, file.Size);
        }
    }
}
