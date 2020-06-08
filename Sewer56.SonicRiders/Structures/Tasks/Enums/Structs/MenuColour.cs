namespace Sewer56.SonicRiders.Structures.Tasks.Enums.Structs
{
    /// <summary>
    /// Defines the menu state for the individual menus used
    /// throughout the game. Depending on the menu, these can either
    /// trigger only animations or cause the next menu to be loaded/this menu closed.
    /// </summary>
    public enum MenuColour : byte
    {
        /// <summary>
        /// [Default] Sonic Blue.
        /// </summary>
        Blue = 0,

        /// <summary>
        /// [Extras] Knuckles Red.
        /// </summary>
        Red = 1,

        /// <summary>
        /// [Options] Tails Yellow.
        /// </summary>
        Yellow = 2,

        /// <summary>
        /// [Mission Mode] Storm Gray.
        /// </summary>
        Gray = 3,

        /// <summary>
        /// [Mission Mode] Wave Purple.
        /// </summary>
        Purple = 4,

        /// <summary>
        /// [Mission Mode] Jet Green.
        /// </summary>
        Green = 5,
    }
}
