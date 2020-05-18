using Sewer56.SonicRiders.Structures.Input.Enums;
using Sewer56.SonicRiders.Structures.Menus;

namespace Sewer56.SonicRiders.Fields
{
    /// <summary>
    /// This class allows you to access the individual menus
    /// of the game through the use of pointers.
    /// It is best advised you check the <see cref="Variables.GameState"/> to first verify which menu you are in.
    /// </summary>
    public static unsafe class Menus
    {
        /// <summary>
        /// Updated when a button on the main menu is newly pressed.
        /// </summary>
        public static Buttons* MenuInputPress = (Buttons*) 0x017E4704;

        /// <summary>
        /// Updated when holding a button in the main menu every ~3 frames.
        /// </summary>
        public static Buttons* MenuInputHold  = (Buttons*) 0x017E470C;


        public static MainMenu* MainMenu;
        public static CharacterSelectMenu* CharacterSelectMenu;
        public static MenuCommon* MenuCommon;
        public static StageSelect* StageSelect;
        public static TitleScreen* TitleScreen;
        public static RaceRules* RaceRules;

        /// <summary>
        /// Static init set values.
        /// </summary>
        static Menus()
        {
            Refresh();
        }

        /// <summary>
        /// You should note that some menu pointers are only set when you enter the individual menu.
        /// You may need to use this method to re/set the addresses when entering a new menu.
        /// </summary>
        public static void Refresh()
        {
            MainMenu = (MainMenu*)*(int*)0x16BF1D8;
            CharacterSelectMenu = (CharacterSelectMenu*)((byte*)MainMenu + 0x80);
            MenuCommon = MainMenu->MenuCommonPointer;
            StageSelect = (StageSelect*)*(int*)0x16BF1CC;
            TitleScreen = (TitleScreen*)*(int*)0x16BF1CC;
            RaceRules = (RaceRules*)((byte*)MainMenu + 0x80);
        }
    }
}
