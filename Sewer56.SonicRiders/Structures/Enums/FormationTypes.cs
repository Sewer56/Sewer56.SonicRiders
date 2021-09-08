using System;

namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum FormationTypes : int
    {
        Speed,
        Fly,
        Power
    }

    [Flags]
    public enum FormationTypesFlags : int
    {
        Speed = 0x1,
        Fly = 0x2,
        Power = 0x4
    }

    public static class FormationTypesExtensions
    {
        /// <summary>
        /// Checks if the given set of flags contains a specific type.
        /// </summary>
        /// <param name="flags">The flags to check.</param>
        /// <param name="type">The type to check for.</param>
        public static bool ContainsType(this FormationTypesFlags flags, FormationTypes type)
        {
            var flag = 1 << (int) type;
            return ((int)flags & flag) != 0;
        }
    }
}
