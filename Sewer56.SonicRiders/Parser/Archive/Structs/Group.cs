namespace Sewer56.SonicRiders.Parser.Archive.Structs
{
    /// <summary>
    /// Defines members of one group.
    /// </summary>
    public struct Group
    {
        /// <summary>
        /// Unique file type/identifier for members of the group.
        /// </summary>
        public ushort Id;

        /// <summary>
        /// Offsets and sizes of all members of the group.
        /// </summary>
        public File[] Files;
    }
}