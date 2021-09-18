using System.Numerics;
using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    /// <summary>
    /// Defines the structure of an object which modifies how gravity is applied upon a player.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x1E)] // Unsure about size
    public unsafe struct GravityObject
    {
        /// <summary>
        /// Pointer to the first segment/coordinate along the object's points.
        /// </summary>
        [FieldOffset(4)]
        public Vector4* pFirstSegment;

        /// <summary>
        /// Number of segments in the <see cref="pFirstSegment"/> array.
        /// </summary>
        [FieldOffset(0x1C)]
        public ushort NumSegments;
    }
}