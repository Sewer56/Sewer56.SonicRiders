using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Sequential, Size = 0x20)]
    public struct RunningPhysics
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        public float Field_00;

        /// <summary>
        /// [Note: Temp variable name]
        /// When high, letting go of inputs causes instant stop.
        /// Getting hit, doing tricks, item collects etc. 
        /// resets speed to max.
        /// </summary>
        public float Inertia;

        /// <summary>
        /// The acceleration applied when walking backwards without air.
        /// Backwards speed is limited by another variable.
        /// </summary>
        public float BackwardsWalkAccel;

        /// <summary>
        /// Acceleration applied when the player runs at above ~40 speed
        /// and holds down to stop, performing slide animation.
        /// </summary>
        public float SlidingBreakAccel;

        /// <summary>
        /// Unknown
        /// </summary>
        public float Field_10;

        /// <summary>
        /// Lowest value your speed can be (only updated when 
        /// inputting or speed hits 0).
        /// </summary>
        public float MinimumSpeed;

        /// <summary>
        /// Unknown
        /// </summary>
        public float Field_18;

        /// <summary>
        /// Unknown
        /// </summary>
        public float Field_1C;
    }
}
