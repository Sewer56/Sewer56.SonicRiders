using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Menus.Enums
{
    /// <summary>
    /// Part of the <see cref="MainMenu"/> structure.
    /// Toggle this number in order to perform minor adjustments on the
    /// current menu.
    /// </summary>
    public enum MainMenuAction : byte
    {
        /// <summary>
        /// Resets the description box size on the bottom of the screen.
        /// </summary>
        ResetDescription = 1,

        Unknown = 2,
        Crash = 3,
        Unknown2 = 4,

        /// <summary>
        /// Unknown, causes a black background in some menus.
        /// </summary>
        DarkBackground = 5,

        SmallDescription = 6,
        SmallDescription2 = 7,
        LargeDescription = 8,
        LargeDescription2 = 9,

        /// <summary>
        /// Plays the enter animation for the description.
        /// </summary>
        DescriptionEnterAnimation = 10,

        /// <summary>
        /// Plays the leave animation for the description.
        /// </summary>
        DescriptionLeaveAnimation = 11
    }
}
