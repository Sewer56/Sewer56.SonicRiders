using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Misc
{
    [StructLayout(LayoutKind.Sequential, Size = 12)]
    public struct Vector
    {
        public float X;
        public float Y;
        public float Z;
    }
}
