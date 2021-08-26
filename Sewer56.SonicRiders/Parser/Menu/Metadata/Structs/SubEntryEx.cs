using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    public struct SubEntryEx
    {
        public SubentryFlags Flags;

        public short Width;
        public short Height;

        public int Unknown;
        public short OffsetX;
        public short OffsetY;
        public int Unknown_2;
        public int TransparencyOffsetTopLeft;
        public int TransparencyOffsetBottomLeft;
        public int TransparencyOffsetBottomRight;
        public int TransparencyOffsetTopRight;
    }
}