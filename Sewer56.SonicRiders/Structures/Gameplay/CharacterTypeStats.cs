using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Explicit, Size = 0x64)]
    public struct CharacterTypeStats
    {
        /// <summary>
        /// Default 0.75 for Speed Type.
        /// Multiplier for the default maximum speed the character can have onboard.
        /// </summary>
        [FieldOffset(0x00)]
        public float MaxSpeedMultiplier;
    }

}
