using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Menus.Enums;

namespace Sewer56.SonicRiders.Structures.Menus
{
    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct TitleScreen
    {
        /// <summary>
        /// See <see cref="Enums.MenuState"/>
        /// </summary>
        [FieldOffset(0xC)]
        public MenuState MenuState;

        [FieldOffset(0xD)]
        public byte CurrentSelection;
    }
}
