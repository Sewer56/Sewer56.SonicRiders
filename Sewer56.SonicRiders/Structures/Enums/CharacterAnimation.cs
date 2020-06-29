namespace Sewer56.SonicRiders.Structures.Enums
{
    /// <summary>
    /// Listing of individual character animations.
    /// </summary>
    public enum CharacterAnimation : int
    {
        /// <summary>
        /// Not moving, in gear mode.
        /// </summary>
        Stationary = 0,

        /// <summary>
        /// Cruising slowly, up to ~aaaaaaaaaa150.
        /// </summary>
        SlowCruising = 1,

        /// <summary>
        /// Cruising fast, after ~150.
        /// </summary>
        FastCruising = 2,

        TurningLeft = 3,
        TurningRight = 5,

        RisingDigitalDimension = 7,

        Jump = 10,
        FallOffLedge = 11,
        AirBlowingFan = 12,
        AboutToLandFromRamp = 13,
        Land = 14,
        NormalLandFromJump = 15,
        DyingOrGettingHit = 16,
        TrickFailed = 17,
        JumpCharging = 20,

        KickDash = 21,
        Tornado = 25,
        Pulley = 26,


        GrindingAlternative = 27,
        Grinding = 28,
        FlyTypeFlying = 29,
        PowerTypePunching = 32,
        PowerTypePunchingCombo = 33,

        AttackAnimation = 35,
        SonicLevel2Attack = 38,

        AttackByTornado = 40,
        AttackByCharacter = 41,
        AttackByUlalaLv2 = 44,
        AttackByUlalaLv2Stun = 45,

        /// <summary>
        /// SS/X Rank Tricks
        /// </summary>
        TrickCelebration = 55,
        
        /// <summary>
        /// Ranks below SS
        /// </summary>
        CheapTrickCelebration = 56,

        RaceEndAnimation = 62,
        RecoverFromHit = 64,
        DriftBoost = 65,

        /// <summary>
        /// Standing before the race begins.
        /// </summary>
        Standing = 66,

        /// <summary>
        /// Running up to the race starting line. Ends at around 100 speed.
        /// </summary>
        RunningForwardSlow = 67,

        /// <summary>
        /// Running fast up to the race starting line. Speed threshold around 100.
        /// </summary>
        RunningForwardFast = 68,

        /// <summary>
        /// Used when walking backwards in run mode.
        /// </summary>
        WalkingBackwards = 69,
        
        /// <summary>
        /// Performs a roll and lands on the board.
        /// </summary>
        LandOnBoard360 = 70,

        /// <summary>
        /// Sliding while in run mode.
        /// </summary>
        Sliding = 72,

        /// <summary>
        /// Seems to contain all tricks.
        /// </summary>
        Tricks = 73,

        /// <summary>
        /// Getting shocked by the laser.
        /// </summary>
        Shocked = 74,


        GeneralCustomAttack1Start = 75,
        GeneralCustomAttack1Loop = 76,

        GeneralCustomAttack2Start = 77,
        GeneralCustomAttack2Loop = 78,

        GeneralCustomAttack3Start = 79,
        GeneralCustomAttack3Loop = 80,

        /// <summary>
        /// Thawing out after getting shocked.
        /// </summary>
        AfterShock = 81,

    }
}