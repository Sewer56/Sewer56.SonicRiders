using Sewer56.SonicRiders.Parser.Menu.Metadata.Structs;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Enums
{
    public enum KeyframeType : ushort
    {
        /// <summary>
        /// Offset for keyframes is derived from the byte count in the struct itself.
        /// </summary>
        HalfByteCount = 0,

        /// <summary>
        /// Offset for extra data is derived from the header <see cref="MetadataHeader.AnimationType1Offset"/>
        /// </summary>
        SizeFromHeader = 1,

        /// <summary>
        /// Size comes from the <see cref="Keyframe.NumberOfBytesDivBy4"/>.
        /// Stores only sections with fixed length of 4 bytes, with type defined by <see cref="Type2DataHeader"/>.
        /// </summary>
        SizeFromSameStructSimpleHeader = 2,

        /// <summary>
        /// Size comes from the <see cref="Keyframe.NumberOfBytesDivBy4"/>.
        /// Stores sections of variable lengths
        /// </summary>
        SizeFromSameStructComplexHeader = 3,
    }
}