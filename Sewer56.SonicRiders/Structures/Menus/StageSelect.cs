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
    public unsafe struct StageSelect
    {
        [FieldOffset(0x2C)]
        public MenuState menuState;

        [FieldOffset(0x2D)]
        public byte currentSelectionHorizontal;

        [FieldOffset(0x2E)]
        public byte currentSelectionVertical;

        [FieldOffset(0x2F)]
        public MenuState submenuState;

        /// <summary>
        /// Individual Track Order by Index. i.e. 1 2 3 4 5 6 7 8
        /// </summary>
        [FieldOffset(0x30)]
        public fixed byte stageOrder[8];

        /// <summary>
        /// Stage Select List Scroll Value.
        /// e.g. Setting 1 makes Splash Canyon on left.
        /// </summary>
        [FieldOffset(0x38)]
        public byte listScrollOffset;

        /// <summary>
        /// Vertical submenu selection.
        /// e.g. Setting 1 selects Night Chase in Metal City's submenu.
        /// </summary>
        [FieldOffset(0x3A)]
        public byte submenuSelection;

        /// <summary>
        /// Vertical submenu selection.
        /// e.g. Setting 1 selects Night Chase in Metal City's submenu.
        /// </summary>
        [FieldOffset(0x3C)]
        public byte trackSelectMode;
    }
}
