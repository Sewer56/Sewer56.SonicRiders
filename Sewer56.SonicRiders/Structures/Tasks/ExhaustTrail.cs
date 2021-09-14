using Sewer56.SonicRiders.Structures.Gameplay;
using Sewer56.SonicRiders.Structures.Misc;
using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Tasks
{

    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct ExhaustTrail
    {
        /// <summary>
        /// Pointer to the player to render the exhaust for.
        /// </summary>
        [FieldOffset(0x1C)]
        public Player* Player;

        /// <summary>
        /// The colour of the exhaust trail.
        /// </summary>
        [FieldOffset(0x54)]
        public ColorRGBA ExhaustTrailColour;
    }
}