using System.Collections.Generic;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Structures.Misc;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class Layer
    {
        /// <summary>
        /// Number of keyframes in this layer.
        /// </summary>
        public short NumKeyframes;

        /// <summary>
        /// Number of bytes for the layer. Used if <see cref="KeyframeType"/> is 0.
        /// </summary>
        public short NumBytes;

        /// <summary>
        /// Where the extended data for keyframes is sourced.
        /// </summary>
        public KeyframeType KeyframeType;

        /// <summary>
        /// Certainty: 90%
        /// </summary>
        public short AnimationDurationFrames;

        /// <summary>
        /// Unknown use.
        /// </summary>
        public byte Unknown_1_0;

        /// <summary>
        /// Unknown use.
        /// </summary>
        public byte Unknown_1_1;

        /// <summary>
        /// Index of the texture used for this menu item.
        /// </summary>
        public short TextureIndex;

        /// <summary>
        /// Flags controlling the rendering of the menu item.
        /// </summary>
        public LayerFlags Flags;

        /// <summary>
        /// Width of the item.
        /// </summary>
        public short Width;

        /// <summary>
        /// Height of the item.
        /// </summary>
        public short Height;

        public short Unknown_SomeTimesOffsetX;
        public short Unknown_SomeTimesOffsetY;

        /// <summary>
        /// Horizontal Item Offset
        /// </summary>
        public short OffsetX;

        /// <summary>
        /// Vertical Item Offset
        /// </summary>
        public short OffsetY;

        public int Unknown_2;

        /// <summary/>
        public ColorABGR ColorTopLeft { get; set; }

        /// <summary/>
        public ColorABGR ColorBottomLeft { get; set; }

        /// <summary/>
        public ColorABGR ColorBottomRight { get; set; }

        /// <summary/>
        public ColorABGR ColorTopRight { get; set; }

        public List<Keyframe> Keyframes { get; set; }
    }
}
