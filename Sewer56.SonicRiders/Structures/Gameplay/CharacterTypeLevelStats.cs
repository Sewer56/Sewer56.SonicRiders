using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct CharacterTypeLevelStats
    {
        /// <summary>
        /// Default 0.75 for Speed Type.
        /// Multiplier for the default maximum speed the character can have onboard.
        /// </summary>
        [FieldOffset(0x00)]
        public float AdditiveSpeed;

        /// <summary>
        /// Current acceleration of the character.
        /// </summary>
        [FieldOffset(0x04)]
        public float LowSpeedAccel;

        [FieldOffset(0x08)]
        public float Field_08;

        [FieldOffset(0x0C)]
        public float HighSpeedAccel;

        [FieldOffset(0x10)]
        public float OffRoadCruisingResistance;

        [FieldOffset(0x14)]
        public float Field_14;

        [FieldOffset(0x18)]
        public float Field_18;
    }
}