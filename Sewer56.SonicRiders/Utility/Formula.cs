using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Gameplay;
using ExtremeGear = Sewer56.SonicRiders.Structures.Gameplay.ExtremeGear;
using Player = Sewer56.SonicRiders.API.Player;

namespace Sewer56.SonicRiders.Utility
{
    /// <summary>
    /// Contains various methods to calculate
    /// </summary>
    public static unsafe class Formula
    {
        private const float SpeedToSpeedometerRatio = 216.0f;

        /// <summary>
        /// Calculates the speed of an individual extreme gear for a specific formation.
        /// </summary>
        /// <param name="extremeGear">The extreme gear for which to calculate the gear speed for.</param>
        /// <param name="formationType">The type of the character to calculate the gear speed for.</param>
        /// <param name="characterLevel">The current level of the character from 0-2.</param>
        /// <param name="rawSpeed">Raw speed in game units.</param>
        /// <returns>Speed in UI/HUD units.</returns>
        public static float GetGearSpeed(ExtremeGear* extremeGear, FormationTypes formationType, int characterLevel, out float rawSpeed)
        {
            var typeStats      = &Player.TypeStats.Pointer[(int)formationType];
            var typeLevelStats = CharacterTypeStats.GetLevelStats(typeStats, characterLevel);

            var speedMultiplier = (1 + extremeGear->SpeedHandlingMultiplier);
            var totalSpeed      = typeLevelStats->AdditiveSpeed + extremeGear->AdditiveSpeed;

            rawSpeed = totalSpeed * speedMultiplier;

            // Apply Speed Multiplier
            return SpeedToSpeedometerRatio * rawSpeed;
        }

        /// <summary>
        /// Converts a speed in float to its value in-game on the speedometer.
        /// </summary>
        /// <param name="speed">The speed to convert to speedometer.</param>
        public static float SpeedToSpeedometer(float speed) => speed * SpeedToSpeedometerRatio;

        /// <summary>
        /// Converts a speed in speedometer to its true float value.
        /// </summary>
        /// <param name="speed">The speed to convert to float.</param>
        public static float SpeedometerToFloat(float speed) => speed / SpeedToSpeedometerRatio;
    }
}
