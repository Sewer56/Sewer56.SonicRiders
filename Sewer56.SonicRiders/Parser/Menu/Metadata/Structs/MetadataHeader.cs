namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    /// <summary>
    /// Header for 2D Layout Metadata.
    /// i.e. TSGME -> 40016 -> 00004.
    /// </summary>
    public unsafe struct MetadataHeader
    {
        /// <summary>
        /// Horizontal Resolution
        /// </summary>
        public short ResolutionX;

        /// <summary>
        /// Vertical Resolution
        /// </summary>
        public short ResolutionY;

        public int Unknown;

        /// <summary>
        /// If file is not loaded, it is the offset in the file.
        /// If the file is loaded, it is the pointer in memory.
        /// </summary>
        public EntryHeader* EntryHeaderPtr;

        /// <summary>
        /// If file is not loaded, it is the offset in the file.
        /// If the file is loaded, it is the pointer in memory.
        /// </summary>
        public TextureIdHeader* TextureIndicesPtr;
    }
}