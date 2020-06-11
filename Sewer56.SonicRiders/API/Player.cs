using System;
using System.Diagnostics;
using Reloaded.Memory.Kernel32;
using Reloaded.Memory.Pointers;
using Reloaded.Memory.Sources;
using Sewer56.SonicRiders.Structures.Gameplay;
using Sewer56.SonicRiders.Structures.Input;
using Sewer56.SonicRiders.Structures.Input.Enums;

namespace Sewer56.SonicRiders.API
{
    /// <summary>
    /// Everything needed to manipulate individual players and overall gameplay.
    /// </summary>
    public static unsafe class Player
    {
        public const int MaxNumberOfPlayers = 8;
        public static readonly int NumberOfGears = 41;

        static Player()
        {
            if (Process.GetCurrentProcess().MainModule.ModuleName.Equals("SonicRiders.exe", StringComparison.OrdinalIgnoreCase))
            {
                Memory.CurrentProcess.ChangePermission((IntPtr)RunPhysics, sizeof(RunningPhysics), Kernel32.MEM_PROTECTION.PAGE_EXECUTE_READWRITE);
            }
        }

        /// <summary>
        /// The array containing the individual player data.
        /// </summary>
        public static RefFixedArrayPtr<Structures.Gameplay.Player> Players => new RefFixedArrayPtr<Structures.Gameplay.Player>(0x006A4B80, MaxNumberOfPlayers);

        /// <summary>
        /// The array containing the individual player inputs.
        /// </summary>
        public static RefFixedArrayPtr<PlayerInput> Inputs => new RefFixedArrayPtr<PlayerInput>(0x017E4580, MaxNumberOfPlayers);

        /// <summary>
        /// Allows you to access the information of any particular extreme gear.
        /// In order to access an individual gear, access this variable like an array, with
        /// <see cref="Sewer56.SonicRiders.Structures.Enums.ExtremeGear"/> as an indexer.
        /// </summary>
        public static FixedArrayPtr<ExtremeGear> Gears => new FixedArrayPtr<ExtremeGear>(0x6575B0, NumberOfGears);

        /// <summary>
        /// Contains the individual statistics/properties Speed, Flight and Power characters.
        /// </summary>
        public static RefFixedArrayPtr<CharacterTypeStats> TypeStats => new RefFixedArrayPtr<CharacterTypeStats>(0x005BD4D8, 3);

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
    }
}
