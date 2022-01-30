using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Reloaded.Memory.Streams.Readers;
using Reloaded.Memory.Streams.Writers;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Structs;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Frames.Attributes;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class Keyframe
    {
        /// public KeyframeType KeyframeType;

        /// <summary>
        /// The number of frames after which this keyframe activates.
        /// </summary>
        public short AnimationActivationPointFrames;
        
        /// public short NumberOfChangedProperties;
        /// public short NumberOfBytesDivBy4;

        /// <summary>
        /// List of all frames to attach to this keyframe.
        /// </summary>
        public Dictionary<KeyframeDataType, object> Frames = new();

        /// <summary>
        /// Writes the keyframe to the given stream.
        /// </summary>
        /// <param name="stream">The stream to write the keyframe to.</param>
        public void Write(EndianMemoryStream stream)
        {
            Initialize();
            bool encodeAsType2 = CanUseType2();
            var originalHeaderPtr = stream.Stream.Position;
            int numBytesOffset    = 0;

            // Writes number of bytes to end of keyframe data.
            void WriteNumBytes()
            {
                var originalOffset = stream.Stream.Position;
                var numBytesDivBy4 = (short)((originalOffset - originalHeaderPtr) / 4);

                stream.Stream.Seek(numBytesOffset, SeekOrigin.Begin);
                stream.Write(numBytesDivBy4);
                stream.Stream.Seek(originalOffset, SeekOrigin.Begin);
            }

            void WriteHeader(KeyframeType type)
            {
                stream.Write(type);
                stream.Write(AnimationActivationPointFrames);
                stream.Write((short)Frames.Count);
                numBytesOffset = (int)stream.Stream.Position;
                stream.Write((short)0);
            }

            if (encodeAsType2)
            {
                WriteHeader(KeyframeType.SizeFromSameStructSimpleHeader);
                
                // Encode type 2 data.
                foreach (var frame in Frames)
                    stream.Write(frame.Key);

                stream.AddPadding(4);
                foreach (var frame in Frames)
                    GetFrame(frame.Key, frame.Value).Write(stream);

                WriteNumBytes();
                return;
            }

            // Encode type 3 data.
            WriteHeader(KeyframeType.SizeFromSameStructComplexHeader);

            foreach (var frame in Frames)
            {
                stream.Write(frame.Key);
                stream.Write((short)GetFrame(frame.Key, frame.Value).Size);
            }

            foreach (var frame in Frames)
            {
                var managedFrame = GetFrame(frame.Key, frame.Value);
                managedFrame.Write(stream);
            }

            WriteNumBytes();
        }

        private void Initialize()
        {
            foreach (var frame in Frames)
                Frames[frame.Key] = GetFrame(frame.Key, frame.Value);
        }

        private bool CanUseType2()
        {
            foreach (var frame in Frames)
            {
                var managedFrame = GetFrame(frame.Key, frame.Value);
                if (managedFrame.Size != sizeof(int))
                    return false;
            }

            return true;
        }

        private IManagedFrame GetFrame(KeyframeDataType dataType, object frameValue)
        {
            if (FrameTypeAttribute.TypeToFrame.TryGetValue((KeyframeDataType)dataType, out var frame))
                return (IManagedFrame)GetJsonValue(frameValue, frame.GetType());

            return (IManagedFrame) GetJsonValue(frameValue, typeof(Unknown));
        }
        
        private static object GetJsonValue(object value, Type targetType)
        {
            if (value is JsonElement element)
                return JsonSerializer.Deserialize(element.ToString(), targetType, ManagedMenuMetadata.SerializerOptions);

            if (value.GetType() == targetType)
                return value;

            throw new Exception($"Cannot convert to specified type T ({nameof(targetType)})");
        }

        /// <summary>
        /// Reads the keyframe header from a given stream.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <param name="managedMenuMetadata"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static unsafe Keyframe Read(EndianStreamReader streamReader, ManagedMenuMetadata managedMenuMetadata)
        {
            var keyframe     = new Keyframe();
            var startingPos  = streamReader.Position();
            
            streamReader.Read(out KeyframeType type);
            streamReader.Read(out keyframe.AnimationActivationPointFrames);
            streamReader.Read(out short numberOfChangedProperties);
            streamReader.Read(out short numberOfBytesDivBy4);

            var keyframeType = type & (KeyframeType)0x7FFF;
            int sizeBytes = (keyframeType) switch
            {
                KeyframeType.HalfByteCount  => throw new NotSupportedException("Type 0 keyframe is not supported"),
                KeyframeType.SizeFromHeader => throw new NotSupportedException("Type 1 keyframe is not supported"),
                KeyframeType.SizeFromSameStructSimpleHeader  => numberOfBytesDivBy4 * 4,
                KeyframeType.SizeFromSameStructComplexHeader => numberOfBytesDivBy4 * 4,
                _ => throw new ArgumentOutOfRangeException()
            };

            // Invalid.
            if (numberOfChangedProperties < 0)
                return keyframe;

            switch (keyframeType)
            {
                case KeyframeType.SizeFromSameStructSimpleHeader:
                {
                    var headerPos    = startingPos + sizeof(Structs.Keyframe);
                    var valuesPos    = startingPos + (numberOfBytesDivBy4 - numberOfChangedProperties) * 4;

                    for (int x = 0; x < numberOfChangedProperties; x++)
                    {
                        streamReader.Seek(headerPos, SeekOrigin.Begin);
                        streamReader.Read(out short dataType);
                        streamReader.Seek(valuesPos, SeekOrigin.Begin);
                        AddFrame(keyframe, dataType, sizeof(int), streamReader);

                        headerPos += sizeof(Type2DataHeader);
                        valuesPos += sizeof(int);
                    }
                    break;
                }
                case KeyframeType.SizeFromSameStructComplexHeader:
                {
                    var headerPos = startingPos + sizeof(Structs.Keyframe);
                    var valuesPos = headerPos + (numberOfChangedProperties * sizeof(Type3DataHeader));
                    for (int x = 0; x < numberOfChangedProperties; x++)
                    {
                        streamReader.Seek(headerPos, SeekOrigin.Begin);
                        streamReader.Read(out short dataType);
                        streamReader.Read(out short numBytes);
                        streamReader.Seek(valuesPos, SeekOrigin.Begin);
                        AddFrame(keyframe, dataType, numBytes, streamReader);

                        headerPos += sizeof(Type3DataHeader);
                        valuesPos += numBytes;
                    }

                    break;
                }
            }

            // Seek to end of keyframe.
            streamReader.Seek(startingPos + sizeBytes, SeekOrigin.Begin);
            return keyframe;
        }

        private static void AddFrame(Keyframe keyframe, short dataType, short numBytes, EndianStreamReader streamReader)
        {
            if (FrameTypeAttribute.TypeToFrame.TryGetValue((KeyframeDataType)dataType, out var frame))
            {
                keyframe.Frames[(KeyframeDataType)dataType] = (IManagedFrame) frame.Read(streamReader);
                return;
            }

            var bytes = streamReader.ReadBytes(streamReader.Position(), numBytes);
            keyframe.Frames[(KeyframeDataType)dataType] = new Unknown()
            {
                Data = bytes,
                DataType = dataType
            };
        }
    }
}
