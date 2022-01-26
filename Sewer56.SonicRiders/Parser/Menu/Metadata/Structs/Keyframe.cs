using System;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Helpers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    public struct Keyframe
    {
        /// <summary>
        /// The keyframe encoding used for this keyframe.
        /// </summary>
        public KeyframeType KeyframeType;

        /// <summary>
        /// The number of frames after which this keyframe activates.
        /// </summary>
        public short AnimationActivationPointFrames;
        
        /// <summary>
        /// Number of properties changed by the keyframe.
        /// </summary>
        public short NumberOfChangedProperties;
        
        /// <summary>
        /// Size of the whole keyframe (divided by 4). Relative to the start of this struct.
        /// </summary>
        public short NumberOfBytesDivBy4;

        /// <summary>
        /// Gets the size of this keyframe, in bytes.
        /// </summary>
        /// <param name="keyframe">The keyframe for which to get the size for.</param>
        /// <param name="layer">The layer in question.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        public static unsafe int GetKeyframeSize(Keyframe* keyframe, Layer* layer, MetadataHeader* header)
        {
            switch ((keyframe->KeyframeType & (KeyframeType)0x7FFF))
            {
                default:
                case KeyframeType.HalfByteCount:
                    return layer->NumBytes + sizeof(Keyframe); // +8 may be an error here, but parses existing files.
                case KeyframeType.SizeFromHeader:
                    return header->AnimationType1Offset * 4; // Typically 0x14 * 4
                case KeyframeType.SizeFromSameStructSimpleHeader:
                case KeyframeType.SizeFromSameStructComplexHeader:
                    return keyframe->NumberOfBytesDivBy4 * 4;
            }
        }

        /// <summary>
        /// Gets the individual data items for a given keyframe.
        /// </summary>
        /// <param name="keyframe">Pointer to the keyframe in question.</param>
        /// <param name="layer">Pointer to the layer in question.</param>
        /// <param name="header">Pointer to the archive header.</param>
        /// <param name="stack">Preallocated stack memory. Recommend 32 items.</param>
        /// <returns></returns>
        public unsafe Span<DataHeaderWrapper> GetData(Keyframe* keyframe, Layer* layer, MetadataHeader* header, Span<DataHeaderWrapper> stack)
        {
            // Invalid.
            if (keyframe->NumberOfChangedProperties < 0)
                return stack.Slice(0, 0);

            var keyframeType = (keyframe->KeyframeType & (KeyframeType)0x7FFF);
            switch (keyframeType)
            {
                default:
                case KeyframeType.HalfByteCount: // 0
                {
                    var result = new DataHeaderWrapper()
                    {
                        DataType = DataHeaderWrapper.InvalidDataType,
                        NumBytes = layer->NumBytes,
                        DataPtr = (byte*)(keyframe + 1)
                    };
                    stack[0] = result;
                    return stack.Slice(0, 1);
                }

                case KeyframeType.SizeFromHeader: // 1
                {
                    var result = new DataHeaderWrapper()
                    {
                        DataType = DataHeaderWrapper.InvalidDataType,
                        NumBytes = (short)(header->AnimationType1Offset * 4),
                        DataPtr = (byte*)(keyframe + 1)
                    };
                    stack[0] = result;
                    return stack.Slice(0, 1);
                }

                case KeyframeType.SizeFromSameStructSimpleHeader: // 2
                {
                    var headersPtr   = (Type2DataHeader*)(keyframe + 1);
                    var valuesOffset = ((keyframe->NumberOfBytesDivBy4 - keyframe->NumberOfChangedProperties) * 4);
                    var valuesPtr    = (int*)((byte*)keyframe + valuesOffset);

                    for (int x = 0; x < keyframe->NumberOfChangedProperties; x++)
                    {
                        stack[x] = new DataHeaderWrapper()
                        {
                            DataType = headersPtr->DataType,
                            NumBytes = sizeof(int),
                            DataPtr = (byte*)valuesPtr,
                        };

                        valuesPtr++;
                        headersPtr++;
                    }

                    return stack.Slice(0, keyframe->NumberOfChangedProperties);
                }

                case KeyframeType.SizeFromSameStructComplexHeader: // 3
                {
                    var headersPtr   = (Type3DataHeader*)(keyframe + 1);
                    var valuesOffset = (keyframe->NumberOfChangedProperties * sizeof(Type3DataHeader));
                    var valuesPtr    = (byte*)headersPtr + valuesOffset;

                    for (int x = 0; x < keyframe->NumberOfChangedProperties; x++)
                    {
                        stack[x] = new DataHeaderWrapper()
                        {
                            DataType = headersPtr->DataType,
                            NumBytes = headersPtr->NumBytes,
                            DataPtr  = valuesPtr,
                        };

                        valuesPtr += headersPtr->NumBytes;
                        headersPtr++;
                    }

                    return stack.Slice(0, keyframe->NumberOfChangedProperties);
                }
            }
        }
    }
}