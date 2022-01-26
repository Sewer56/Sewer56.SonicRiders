using System;
using System.Collections.Generic;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Enums;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Frames.Attributes
{
    /// <summary>
    /// Allows you to attach a frame type to a given class.
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
    public class FrameTypeAttribute : Attribute
    {
        /// <summary>
        /// The numerical type for this frame.
        /// </summary>
        public KeyframeDataType DataType { get; set; }
    }
}
