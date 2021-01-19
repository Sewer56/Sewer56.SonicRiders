using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Structures.Enums;
using ExtremeGear = Sewer56.SonicRiders.Structures.Gameplay.ExtremeGear;

namespace Sewer56.SonicRiders.Utility
{
    /// <summary>
    /// Contains various methods to calculate
    /// </summary>
    public static unsafe class Formula
    {
        private const float speedToSpeedometerRatio = 216.0f;

        /// <summary>
        /// Calculates the speed of an individual extreme gear for a specific formation.
        /// </summary>
        /// <param name="extremeGear">The extreme gear for which to calculate the gear speed for.</param>
        /// <param name="formationType">The type of the character to calculate the gear speed for.</param>
        public static float GetGearSpeed(ExtremeGear* extremeGear, FormationTypes formationType)
        {
            float characterTypeSpeedMultiplier = Player.TypeStats[(int)formationType].MaxSpeedMultiplier;
            float speed = speedToSpeedometerRatio * (characterTypeSpeedMultiplier + extremeGear->AdditiveSpeed);

            // Apply Speed Multiplier
            return speed * (extremeGear->SpeedHandlingMultiplier + 1);
        }

        /// <summary>
        /// Converts a speed in float to its value in-game on the speedometer.
        /// </summary>
        /// <param name="speed">The speed to convert to speedometer.</param>
        public static float SpeedToSpeedometer(float speed) => speed * speedToSpeedometerRatio;

        /// <summary>
        /// Converts a speed in speedometer to its true float value.
        /// </summary>
        /// <param name="speed">The speed to convert to float.</param>
        public static float SpeedometerToFloat(float speed) => speed / speedToSpeedometerRatio;
    }
}
