using System.Collections.Generic;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class Keyframe
    {
        /// <summary>
        /// The keyframe encoding used for this keyframe.
        /// </summary>
        /// public KeyframeType KeyframeType;

        /// <summary>
        /// The number of frames after which this keyframe activates.
        /// </summary>
        public short AnimationActivationPointFrames;

        /// <summary>
        /// List of all frames to attach to this keyframe.
        /// </summary>
        public List<IManagedFrame> Frames { get; set; }

        /// <summary>
        /// Number of properties changed by the keyframe.
        /// </summary>
        /// public short NumberOfChangedProperties;

        /// <summary>
        /// Size of the whole keyframe (divided by 4). Relative to the start of this struct.
        /// </summary>
        /// public short NumberOfBytesDivBy4;
    }
}
