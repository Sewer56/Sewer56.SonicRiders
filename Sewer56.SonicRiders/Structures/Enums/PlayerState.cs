namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum PlayerState : byte
    {
        /// <summary>
        /// The running state that is applied at the start of a race.
        /// </summary>
        Running = 0x01,

        /// <summary>
        /// Resets the player as if they were to fall out of map, go the wrong way, etc.
        /// </summary>
        Reset = 0x03,

        /// <summary>
        /// Brings up the Retire Screen as if the current mission were to be failed by the player.
        /// </summary>
        Retire = 0x04,

        /// <summary>
        /// Normally driving forward on extreme gear/skates/bike.
        /// </summary>
        NormalOnBoard = 0x05,

        /// <summary>
        /// Triggers a character jump.
        /// </summary>
        Jump = 0x06,

        /// <summary>
        /// Applied when the player falls off a cliff/ledge without jumping.
        /// </summary>
        FreeFalling = 0x07,

        /// <summary>
        /// Doing Tricks (Horizontal Ramp) e.g. First Jump Metal City
        /// </summary>
        TrickJumpHorizontal = 0x08,

        /// <summary>
        /// Doing Tricks (Vertical Ramp) e.g. First Jump Ice Factory
        /// </summary>
        TrickJumpVertical = 0x09,

        TrickJumpUnknown1 = 0x0A,
        TrickJumpUnknown2 = 0x0B,

        /// <summary>
        /// Doing Tricks (Flat Vertical Ramp) (e.g. Ice Factory 2nd Jump), first jump after
        /// Metal City's first turn.
        /// </summary>
        TrickJumpFlatVertical = 0x0C,

        /// <summary>
        /// Doing Tricks (Turbulence) e.g. Turbulence
        /// </summary>
        TrickJumpTurbulence = 0x0D,

        /// <summary>
        /// Turbulence
        /// </summary>
        Turbulence = 0x10,

        /// <summary>
        /// Inside an Auto/Rotate Stick Section (or arrows on PC version).
        /// (Setting manually = crash, needs rail set somewhere first)
        /// </summary>
        RotateSection = 0x11,

        /// <summary>
        /// Grinding (Setting manually = crash, needs rail set somewhere first)
        /// </summary>
        Grinding = 0x12,

        /// <summary>
        /// Flying (Flight Formation).
        /// </summary>
        Flying = 0x13,

        /// <summary>
        /// Attacking an enemy/rival.
        /// (Setting manually = crash, needs enemy set somewhere first)
        /// </summary>
        Attacking = 0x15,

        /// <summary>
        /// Getting attacked by an enemy/rival.
        /// (Setting manually = crash, needs enemy set somewhere first)
        /// </summary>
        GettingAttacked = 0x16,

        /// <summary>
        /// Triggers the electric shock encountered if the player passes the start
        /// line too early.
        /// </summary>
        ElectricShock = 0x1A,

        /// <summary>
        /// Purpose unknown, brings player to a halt.
        /// </summary>
        InstantStop = 0x1B,

        /// <summary>
        /// ElectricShock but longer.
        /// </summary>
        ElectricShockLong = 0x1C,

        /// <summary>
        /// Some variant of ElectricShock which crashes the game.
        /// </summary>
        ElectricShockCrash = 0x1D,
    }
}
