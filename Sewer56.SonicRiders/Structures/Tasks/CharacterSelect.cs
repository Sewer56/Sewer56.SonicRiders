using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Tasks.Enums.Shared;
using Sewer56.SonicRiders.Structures.Tasks.Enums.Structs;

namespace Sewer56.SonicRiders.Structures.Tasks
{
    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x54)]
    public unsafe struct CharacterSelect
    {
        /// <summary>
        /// Loads the stage in question.
        /// </summary>
        [FieldOffset(0x8)]
        public byte SelectionIsPerformed;

        /// <summary>
        /// See <see cref="Enums.Shared.MenuState"/>
        /// </summary>
        [FieldOffset(0xC)]
        public MenuState MenuState;

        /// <summary>
        /// Set to true to show the "Are you Ready" prompt.
        /// Set to false to hide the prompt.
        /// </summary>
        [FieldOffset(0xF)]
        public bool AreYouReadyEnabled;

        /// <summary>
        /// Frame counter for the animation for the individual stars
        /// sliding in from the left side for the current gear.
        /// </summary>
        [FieldOffset(0x10)]
        public float StarsAnimationFrameCounterP1;

        /// <summary>
        /// Frame counter for the animation for the individual stars
        /// sliding in from the left side for the current gear.
        /// </summary>
        [FieldOffset(0x14)]
        public float StarsAnimationFrameCounterP2;

        /// <summary>
        /// Frame counter for the animation for the individual stars
        /// sliding in from the left side for the current gear.
        /// </summary>
        [FieldOffset(0x18)]
        public float StarsAnimationFrameCounterP3;

        /// <summary>
        /// Frame counter for the animation for the individual stars
        /// sliding in from the left side for the current gear.
        /// </summary>
        [FieldOffset(0x1C)]
        public float StarsAnimationFrameCounterP4;

        /// <summary>
        /// Defines the currently locked in Characters, these Characters
        /// cannot be re-selected.
        /// You may use <see cref="Structures.Enums.Characters"/> as in indexer here.
        /// </summary>
        [FieldOffset(0x20)]
        public fixed bool Characters[0x14];

        /// <summary>
        /// Points to something, right?
        /// </summary>
        [FieldOffset(0x34)]
        public int UnknownPointer;

        /// <summary>
        /// An array of <see cref="PlayerStatus"/> representing the player statuses.
        /// Note: Type is set to byte due to language limitations.
        /// </summary>
        [FieldOffset(0x38)]
        public fixed byte PlayerStatuses[0x4];

        /// <summary>
        /// The currently selected Characters on the character list for each player.
        /// See <see cref="Structures.Enums.Characters"/>.
        /// </summary>
        [FieldOffset(0x3C)]
        public fixed byte PlayerMenuSelections[0x4];

        /// <summary>
        /// Controls whether you can select a gear.
        /// </summary>
        [FieldOffset(0x48)]
        public RaceMode RaceMode;

        /// <summary>
        /// Defines the amount of currently active (joined in) players on the current menu.
        /// Setting this value to 0, exits the menu.
        /// </summary>
        [FieldOffset(0x49)]
        public byte CurrentlyActivePlayerCount;

        /// <summary>
        /// Defines the maximum number of players that are allowed to join the current game.
        /// </summary>
        [FieldOffset(0x4A)]
        public byte MaximumPlayerCount;

        /// <summary>
        /// 0xFF if a player can join in current slot, else index of player (0 = P1, 1 = P2 etc.).
        /// </summary>
        [FieldOffset(0x4B)]
        public fixed byte OpenPlayerSlots[0x4];
    }
}
