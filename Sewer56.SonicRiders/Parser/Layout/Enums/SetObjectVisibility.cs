using System;

namespace Sewer56.SonicRiders.Parser.Layout.Enums
{
    [Flags]
    public enum SetObjectVisibility : int
    {
        GameCube = 1 << 0,
        PlayStation = 1 << 1,

        /// <summary>
        /// And PC
        /// </summary>
        Xbox = 1 << 2,

        Race     = 1 << 3,
        Tag      = 1 << 4,
        Survival = 1 << 5,

        Mission1 = 1 << 6,
        Mission2 = 1 << 7,
        Mission3 = 1 << 8,
        Mission4 = 1 << 9,
        Mission5 = 1 << 10,
        Mission6 = 1 << 11,
        Mission7 = 1 << 12,
    }
}