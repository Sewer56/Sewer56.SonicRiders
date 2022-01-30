using Reloaded.Memory.Streams.Readers;
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
        public unsafe int Size => sizeof(Color);

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
            var pos = stream.Stream.Position;
            Extensions.Write(stream, TopLeft);
            Extensions.Write(stream, BottomLeft);
            Extensions.Write(stream, BottomRight);
            Extensions.Write(stream, TopRight);
            return (int)(stream.Stream.Position - pos);
        }

        public object Read(EndianStreamReader stream)
        {
            var result = new Color();
            Extensions.Read(stream, out result.TopLeft);
            Extensions.Read(stream, out result.BottomLeft);
            Extensions.Read(stream, out result.BottomRight);
            Extensions.Read(stream, out result.TopRight);
            return result;
        }
    }
}