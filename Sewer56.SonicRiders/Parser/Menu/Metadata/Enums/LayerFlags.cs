using System;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Enums
{
    [Flags]
    public enum LayerFlags
    {
        FlipHorizontal = 0x1,
        FlipVertical = 0x2,

        UnknownA = 0x20,
        UnknownB = 0x40,
    }
}