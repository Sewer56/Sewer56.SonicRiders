namespace Sewer56.SonicRiders.Structures.Tasks.Enums.States
{
    public enum TitleSequenceTaskState : byte
    {
        /// <summary>
        /// Set this to 1 and a new race is loaded. Strange, isn't it?
        /// </summary>
        LoadRace = 1,
        Race = 2,
        
        SetSplashScreen = 10,
        CheckHeapAndSetSplashScreen = 11,
        SplashScreen = 12,
        TitleScreen = 13,

        /// <summary>
        /// Also valid for the Extras and Options menu.
        /// </summary>
        MainMenu = 15,

        NormalRaceSubmenu = 16,
        StorySubmenu = 17,
        MissionSubmenu = 18,
        LoadTagSubmenu = 19,
        SurvivalSubmenu = 20,
        LoadShopSubmenu = 21,
        CourseSelect = 22,
        TimeTrialSaving = 23,
        CharacterSelect = 24,
        Shop = 25,
        LoadExtras = 26,
        LoadOptions = 27,
        ExtrasSubmenus = 28,
        OptionsSubmenus = 29,
        LoadTitleScreen = 30,

        LoadSubmenuAfterReturnToTitleSequence = 34,
        LoadMainMenu = 31,
        MissionSelect = 38
    }
}
