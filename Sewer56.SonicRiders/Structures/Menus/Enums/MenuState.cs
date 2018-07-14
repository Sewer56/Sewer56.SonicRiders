using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Menus.Enums
{
    /// <summary>
    /// Defines the menu state for the individual menus used
    /// throughout the game. Depending on the menu, these can either
    /// trigger only animations or cause the next menu to be loaded/this menu closed.
    /// </summary>
    public enum MenuState : byte
    {
        /// <summary>
        /// Generally reloads the menu.
        /// </summary>
        Reset = 0,

        /// <summary>
        /// Plays the menu entry animation.
        /// </summary>
        Enter = 1,

        /// <summary>
        /// Default state once inside the menu.
        /// </summary>
        Running = 2,

        /// <summary>
        /// Typically just plays the exit animation.
        /// In some cases, it can lead to the next screen or go back to last.
        /// </summary>
        Exit = 3,

        /// <summary>
        /// Default state once <see cref="Exit"/> finishes.
        /// </summary>
        Closed = 4
    }
}
