using System.Collections.Generic;

namespace Sewer56.SonicRiders.API
{
    /// <summary>
    /// Menu related variables.
    /// </summary>
    public static unsafe class Menu
    {
        public static Dictionary<nint, MenuEntry> LayoutPointerToMenuEntry = new();
        public static Dictionary<nint, MenuEntry> XvrsPointerToMenuEntry = new();

        static Menu()
        {
            MainMenu = AddItem(new MenuEntry()
            {
                FriendlyName = "Main Menu",
                LayoutPointer = (void**)0x17DD610,
                XvrsPointer = (void**)0x17DD614
            });

            CourseSelect = AddItem(new MenuEntry()
            {
                FriendlyName = "Course Select",
                LayoutPointer = (void**)0x17DD600,
                XvrsPointer = (void**)0x17DD604
            });

            CharacterSelect = AddItem(new MenuEntry()
            {
                FriendlyName = "Character Select",
                LayoutPointer = (void**)0x17DD640,
                XvrsPointer = (void**)0x17DD644
            });

            MissionMode = AddItem(new MenuEntry()
            {
                FriendlyName = "Mission Mode",
                LayoutPointer = (void**)0x17DD5F0,
                XvrsPointer = (void**)0x17DD5F4
            });

            Pro2D = AddItem(new MenuEntry()
            {
                FriendlyName = "Pro 2D",
                LayoutPointer = (void**)0x17DD620,
                XvrsPointer = (void**)0x17DD624
            });

            Extras = AddItem(new MenuEntry()
            {
                FriendlyName = "Extras",
                LayoutPointer = (void**)0x17DD5F8,
                XvrsPointer = (void**)0x17DD5FC
            });

            static MenuEntry AddItem(MenuEntry entry)
            {
                LayoutPointerToMenuEntry[(nint)entry.LayoutPointer] = entry;
                XvrsPointerToMenuEntry[(nint)entry.XvrsPointer] = entry;
                return entry;
            }
        }

        public static readonly MenuEntry MainMenu;
        public static readonly MenuEntry CourseSelect;
        public static readonly MenuEntry CharacterSelect;
        public static readonly MenuEntry MissionMode;
        public static readonly MenuEntry Pro2D;
        public static readonly MenuEntry Extras;
    }

    /// <summary>
    /// User friendly abstraction over the individual assets for menus.
    /// </summary>
    public unsafe struct MenuEntry
    {
        /// <summary>
        /// Friendly name
        /// </summary>
        public string FriendlyName;

        /// <summary>
        /// Pointer to the game's pointer to the Xvrs Texture Archive.
        /// </summary>
        public void** XvrsPointer;

        /// <summary>
        /// Pointer to the game's pointer to the metadata layout file.
        /// </summary>
        public void** LayoutPointer;
    }
}
