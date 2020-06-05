using System;

namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum FormationTypes : int
    {
        Speed,
        Fly,
        Power
    }

    [Flags]
    public enum FormationTypesFlags : int
    {
        Speed = 0x1,
        Fly = 0x2,
        Power = 0x4
    }
}
