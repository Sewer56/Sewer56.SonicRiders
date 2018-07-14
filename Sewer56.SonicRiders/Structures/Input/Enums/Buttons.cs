using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Input.Enums
{
    [Flags]
    public enum Buttons : int
    {
        Accept =  0x00000001,
        Decline = 0x00000002,
        LBumper = 0x00000200,
        RBumper = 0x00000400,
        Up =      0x00001010,
        Down =    0x00002020,
        Left =    0x00004040,
        Right =   0x00008080
    }
}
