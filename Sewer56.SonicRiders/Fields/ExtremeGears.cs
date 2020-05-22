using System;
using System.Collections.Generic;
using System.Text;
using Sewer56.SonicRiders.Structures.Gameplay;

namespace Sewer56.SonicRiders.Fields
{
    /// <summary>
    /// Provides a list of all of the extreme gears used in the game.
    /// </summary>
    public static unsafe class ExtremeGears
    {
        /// <summary>
        /// Allows you to access the information of any particular extreme gear.
        /// In order to access an individual gear, access this variable like an array, with
        /// <see cref="Sewer56.SonicRiders.Structures.Enums.ExtremeGear"/> as an indexer.
        /// </summary>
        public static readonly ExtremeGear* ExtremeGear = (ExtremeGear*)0x6575B0;
    }
}
