using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CharacterTypeStats
    {
        public CharacterTypeLevelStats LevelOne;
        public CharacterTypeLevelStats LevelTwo;
        public CharacterTypeLevelStats LevelThree;

        public float Unknown_1;
        public float Unknown_2;
        public float Unknown_3;
        public float Unknown_4;

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
