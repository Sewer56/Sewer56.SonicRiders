using System;
using System.Collections.Generic;
using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Structures.Misc;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    /// <summary>
    /// Header of an individual action layer.
    /// </summary>
    public struct ActionLayer
    {
        /// <summary>
        /// If this is less than 1, struct ends at <see cref="DurationOfLongestAnimation"/>.
        /// </summary>
        public short IsEnabled;
        
        public short Unk_1;
        
        // Struct may potentially end here.

        public short DurationOfLongestAnimation;
        
        public short UnknownFlag;
        
        public short Unk_4;
        
        public short Unk_5;

        public int Unknown_6;
    }

    public struct Layer
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
        public short MaybeAnimationDurationFrames;
        
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
        /// Returns a list of all keyframe data belonging to this specific layer.
        /// </summary>
        /// <param name="layer">The layer to get the keyframes for.</param>
        /// <param name="header">Header of the file from which the keyframes are sourced.</param>
        /// <param name="keySpan">The buffer to place the keyframes in.</param>
        /// <returns>The supplied buffer, sliced.</returns>
        public static unsafe Span<BlittablePointer<Keyframe>> GetKeyFrames(Layer* layer, MetadataHeader* header, Span<BlittablePointer<Keyframe>> keySpan)
        {
            int remainingFrames = layer->NumKeyframes;
            var currentPointer  = (byte*)(layer + 1);
            int numItems = 0;

            if (layer->MaybeAnimationDurationFrames <= 0 && remainingFrames <= 0)
                return keySpan.Slice(0, numItems);

            while (remainingFrames > 1)
            {
                var keyFramePtr    = (Keyframe*) currentPointer;
                var keyFrameLength = Keyframe.GetKeyframeSize(keyFramePtr, layer, header);
                var keyFrameType   = (short)(keyFramePtr->KeyframeType & (KeyframeType)0x7FFF);
                keySpan[numItems++] = keyFramePtr;

                // Animation ends if no duration, unless keyframes type 0/1
                if (keyFramePtr->AnimationActivationPointFrames < 1 && keyFrameType != 0 && keyFrameType != 1)
                    break;

                remainingFrames--;
                currentPointer += keyFrameLength;
            }

            return keySpan.Slice(0, numItems);
        }
    }
}