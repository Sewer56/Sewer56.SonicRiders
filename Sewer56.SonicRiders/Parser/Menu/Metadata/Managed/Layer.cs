using System;
using System.Collections.Generic;
using System.IO;
using Reloaded.Memory.Streams.Readers;
using Reloaded.Memory.Streams.Writers;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Structures.Misc;
using Sewer56.SonicRiders.Utility;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class Layer
    {
        public const short ExpectedLayerSize = 0x2C;

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
        public ColorABGR ColorTopLeft;

        /// <summary/>
        public ColorABGR ColorBottomLeft;

        /// <summary/>
        public ColorABGR ColorBottomRight;

        /// <summary/>
        public ColorABGR ColorTopRight;

        /// <summary>
        /// Extended data for this layer.
        /// </summary>
        public byte[] Extension = Array.Empty<byte>();

        public List<Keyframe> Keyframes = new();

        /// <summary>
        /// Reads the contents of a layer from a given stream.
        /// </summary>
        /// <param name="streamReader">The stream to read the contents from.</param>
        /// <param name="menuMetadata"></param>
        public static Layer Read(EndianStreamReader streamReader, ManagedMenuMetadata menuMetadata)
        {
            var layer = new Layer();
            streamReader.Read(out short numKeyframes);
            streamReader.Read(out short numBytes);
            streamReader.Read(out KeyframeType keyframeType);

            layer.AnimationDurationFrames = streamReader.Read<short>();
            layer.Unknown_1_0 = streamReader.Read<byte>();
            layer.Unknown_1_1 = streamReader.Read<byte>();
            layer.TextureIndex = streamReader.Read<short>();
            layer.Flags = streamReader.Read<LayerFlags>();
            layer.Width = streamReader.Read<short>();
            layer.Height = streamReader.Read<short>();
            layer.Unknown_SomeTimesOffsetX = streamReader.Read<short>();
            layer.Unknown_SomeTimesOffsetY = streamReader.Read<short>();
            layer.OffsetX = streamReader.Read<short>();
            layer.OffsetY = streamReader.Read<short>();
            layer.Unknown_2 = streamReader.Read<int>();

            Extensions.Read(streamReader, out layer.ColorTopLeft);
            Extensions.Read(streamReader, out layer.ColorBottomLeft);
            Extensions.Read(streamReader, out layer.ColorBottomRight);
            Extensions.Read(streamReader, out layer.ColorTopRight);

            if (numBytes > ExpectedLayerSize)
            {
                var extraBytes = numBytes - ExpectedLayerSize;
                layer.Extension = streamReader.ReadBytes(streamReader.Position(), extraBytes);
                streamReader.Seek(extraBytes, SeekOrigin.Current);
            }

            // Read keyframes.
            int remainingFrames = numKeyframes;
            if (layer.AnimationDurationFrames <= 0 && remainingFrames <= 0)
                return layer;

            while (remainingFrames > 1)
            {
                var keyframe = Keyframe.Read(streamReader, menuMetadata);
                if (keyframe == null)
                    break;

                layer.Keyframes.Add(keyframe);
                remainingFrames--;
            }

            return layer;
        }

        /// <summary>
        /// Writes the content of a layer to a given stream.
        /// </summary>
        /// <param name="stream">The stream in question.</param>
        public void Write(EndianMemoryStream stream)
        {
            stream.Write((short)(Keyframes.Count + 1)); // Number of keyframes.
            stream.Write((short)(ExpectedLayerSize + Extension.Length)); // Number of Bytes in layer header.
            stream.Write(KeyframeType.HalfByteCount);

            stream.Write(AnimationDurationFrames);
            stream.Write(Unknown_1_0);
            stream.Write(Unknown_1_1);
            stream.Write(TextureIndex);
            stream.Write(Flags);
            stream.Write(Width);
            stream.Write(Height);
            stream.Write(Unknown_SomeTimesOffsetX);
            stream.Write(Unknown_SomeTimesOffsetY);
            stream.Write(OffsetX);
            stream.Write(OffsetY);
            stream.Write(Unknown_2);

            Extensions.Write(stream, ColorTopLeft);
            Extensions.Write(stream, ColorBottomLeft);
            Extensions.Write(stream, ColorBottomRight);
            Extensions.Write(stream, ColorTopRight);

            if (Extension.Length > 0)
                stream.Write(Extension);

            foreach (var keyFrame in Keyframes)
                keyFrame.Write(stream);
        }
    }
}
