using System.Collections.Generic;

namespace Sewer56.SonicRiders.Parser.Archive.Structs.Managed
{
    /// <summary>
    /// A tuple of a group and its actual files.
    /// </summary>
    public struct ManagedGroup
    {
        /// <summary>
        /// Unique file type/identifier for members of the group.
        /// </summary>
        public ushort Id;

        /// <summary>
        /// The files contained inside this group.
        /// </summary>
        public List<ManagedFile> Files;

        public ManagedGroup(Group group, byte[][] files)
        {
            Id = group.Id;
            Files = new List<ManagedFile>(new ManagedFile[files.Length]);
            for (int x = 0; x < files.Length; x++)
                Files[x]  = new ManagedFile() { Data = files[x] };
        }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        public static ManagedGroup Create()
        {
            return new ManagedGroup()
            {
                Id = 0xFFFF,
                Files = new List<ManagedFile>()
            };
        }
    }
}