using Reloaded.Memory.Streams.Writers;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Frames.Attributes;
using Sewer56.SonicRiders.Structures.Misc;
using Sewer56.SonicRiders.Utility;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Frames
{
    /// <summary>
    /// Stores colours for individual keyframes.
    /// </summary>
    [FrameType(DataType = KeyframeDataType.Color)]
    public struct Color : IManagedFrame
    {
        /// <summary/>
        public ColorABGR TopLeft;

        /// <summary/>
        public ColorABGR BottomLeft;

        /// <summary/>
        public ColorABGR BottomRight;

        /// <summary/>
        public ColorABGR TopRight;

        public int Write(EndianMemoryStream stream)
        {
            stream.Write(TopLeft);
            stream.Write(BottomLeft);
            stream.Write(BottomRight);
            stream.Write(TopRight);
            return 1;
        }
    }
}