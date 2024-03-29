﻿using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.Structures.Gameplay;
using Sewer56.SonicRiders.Structures.Input;
using Sewer56.SonicRiders.Structures.Input.Enums;
using ExtremeGear = Sewer56.SonicRiders.Structures.Gameplay.ExtremeGear;

namespace Sewer56.SonicRiders.API
{
    /// <summary>
    /// Everything needed to manipulate individual players and overall gameplay.
    /// </summary>
    public static unsafe class Player
    {
        public const int MaxNumberOfPlayers = 8;

        /// <summary>
        /// Number of the game's original gears.
        /// </summary>
        public static readonly int OriginalNumberOfGears = 41;

        /// <summary>
        /// Number of the game's original characters.
        /// </summary>
        public static readonly int OriginalNumberOfCharacters = 17;

        /// <summary>
        /// The current number of gears.
        /// </summary>
        public static int NumberOfGears = 41;

        /// <summary>
        /// The array containing the individual player data.
        /// </summary>
        public static RefFixedArrayPtr<Structures.Gameplay.Player> Players = new(0x006A4B80, MaxNumberOfPlayers);

        /// <summary>
        /// The array containing the individual player data.
        /// </summary>
        public static RefFixedArrayPtr<CharacterParameters> CharacterParameters = new(0x5C2D18, OriginalNumberOfCharacters);

        /// <summary>
        /// The array containing the individual player inputs.
        /// </summary>
        public static RefFixedArrayPtr<PlayerInput> Inputs = new(0x017E4580, MaxNumberOfPlayers);

        /// <summary>
        /// Allows you to access the information of any particular extreme gear.
        /// In order to access an individual gear, access this variable like an array, with
        /// <see cref="Sewer56.SonicRiders.Structures.Enums.ExtremeGear"/> as an indexer.
        /// </summary>
        public static FixedArrayPtr<ExtremeGear> Gears = new(0x6575B0, OriginalNumberOfGears);

        /// <summary>
        /// Contains the character colours in RGBA format (1 byte per color).
        /// Last slot is used by COM.
        /// </summary>
        public static RefFixedArrayPtr<int> Colours = new(0x005B2538, 18);

        /// <summary>
        /// Contains the individual statistics/properties Speed, Flight and Power characters.
        /// </summary>
        public static RefFixedArrayPtr<CharacterTypeStats> TypeStats = new(0x5BD4D0, 3);

        /// <summary>
        /// Provides you control over the turbulence in the game.
        /// </summary>
        public static RefFixedArrayPtr<TurbulenceProperties> TurbulenceProperties  = new((nuint)0x005C4500, (int)(TurbulenceType.TrickRainbowTopPath + 1) * 3);

        /// <summary>
        /// The first set of Running Physics values.
        /// See <see cref="RunPhysics2"/> for the rest.
        /// </summary>
        public static readonly RunningPhysics* RunPhysics = (RunningPhysics*)0x005C30F8;

        /// <summary>
        /// The second set of Running Physics values.
        /// See <see cref="RunPhysics"/> for the rest.
        /// </summary>
        public static readonly RunningPhysics2* RunPhysics2 = (RunningPhysics2*)0x0065C534;

        /// <summary>
        /// Updated when a button on the main menu is newly pressed.
        /// </summary>
        public static readonly Buttons* MenuInputPress = (Buttons*)0x017E4704;

        /// <summary>
        /// Updated when holding a button in the main menu every ~3 frames.
        /// </summary>
        public static readonly Buttons* MenuInputHold = (Buttons*)0x017E470C;

        /// <summary>
        /// Gets the player index of an individual pointer.
        /// </summary>
        /// <param name="ptr">The pointer to the player structure.</param>
        /// <returns>Returns the player index based off of the player pointer. Otherwise -1 if not found.</returns>
        public static unsafe int GetPlayerIndex(Structures.Gameplay.Player* ptr)
        {
            for (int x = 0; x < Players.Count; x++)
            {
                if (ptr == &Players.Pointer[x])
                    return x;
            }

            return -1;
        }

        /// <summary>
        /// Gets the player index of an individual pointer by checking if the pointer falls in
        /// the range between the start and end of any of the player structs.
        /// </summary>
        /// <param name="ptr">The pointer to somewhere inside a valid player structure.</param>
        /// <param name="result">Pointer to the player struct this mid struct ptr belongs to.</param>
        /// <returns>Returns the player index based off of the player pointer. Otherwise -1 if not found.</returns>
        public static unsafe int GetPlayerIndexFromMidStructPtr(void* ptr, out Structures.Gameplay.Player* result)
        {
            for (int x = 0; x < Players.Count; x++)
            {
                var current = &Players.Pointer[x];
                var next    = current + 1;

                if (ptr >= current && ptr < next)
                {
                    result = current;
                    return x;
                }
            }

            result = default;
            return -1;
        }
    }
}
