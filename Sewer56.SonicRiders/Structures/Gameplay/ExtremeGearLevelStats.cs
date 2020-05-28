using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    /// <summary>
    /// Defines the statistics for a board at a perticular level.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 0x1C)]
    public struct ExtremeGearLevelStats
    {
        public int MaxAir;

        /// <summary>
        /// Counted per frame.
        /// </summary>
        public int PassiveAirDrain;

        /// <summary>
        /// Counted per frame.
        /// </summary>
        public int DriftAirCost;

        public int BoostCost;
        public int TornadoCost;
        public float SpeedGainedFromDriftDash;
        public float BoostSpeed;
    }
}
