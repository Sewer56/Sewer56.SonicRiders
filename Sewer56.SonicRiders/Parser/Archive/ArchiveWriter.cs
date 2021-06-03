using System.Collections.Generic;
using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Writers;
using Sewer56.SonicRiders.Parser.Archive.Structs.Managed;

namespace Sewer56.SonicRiders.Parser.Archive
{
    public class ArchiveWriter
    {
        /// <summary>
        /// A map of all group IDs to their group data.
        /// Stores all groups for the archive to be written.
        /// </summary>
        public Dictionary<byte, ManagedGroup> Groups { get; } = new Dictionary<byte, ManagedGroup>();

        /// <summary>
        /// Adds a group to be written to the archive.
        /// </summary>
        /// <param name="groupNo">Id of the group to add.</param>
        /// <param name="group">The group to add to the list of groups.</param>
        public void AddGroup(byte groupNo, ManagedGroup group) => Groups[groupNo] = (group);

        /// <summary>
        /// Writes the contents of the archive to be generated to the stream.
        /// </summary>
        public void Write(Stream writeStream, bool bigEndian)
        {
            using var stream = new ExtendedMemoryStream();
            using EndianMemoryStream endianStream = bigEndian ? (EndianMemoryStream) new BigEndianMemoryStream(stream) : new LittleEndianMemoryStream(stream);

            // Number of items.
            endianStream.Write<int>(Groups.Keys.Count);

            // Number of items for each id.
            foreach (var group in Groups)
                endianStream.Write<byte>((byte)group.Value.Files.Count);

            endianStream.AddPadding(0x00, 4);

            // Write first item index for each group. 
            ushort totalItems = 0;
            foreach (var group in Groups)
            {
                endianStream.Write<ushort>(totalItems);
                totalItems += (ushort)group.Value.Files.Count;
            }

            // Write ID for each group.
            foreach (var group in Groups)
                endianStream.Write<ushort>(group.Value.Id);

            // Write offsets for each file and pad.
            int firstWriteOffset = Utilities.RoundUp((int)endianStream.Stream.Position + (sizeof(int) * totalItems), 16);
            int fileWriteOffset  = firstWriteOffset;
            foreach (var group in Groups)
            {
                foreach (var file in group.Value.Files)
                {
                    endianStream.Write<int>(file.Data.Length <= 0 ? 0 : fileWriteOffset);
                    fileWriteOffset += file.Data.Length;
                }
            }

            // Write files.
            endianStream.Write(new byte[(int)(firstWriteOffset - endianStream.Stream.Position)]); // Alignment
            foreach (var file in Groups.SelectMany(x => x.Value.Files))
                endianStream.Write(file.Data);

            writeStream.Write(endianStream.ToArray());
        }

    }
}
