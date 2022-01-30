using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Reloaded.Memory.Streams.Readers;
using Reloaded.Memory.Streams.Writers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class ManagedMenuMetadata
    {
        /// <summary>
        /// Json serializer options for menu metadata.
        /// </summary>
        public static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
        {
            IncludeFields = true,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public short ResolutionX    { get; set; }
        public short ResolutionY    { get; set; }
        public byte FrameRate       { get; set; }
        public byte MaxKeyframeSize { get; set; }
        public short Unknown        { get; set; }

        public List<Object> Objects { get; set; } = new ();

        public List<Texture> Textures { get; set; } = new ();

        /// <summary>
        /// Writes the existing file to a stream.
        /// </summary>
        /// <param name="stream">Where to write the data to.</param>
        public void ToStream(EndianMemoryStream stream)
        {
            var startingPos = stream.Stream.Position;
            stream.Write(ResolutionX);
            stream.Write(ResolutionY);
            stream.Write(FrameRate);
            stream.Write(MaxKeyframeSize);
            stream.Write(Unknown);
            stream.Write(16); // Position of object section. 16 == sizeof(MetadataHeader).
            var textureSectionPtrPos = stream.Stream.Position;
            stream.Write(0);  // Dummy

            // Write Objects
            WriteObjects(stream);

            // Write pointer to texture section.
            var textureSectionPos = stream.Stream.Position;
            stream.Stream.Seek(textureSectionPtrPos, SeekOrigin.Begin);
            stream.Write((int) textureSectionPos);

            // Write textures.
            stream.Stream.Seek(textureSectionPos, SeekOrigin.Begin);
            WriteTextures(stream);
        }

        private void WriteTextures(EndianMemoryStream stream)
        {
            stream.Write(Textures.Count);
            stream.Write(0); // Inserted at runtime.
            foreach (var texture in Textures)
                texture.Write(stream);
        }

        private void WriteObjects(EndianMemoryStream stream)
        {
            var sectionHeaderPos = stream.Stream.Position;

            stream.Write(Objects.Count);
            var sectionSizePos = stream.Stream.Position;
            stream.Write(0);

            // Offsets
            var offsetPos = stream.Stream.Position;
            for (int x = 0; x < Objects.Count; x++)
                stream.Write(0);

            // Object Pointers
            foreach (var obj in Objects)
            {
                var objectPosition = stream.Stream.Position;
                var offset = (int)(objectPosition - sectionHeaderPos);

                // Write object offset.
                stream.Stream.Seek(offsetPos, SeekOrigin.Begin);
                stream.Write(offset);
                offsetPos += sizeof(int);

                // Write Object
                stream.Stream.Seek(objectPosition, SeekOrigin.Begin);
                WriteObject(stream, obj);
            }

            // Seek to start to insert section size.
            var currentPosition = stream.Stream.Position;
            var size = currentPosition - sectionSizePos;
            stream.Stream.Seek(sectionSizePos, SeekOrigin.Begin);
            stream.Write((int)size);

            // Seek back to end
            stream.Stream.Seek(currentPosition, SeekOrigin.Begin);
        }

        private void WriteObject(EndianMemoryStream stream, Object obj)
        {
            var objectHeaderPos = stream.Stream.Position;

            stream.Write(obj.Layers.Count + 1); // and action layer
            var sectionSizePos = stream.Stream.Position;
            stream.Write(0);

            // Offsets
            var offsetPos = stream.Stream.Position;
            for (int x = 0; x < obj.Layers.Count + 1; x++)
                stream.Write(0);

            for (int x = 0; x < obj.Layers.Count + 1; x++)
            {
                var objectPosition = stream.Stream.Position;
                var offset = (int)(objectPosition - objectHeaderPos);

                // Write object offset.
                stream.Stream.Seek(offsetPos, SeekOrigin.Begin);
                stream.Write(offset);
                offsetPos += sizeof(int);

                // Write Object
                stream.Stream.Seek(objectPosition, SeekOrigin.Begin);
                if (x == 0)
                    obj.ActionLayer.Write(stream, obj);
                else
                    obj.Layers[x - 1].Write(stream);
            }

            // Seek to start to insert section size.
            var currentPosition = stream.Stream.Position;
            var size = currentPosition - objectHeaderPos;
            stream.Stream.Seek(sectionSizePos, SeekOrigin.Begin);
            stream.Write((int)size);

            stream.Stream.Seek(currentPosition, SeekOrigin.Begin);
        }

        /// <summary>
        /// Parses an existing file from a stream.
        /// </summary>
        /// <param name="streamReader">Reads the stream in question.</param>
        public static ManagedMenuMetadata FromStream(EndianStreamReader streamReader)
        {
            var result             = new ManagedMenuMetadata();
            var startingPos        = streamReader.Position();

            result.ResolutionX     = streamReader.Read<short>();
            result.ResolutionY     = streamReader.Read<short>();
            result.FrameRate       = streamReader.Read<byte>();
            result.MaxKeyframeSize = streamReader.Read<byte>();
            result.Unknown         = streamReader.Read<short>();

            var pObjectSectionHeader = streamReader.Read<int>();
            var pTextureIndices      = streamReader.Read<int>();
            ReadObjects(result, streamReader, startingPos, pObjectSectionHeader);
            ReadTextures(result, streamReader, startingPos, pTextureIndices);
            return result;
        }

        private static void ReadTextures(ManagedMenuMetadata result, EndianStreamReader streamReader, long startingPos, int pTextureIndices)
        {
            streamReader.Seek(startingPos + pTextureIndices, SeekOrigin.Begin);
            streamReader.Read(out int numTextures);
            streamReader.Read(out int _);

            result.Textures = new List<Texture>(numTextures);
            for (int x = 0; x < numTextures; x++)
                result.Textures.Add(Texture.Read(streamReader));
        }

        private static void ReadObjects(ManagedMenuMetadata result, EndianStreamReader streamReader, long startingPos, int pObjectSectionHeader)
        {
            var headerPos = streamReader.Position();
            streamReader.Seek(startingPos + pObjectSectionHeader, SeekOrigin.Begin);
            streamReader.Read(out int numObjects);
            streamReader.Read(out int sectionSize);

            // Get object offset.
            Span<int> offsets = stackalloc int[numObjects];
            for (int x = 0; x < numObjects; x++)
                streamReader.Read(out offsets[x]);

            // Read each object.
            result.Objects = new List<Object>(numObjects);
            foreach (var offset in offsets)
            {
                streamReader.Seek(headerPos + offset, SeekOrigin.Begin);
                result.Objects.Add(ReadObject(streamReader, result));
            }
        }

        private static Object ReadObject(EndianStreamReader streamReader, ManagedMenuMetadata menuMetadata)
        {
            var obj = new Object();
            var headerPos = streamReader.Position();
            streamReader.Read(out int numLayers);
            streamReader.Read(out int objectSize);

            // Get layer offset.
            Span<int> offsets = stackalloc int[numLayers];
            for (int x = 0; x < numLayers; x++)
                streamReader.Read(out offsets[x]);

            // Get layers
            for (var x = 0; x < offsets.Length; x++)
            {
                var offset = offsets[x];
                streamReader.Seek(headerPos + offset, SeekOrigin.Begin);

                if (x == 0)
                    obj.ActionLayer = ActionLayer.Read(streamReader);
                else
                    obj.Layers.Add(Layer.Read(streamReader, menuMetadata));
            }

            return obj;
        }
    }
}
