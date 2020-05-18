using System;

namespace Sewer56.SonicRiders.Structures.Input.Enums
{
    [Flags]
    public enum Buttons : int
    {
        Null        = 0x0,
        Accept      = 0x1,
        Decline     = 0x2,
        DPadUp      = 0x10,
        DPadDown    = 0x20,
        DPadLeft    = 0x40,
        DPadRight   = 0x80,
        Start       = 0x100,
        LeftDrift   = 0x200,
        RightDrift  = 0x400,
        Up          = 0x1000,
        Down        = 0x2000,
        Left        = 0x4000,
        Right       = 0x8000
    };
}
