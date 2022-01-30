using System;
using System.Collections.Generic;
using System.Reflection;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Frames.Attributes
{
    /// <summary>
    /// Allows you to attach a frame type to a given class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class FrameTypeAttribute : Attribute
    {
        /// <summary>
        /// Maps a given keyframe type to their respective frames.
        /// </summary>
        public static Dictionary<KeyframeDataType, IManagedFrame> TypeToFrame = new();

        /// <summary>
        /// The numerical type for this frame.
        /// </summary>
        public KeyframeDataType DataType { get; set; }

        static FrameTypeAttribute()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                var frameType = type.GetCustomAttribute<FrameTypeAttribute>();
                if (frameType != null)
                    TypeToFrame[frameType.DataType] = (IManagedFrame) Activator.CreateInstance(type);
            }
        }
    }
}
