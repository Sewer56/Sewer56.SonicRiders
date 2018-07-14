using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Menus.Enums
{
    /// <summary>
    /// Defines the mode to enter the next race in, such as Time Trial, GP, Emerald Race etc.
    /// This is read upon starting a stage and initially set on entering
    /// the track selection menu - thus is part of the <see cref="TitleScreen"/> 
    /// structure.
    /// </summary>
    public enum TrackSelectMode : byte
    {
        Default = 0,
        TimeTrial = 1,
        GrandPrix = 2,
        EmeraldRace = 3,
        BattleMode = 4,
        MissionMode = 5,
        TagMode = 6,

        /// <summary>
        /// Launches the game demos, your track selection does not affect
        /// the demo launched.
        /// </summary>
        DemoMode = 7,

        /// <summary>
        /// Boots you back to the title screen.
        /// </summary>
        TitleScreen = 8
    }
}
