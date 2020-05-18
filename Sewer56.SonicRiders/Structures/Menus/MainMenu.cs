using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Menus.Enums;

namespace Sewer56.SonicRiders.Structures.Menus
{
    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct MainMenu
    {
        /// <summary>
        /// See <see cref="Enums.MenuState"/>
        /// </summary>
        [FieldOffset(0x0)]
        public MenuCommon* MenuCommonPointer;

        /// <summary>
        /// See <see cref="Enums.MenuState"/>
        /// </summary>
        [FieldOffset(0xC)]
        public MenuState MenuState;

        [FieldOffset(0xD)]
        public byte CurrentSelection;

        /// <summary>
        /// See <see cref="Enums.MainMenuAction"/>
        /// </summary>
        [FieldOffset(0x1C)]
        public MainMenuAction MainMenuAction;

        /// <summary>
        /// Changes the colour of the main menu and all submenus.
        /// </summary>
        [FieldOffset(0x1E)]
        public MenuColour MenuColour;

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
        /// See <see cref="Enums.MainMenuVariation"/> for more details.
        /// </summary>
        [FieldOffset(0x39)]
        public MainMenuVariation MainMenuVariation;

        /// <summary>
        /// The mode the characters will race in.
        /// </summary>
        [FieldOffset(0x3C)]
        public RaceMode RaceMode;
    }
}
