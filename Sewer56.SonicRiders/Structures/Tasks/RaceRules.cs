using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Tasks.Enums;
using Sewer56.SonicRiders.Structures.Tasks.Enums.Shared;
using Sewer56.SonicRiders.Structures.Tasks.Enums.Structs;

namespace Sewer56.SonicRiders.Structures.Tasks
{
    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct RaceRules
    {
        /// <summary>
        /// See <see cref="Enums.Shared.MenuState"/>
        /// </summary>
        [FieldOffset(0x1C)]
        public MenuState MenuState;

        [FieldOffset(0x1D)]
        public byte CurrentHorizontalSelection;

        [FieldOffset(0x1E)]
        public byte CurrentVerticalSelection;

        [FieldOffset(0x1F)]
        public byte VerticalItemCount;

        /* Options */

        [FieldOffset(0x20)]
        public byte TotalLaps;

        [FieldOffset(0x21)]
        public bool Announcer;

        [FieldOffset(0x22)]
        public bool Level;

        [FieldOffset(0x23)]
        public bool Item;

        [FieldOffset(0x24)]
        public bool Pit;

        [FieldOffset(0x25)]
        public AirLostActions AirLostAction;

        /* Max Options */

        [FieldOffset(0x26)]
        public byte MaxLapCount;

        [FieldOffset(0x27)]
        public byte MaxSelectionAnnouncer;

        [FieldOffset(0x28)]
        public byte MaxSelectionLevel;

        [FieldOffset(0x29)]
        public byte MaxSelectionItem;

        [FieldOffset(0x2A)]
        public byte MaxSelectionPit;

        [FieldOffset(0x2B)]
        public byte MaxSelectionAirLostAction;
    }
}
