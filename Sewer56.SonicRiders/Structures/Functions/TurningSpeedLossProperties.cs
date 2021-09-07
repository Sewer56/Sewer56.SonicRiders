using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Functions
{
    [StructLayout(LayoutKind.Explicit, Size = 0x54)] // Unsure about side.
    public struct TurningSpeedLossProperties
    {
        /// <summary>
        /// This value gets multiplied by itself 3 times; then multiplies the new speed calc.
        /// </summary>
        [FieldOffset(0)]
        public float CubedMultiplier;

        /// <summary>
        /// Linear speed multiplier.
        /// </summary>
        [FieldOffset(0x50)]
        public float LinearMultiplier;
    }
}