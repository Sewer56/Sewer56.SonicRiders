using System.Numerics;
using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Utility.Math;
// ReSharper disable InvalidXmlDocComment

namespace Sewer56.SonicRiders.Structures.Tasks
{    
    /// <summary>
    /// Contains the common details of the task for a single placeable object.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x7F)]
    public unsafe struct SetObjectTaskData
    {
        // Commented out lines are things I'm unsure about.
        // Item task data is not standardised.

        /// <summary>
        /// Current Position of the Item
        /// </summary>
        [FieldOffset(0x0)]
        public Vector3 Position;

        /// <summary>
        /// Current Position of the Item
        /// </summary>
        //[FieldOffset(0xC)]
        //public float UnknownFloat;

        /// <summary>
        /// Current Position of the Item
        /// </summary>
        [FieldOffset(0x20)]
        public Vector3Int RotationBams;

        /// <summary>
        /// Current item attribute.
        /// </summary>
        ///[FieldOffset(0x5F)]
        //public byte Attribute;

        /// <summary>
        /// Current Item Scale
        /// </summary>
        //[FieldOffset(0x60)]
        //public Vector3 Scale;
    }
}