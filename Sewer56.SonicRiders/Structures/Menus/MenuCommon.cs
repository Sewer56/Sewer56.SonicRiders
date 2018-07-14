using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Menus.Enums;

namespace Sewer56.SonicRiders.Structures.Menus
{
    /// <summary>
    /// Note: Size is a decent estimate, real size is not known.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct MenuCommon
    {
        /// <summary>
        /// See <see cref="ControllingMenu"/>
        /// </summary>
        [FieldOffset(0x14)]
        public ControllingMenu currentlyControllingMenu;
    }
}
