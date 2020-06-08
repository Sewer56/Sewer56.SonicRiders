namespace Sewer56.SonicRiders.Structures.Tasks.Enums.Structs
{
    /// <summary>
    /// Specifies the variant of the main menu the user is currently in, 
    /// since Game State 15 is shared between multiple menus.
    /// </summary>
    public enum MainMenuVariation : byte
    {
        Default = 0,
        ExtrasMenu = 1,
        MissionMode = 2,
        Options = 3
    }
}
