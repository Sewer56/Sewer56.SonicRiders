namespace Sewer56.SonicRiders.Structures.Menus.Enums
{
    /// <summary>
    /// Defines the menu or submenu that the player is currently in control of.
    /// Generally only useful in the case of synchronizing the stage select submenu.
    /// </summary>
    public enum ControllingMenu
    {
        MainMenu = 1,
        StageSelect = 3,
        StageSelectStageSubmenu = 5,
        TitleScreenPressEnter = 6,
        TitleSaveLoadAndBattleTrackSelect = 7,
        TitleMenu = 8,
        OpenRaceRules = 9,
        RaceRules = 10,
        ShopMenu = 15
    }
}
