using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Tasks.Enums.Shared;

namespace Sewer56.SonicRiders.Structures.Tasks
{
    [StructLayout(LayoutKind.Explicit)]
    public struct MessageBox
    {
        /// <summary>
        /// Controls the text shown in the selectable options.
        /// </summary>
        [FieldOffset(0xA)]
        public byte YesNoText;

        /// <summary>
        /// Controls the text shown in the selectable options.
        /// </summary>
        [FieldOffset(0xC)]
        public short FrameCounter;

        /// <summary>
        /// No buttons, only text.
        /// </summary>
        [FieldOffset(0xE)]
        public byte HasOnlyText;

        /// <summary>
        /// Item selected during this frame, this is -1 if no item is clicked.
        /// </summary>
        [FieldOffset(0x10)]
        public byte ClickedItem;

        /// <summary>
        /// Number of selectable menu items.
        /// </summary>
        [FieldOffset(0x11)]
        public byte NumberOfSelections;

        /// <summary>
        /// Number of selectable menu items.
        /// </summary>
        [FieldOffset(0x15)]
        public byte NumberOfDisplayedItems;

        /// <summary>
        /// Current menu state.
        /// </summary>
        [FieldOffset(0x15)]
        public MenuState MenuState;

        /// <summary>
        /// Current variation of text (e.g. Loading or Saving)
        /// </summary>
        [FieldOffset(0x1C)]
        public byte TextVariation;
    }
}