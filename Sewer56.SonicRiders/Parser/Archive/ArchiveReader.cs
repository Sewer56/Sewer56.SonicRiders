using System;
using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Readers;
using Sewer56.SonicRiders.Parser.Archive.Structs;
using Sewer56.SonicRiders.Parser.Archive.Structs.Managed;

namespace Sewer56.SonicRiders.Parser.Archive
{
    /// <summary>
    /// Reads an individual Riders Archive.
    /// </summary>
    public class ArchiveReader : IDisposable
    {
        /// <summary>
        /// All of the groups which belong to this archive.
        /// </summary>
        public Group[] Groups;

        private long _startPos;
        private Stream _stream;

        /// <summary>
        /// Reads an archive from a stream.
        /// </summary>
        /// <param name="stream">Stream pointing to the start of the archive.</param>
        /// <param name="archiveSize">Size of the archive file.</param>
        /// <param name="bigEndian">True if big endian.</param>
        public ArchiveReader(Stream stream, int archiveSize, bool bigEndian)
        {
            _stream = stream;
            _startPos = stream.Position;

            // Extract Data.
            using var streamReader = new BufferedStreamReader(stream, 2048);
            using EndianStreamReader endianStreamReader = bigEndian ? (EndianStreamReader) new BigEndianStreamReader(streamReader) : new LittleEndianStreamReader(streamReader);
            
            endianStreamReader.Read(out int binCount);
            Groups = new Group[binCount];

            // Get group item counts.
            for (int x = 0; x < Groups.Length; x++)
                Groups[x].Files = new Structs.File[endianStreamReader.Read<byte>()];

            // Alignment
            endianStreamReader.Seek(Utilities.RoundUp((int) endianStreamReader.Position(), 4) - endianStreamReader.Position(), SeekOrigin.Current);

            // Skip section containing first item for each group.
            endianStreamReader.Seek(sizeof(short) * Groups.Length, SeekOrigin.Current);

            // Populate IDs
            for (int x = 0; x < Groups.Length; x++)
                Groups[x].Id = endianStreamReader.Read<ushort>();

            // Populate offsets.
            int[] offsets = new int[Groups.Select(x => x.Files.Length).Sum()];
            for (int x = 0; x < offsets.Length; x++)
                offsets[x] = endianStreamReader.Read<int>();

            int offsetIndex = 0;
            for (int x = 0; x < Groups.Length; x++)
            {
                var fileCount = Groups[x].Files.Length;
                for (int y = 0; y < fileCount; y++)
                {
                    // Do not fill if no more elements left.
                    if (offsetIndex >= offsets.Length)
                        break;
                    
                    var offset = (int) offsets[offsetIndex];
                    int nextOffsetIndex = offsetIndex;
                    offsetIndex += 1;

                    // Find next non-zero value within array; if not found, use archive size..
                    do { nextOffsetIndex += 1; } 
                    while (nextOffsetIndex < offsets.Length && offsets[nextOffsetIndex] == 0);

                    var nextOffset = nextOffsetIndex < offsets.Length ? offsets[nextOffsetIndex] : archiveSize;

                    // Set offsets
                    Groups[x].Files[y].Offset = offset;
                    Groups[x].Files[y].Size   = nextOffset - offset;
                }
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _stream?.Dispose();
        }

        /// <summary>
        /// Gets all files in all groups in a convenient representation.
        /// </summary>
        /// <returns>A mapping between group id to all of the group's files.</returns>
        public ManagedGroup[] GetAllGroups()
        {
            var result = new ManagedGroup[Groups.Length];
            for (var x = 0; x < Groups.Length; x++)
                result[x] = new ManagedGroup(Groups[x], GetFiles(Groups[x]));

            return result;
        }

        /// <summary>
        /// Gets the data belonging to all of the files of the group.
        /// </summary>
        /// <param name="group">The group to which the file belongs to.</param>
        /// <returns>Data for each file. Or an empty array if the file was listed in the archive header but not present in archive (offset/size = 0)</returns>
        public byte[][] GetFiles(Group group)
        {
            byte[][] files = new byte[group.Files.Length][];
            for (int x = 0; x < group.Files.Length; x++)
                files[x] = GetFile(group, x);

            return files;
        }

        /// <summary>
        /// Gets the data belonging to an individual file in a group.
        /// </summary>
        /// <param name="group">The group to which the file belongs to.</param>
        /// <param name="fileIndex">Index of the individual file.</param>
        /// <returns>Data for the file. Or an empty array if the file was listed in the archive header but not present in archive (offset/size = 0)</returns>
        public byte[] GetFile(Group group, int fileIndex)
        {
            var file   = group.Files[fileIndex];
            var offset = file.Offset;
            if (offset <= 0)
                return new byte[0];

            var buffer = new byte[file.Size];
            _stream.Position = _startPos + file.Offset;
            _stream.Read(buffer.AsSpan());
            return buffer;
        }
    }
}
