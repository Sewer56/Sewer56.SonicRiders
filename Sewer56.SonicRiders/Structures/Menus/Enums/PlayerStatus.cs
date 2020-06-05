using System;

namespace Sewer56.SonicRiders.Structures.Menus.Enums
{
    [Flags]
    public enum PlayerStatus : byte
    {
        /// <summary>
        /// Player is currently inactive.
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// Player has joined the game/race.
        /// </summary>
        Active = 1,

        /// <summary>
        /// Player is currently selecting gear.
        /// </summary>
        GearSelect = 2,

        /// <summary>
        /// Player has selected both gear and character and is ready to race.
        /// </summary>
        Ready = 4
    }
}
