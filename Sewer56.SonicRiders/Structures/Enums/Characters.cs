using System;
using System.Collections.Generic;
using System.Text;

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
