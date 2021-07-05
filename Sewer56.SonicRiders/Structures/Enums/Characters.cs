using System;
using System.Collections.Generic;

namespace Sewer56.SonicRiders.Structures.Enums
{
    /// <summary>
    /// Defines the list of character IDs used internally in the game.
    /// </summary>
    public enum Characters : byte
    {
        Sonic,
        Tails,
        Knuckles,
        Amy,
        Jet,
        Storm,
        Wave,
        Robotnik,
        Cream,
        Rouge,
        Shadow,
        SuperSonic,
        Nights,
        AiAi,
        Ulala,
        E10000G,
        E10000R,
    }

    public static class CharactersExtensions
    {
        private static Dictionary<Characters, char> _character = new Dictionary<Characters, char>()
        {
            { Characters.Nights, '0' },
            { Characters.AiAi, '1' },
            { Characters.Ulala, '2' },
            { Characters.Amy, 'A' },
            { Characters.Cream, 'C' },
            { Characters.Shadow, 'D' },
            { Characters.Robotnik, 'E' },
            { Characters.Jet, 'J' },
            { Characters.Knuckles, 'K' },
            { Characters.Storm, 'M' },
            { Characters.E10000R, 'O' },
            { Characters.SuperSonic, 'P' },
            { Characters.Rouge, 'R' },
            { Characters.Sonic, 'S' },
            { Characters.Tails, 'T' },
            { Characters.Wave, 'W' },
            { Characters.E10000G, 'Z' },
        };

        /// <summary>
        /// Gets the character used to represent this character in File Names.
        /// </summary>
        public static char GetFilenameChar(this Characters character) => _character[character];
    }

    /// <summary>
    /// Defines the list of character IDs used internally in the game.
    /// </summary>
    [Flags]
    public enum CharactersFlags : int
    {
        Sonic = 0x000001,
        Tails = 0x000002,
        Knuckles = 0x000004,
        Amy = 0x000008,
        Jet = 0x000010,
        Storm = 0x000020,
        Wave = 0x000040,
        Robotnik = 0x000080,
        Cream = 0x000100,
        Rouge = 0x000200,
        Shadow = 0x000400,
        SuperSonic = 0x000800,
        Nights = 0x001000,
        AiAi = 0x002000,
        Ulala = 0x004000,
        E10000G = 0x008000,
        E10000R = 0x010000,
    }
}
