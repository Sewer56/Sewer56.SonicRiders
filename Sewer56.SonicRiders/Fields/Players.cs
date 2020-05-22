using System;
using System.Collections.Generic;
using System.Text;
using Sewer56.SonicRiders.Structures.Gameplay;
using Sewer56.SonicRiders.Structures.Input;

namespace Sewer56.SonicRiders.Fields
{
    /// <summary>
    /// The players class allows you to take control of the individual
    /// players ingame.
    /// </summary>
    public static unsafe class Players
    {
        /// <summary>
        /// Contains an instance of the individual player structure.
        /// To access the individual players, use an array index 0 through 7.
        /// e.g. Player[1] returns 2nd player, Player[3] fourth player.
        /// </summary>
        public static readonly Player* Player = (Player*)0x006A4B80;

        /// <summary>
        /// Pointer to the statically stored player inputs.
        /// Can be indexed from 0 to 7. i.e PlayerInputs[7] is max.
        /// </summary>
        public static readonly PlayerInput* PlayerInputs = (PlayerInput*) 0x017E4580;

        /// <summary>
        /// Contains the individual statistics/properties Speed, Flight and Power characters.
        /// </summary>
        public static readonly CharacterTypeStats* CharacterTypeStats = (CharacterTypeStats*)0x005BD4D8;
    }
}
