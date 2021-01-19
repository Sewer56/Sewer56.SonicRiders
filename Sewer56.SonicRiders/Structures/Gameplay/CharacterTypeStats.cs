using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Explicit, Size = 0x64)]
    public unsafe struct CharacterTypeStats
    {
        [FieldOffset(0x00)]
        public CharacterTypeLevelStats LevelOne;

        [FieldOffset(0x1C)]
        public CharacterTypeLevelStats LevelTwo;

        [FieldOffset(0x38)]
        public CharacterTypeLevelStats LevelThree;

        /// <summary>
        /// Returns the type stats for a specific level.
        /// </summary>
        /// <param name="stats">Pointer to type stats.</param>
        /// <param name="level">Current character level.</param>
        public static CharacterTypeLevelStats* GetLevelStats(CharacterTypeStats* stats, int level)
        {
            var levelOne = &stats->LevelOne;
            return &levelOne[level];
        }
    }
}
