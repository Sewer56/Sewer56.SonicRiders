using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Frames.Attributes;
using Sewer56.SonicRiders.Structures.Misc;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Frames
{
    /// <summary>
    /// Stores colours for individual keyframes.
    /// </summary>
    [FrameType(DataType = KeyframeDataType.Color)]
    public struct Color
    {
        /// <summary/>
        public ColorABGR TopLeft;

        /// <summary/>
        public ColorABGR BottomLeft;

        /// <summary/>
        public ColorABGR BottomRight;

        /// <summary/>
        public ColorABGR TopRight;
    }
}