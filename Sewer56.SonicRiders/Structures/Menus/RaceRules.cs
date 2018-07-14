using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Sewer56.SonicRiders.Structures.Menus.Enums;

namespace Sewer56.SonicRiders.Structures.Menus
{
    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct RaceRules
    {
        /// <summary>
        /// See <see cref="MenuState"/>
        /// </summary>
        [FieldOffset(0x1C)]
        public MenuState menuState;

        [FieldOffset(0x1D)]
        public byte currentHorizontalSelection;

        [FieldOffset(0x1E)]
        public byte currentVerticalSelection;

        [FieldOffset(0x1F)]
        public byte menuItemCount;

        /* Options */

        [FieldOffset(0x20)]
        public byte totalLapsCount;

        [FieldOffset(0x21)]
        public bool announcer;

        [FieldOffset(0x22)]
        public bool level;

        [FieldOffset(0x23)]
        public bool item;

        [FieldOffset(0x24)]
        public bool pit;

        [FieldOffset(0x25)]
        public AirLostActions airLostAction;

        /* Max Options */

        [FieldOffset(0x26)]
        public byte maxSelectionLapCount;

        [FieldOffset(0x27)]
        public byte maxSelectionAnnouncer;

        [FieldOffset(0x28)]
        public byte maxSelectionLevel;

        [FieldOffset(0x29)]
        public byte maxSelectionItem;

        [FieldOffset(0x2A)]
        public byte maxSelectionPit;

        [FieldOffset(0x2B)]
        public byte maxSelectionAirLostAction;
    }
}
