namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum PlayerState : byte
    {
        None = 0,

        /// <summary>
        /// The running state that is applied at the start of a race.
        /// </summary>
        Running = 1,

        /// <summary>
        /// Resets the player as if they were to fall out of map, go the wrong way, etc.
        /// </summary>
        Reset = 3,

        /// <summary>
        /// Brings up the Retire Screen as if the current mission were to be failed by the player.
        /// </summary>
        Retire = 4,

        /// <summary>
        /// Normally driving forward on extreme gear/skates/bike.
        /// </summary>
        NormalOnBoard = 5,

        /// <summary>
        /// Triggers a character jump.
        /// </summary>
        Jump = 6,

        /// <summary>
        /// Applied when the player falls off a cliff/ledge without jumping.
        /// </summary>
        FreeFalling = 7,

        /// <summary>
        /// Doing Tricks (Horizontal Ramp) e.g. First Jump Metal City
        /// </summary>
        TrickJumpHorizontal = 8,

        /// <summary>
        /// Doing Tricks (Vertical Ramp) e.g. First Jump Ice Factory
        /// </summary>
        TrickJumpVertical = 9,

        TrickJumpUnknown1 = 10,
        TrickJumpUnknown2 = 11,

        /// <summary>
        /// Doing Tricks (Flat Vertical Ramp) (e.g. Ice Factory 2nd Jump), first jump after
        /// Metal City's first turn.
        /// </summary>
        TrickJumpFlatVertical = 12,

        /// <summary>
        /// Doing Tricks (Turbulence) e.g. Turbulence
        /// </summary>
        TrickJumpTurbulence = 13,

        /// <summary>
        /// Turbulence
        /// </summary>
        Turbulence = 16,

        /// <summary>
        /// Inside an Auto/Rotate Stick Section (or arrows on PC version).
        /// (Setting manually = crash, needs rail set somewhere first)
        /// </summary>
        RotateSection = 17,

        /// <summary>
        /// Grinding (Setting manually = crash, needs rail set somewhere first)
        /// </summary>
        Grinding = 18,

        /// <summary>
        /// Flying (Flight Formation).
        /// </summary>
        Flying = 19,

        /// <summary>
        /// Attacking an enemy/rival.
        /// (Setting manually = crash, needs enemy set somewhere first)
        /// </summary>
        Attacking = 21,

        /// <summary>
        /// Getting attacked by an enemy/rival.
        /// (Setting manually = crash, needs enemy set somewhere first)
        /// </summary>
        GettingAttacked = 22,

        /// <summary>
        /// Running state after the player crosses the start line.
        /// </summary>
        RunningAfterStart = 25,

        /// <summary>
        /// Triggers the electric shock encountered if the player passes the start
        /// line too early.
        /// </summary>
        ElectricShock = 26,

        /// <summary>
        /// Purpose unknown, brings player to a halt.
        /// </summary>
        InstantStop = 27,

        /// <summary>
        /// ElectricShock but longer.
        /// </summary>
        ElectricShockLong = 28,

        /// <summary>
        /// Some variant of ElectricShock which crashes the game.
        /// </summary>
        ElectricShockCrash = 29,
    }
}
