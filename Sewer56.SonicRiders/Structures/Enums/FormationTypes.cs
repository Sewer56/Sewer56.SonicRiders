using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum FormationTypes
    {
        Speed,
        Fly,
        Power
    }

    [Flags]
    public enum FormationTypesFlags
    {
        Speed = 0x1,
        Fly = 0x2,
        Power = 0x4
    }
}
