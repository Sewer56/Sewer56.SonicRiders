using System;
using System.Collections.Generic;
using System.Text;
using Sewer56.SonicRiders.Fields;
using Sewer56.SonicRiders.Structures.Enums;
using ExtremeGear = Sewer56.SonicRiders.Structures.Gameplay.ExtremeGear;

namespace Sewer56.SonicRiders.Mathematics
{
    /// <summary>
    /// Contains various methods to calculate
    /// </summary>
    public static unsafe class Formula
    {
        /// <summary>
        /// Calculates the speed of an individual extreme gear for a specific formation.
        /// </summary>
        /// <param name="extremeGear">The extreme gear for which to calculate the gear speed for.</param>
        /// <param name="formationType">The type of the character to calculate the gear speed for.</param>
        public static float GetGearSpeed(ExtremeGear* extremeGear, FormationTypes formationType)
        {
            float characterTypeSpeedMultiplier = Players.CharacterTypeStats[(int)formationType].MaxSpeedMultiplier;
            float speed = 216 * (characterTypeSpeedMultiplier + extremeGear->SpeedHandlingMultiplier);

            // Apply Speed Multiplier
            return speed * (extremeGear->SpeedMultiplier + 1);
        }
    }
}
