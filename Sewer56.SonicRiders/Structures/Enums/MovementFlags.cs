using System;

namespace Sewer56.SonicRiders.Structures.Enums
{
    /// <summary>
    /// Various movement flags while on board. Affect current character state.
    /// </summary>
    [Flags]
    public enum MovementFlags : int
    {
        Left            = 0x00000001,
        Right           = 0x00000002,
        Down            = 0x00000004,
        Up              = 0x00000008,
        Braking         = 0x00000100,
        Boosting        = 0x00000400,
        ChargingJump    = 0x00001000,
        BoostingAirLoss = 0x00002000,
        Drifting        = 0x00004000,
        Tornado         = 0x00008000,
        AttachToRail    = 0x00010000,
        TornadoRelated  = 0x00200000,
    }
}