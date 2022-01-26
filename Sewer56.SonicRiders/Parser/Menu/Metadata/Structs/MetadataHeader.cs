using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;

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

        /// <summary>
        /// Maybe the framerate of the menu animations.
        /// </summary>
        public byte MaybeFramerate;

        /// <summary>
        /// Offset for <see cref="Layer"/> when <see cref="KeyframeType.SizeFromHeader"/>.
        /// </summary>
        public byte AnimationType1Offset;

        /// <summary>
        /// Usually 1.
        /// </summary>
        public short Unknown;

        /// <summary>
        /// If file is not loaded, it is the offset in the file.
        /// If the file is loaded, it is the pointer in memory.
        /// </summary>
        public ObjectSectionHeader* EntryHeaderPtr;

        /// <summary>
        /// If file is not loaded, it is the offset in the file.
        /// If the file is loaded, it is the pointer in memory.
        /// </summary>
        public TextureSectionHeader* TextureIndicesPtr;
    }
}