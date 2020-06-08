using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Tasks.Base;
using Sewer56.SonicRiders.Structures.Tasks.Enums;
using Sewer56.SonicRiders.Structures.Tasks.Enums.Shared;
using Sewer56.SonicRiders.Structures.Tasks.Enums.Structs;

namespace Sewer56.SonicRiders.Structures.Tasks
{
    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct TitleSequence
    {
        /// <summary>
        /// Task for the current child menu of this menu.
        /// </summary>
        [FieldOffset(0x0)]
        public Task* ChildMenuTask;

        /// <summary>
        /// See <see cref="MenuState"/>
        /// </summary>
        [FieldOffset(0xC)]
        public MenuState State;

        [FieldOffset(0xD)]
        public byte Selection;

        /// <summary>
        /// See <see cref="MainMenuAction"/>
        /// </summary>
        [FieldOffset(0x1C)]
        public MainMenuAction Action;

        /// <summary>
        /// Changes the colour of the main menu and all submenus.
        /// </summary>
        [FieldOffset(0x1E)]
        public MenuColour Colour;

        /// <summary>
        /// Seems to have more effect than changing the title sprite, but for now, such name will do.
        /// </summary>
        [FieldOffset(0x1F)]
        public byte MenuTitleSprite;

        /// <summary>
        /// Defined as this based off of observation.
        /// Something related to the last menu the user exited from.
        /// It is unknown what this is used for.
        /// </summary>
        [FieldOffset(0x28)]
        public int* LastMenuPointer;

        /// <summary>
        /// Used to determine the selectable options on screen by index and menus they will enter.
        /// See <see cref="MainMenuVariation"/> for more details.
        /// </summary>
        [FieldOffset(0x39)]
        public MainMenuVariation MenuVariation;

        /// <summary>
        /// The mode the characters will race in.
        /// </summary>
        [FieldOffset(0x3C)]
        public RaceMode RaceMode;
    }
}
