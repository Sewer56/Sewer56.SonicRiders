namespace Sewer56.SonicRiders.Structures.Gameplay
{
    public struct TurbulenceProperties
    {
        /// <summary>
        /// Speed given from a landed trick.
        /// </summary>
        public float TrickSpeed;

        /// <summary>
        /// Deceleration applied if above max speed.
        /// </summary>
        public float SpeedLossAboveMaxSpeed; 

        /// <summary>
        /// Minimum speed.
        /// </summary>
        public float MinSpeed; 

        /// <summary>
        /// Amount of speed given to player if below min speed.
        /// </summary>
        public float SpeedGainBelowMinSpeed; 

        /// <summary>
        /// Amount of speed gained when going from the edge to the center of the turbulence. Noticeable on turns.
        /// </summary>
        public float AccelOnCurve;

        /// <summary>
        /// According to the values in the prototype this is supposed to be the max speed but I can't find
        /// this value used anywhere in code. It's typically set to 5/10 below the other maxSpeed value.
        /// </summary>
        public float ApparentlyMaxSpeed;

        /// <summary>
        /// Maximum speed on turbulence.
        /// </summary>
        public float MaxSpeed;
    }

    public enum TurbulenceType
    {
        NoTrick,
        TrickOne,
        TrickTwo,
        TrickThree,
        TrickRainbowTopPath,
    }
}