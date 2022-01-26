using System;

namespace Sewer56.SonicRiders.Structures.Misc
{
    public struct ColorABGR
    {
        public byte Alpha;
        public byte Blue;
        public byte Green;
        public byte Red;

        public static implicit operator System.Drawing.Color(ColorABGR color) => System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
        public static implicit operator ColorABGR(System.Drawing.Color color) => new ColorABGR()
        {
            Alpha = color.A,
            Blue = color.B,
            Green = color.G,
            Red = color.R
        };

        public override string ToString()
        {
            return $"ABGR {Alpha}-{Blue}-{Green}-{Red}";
        }

        public bool Equals(ColorABGR other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha;
        }

        public override bool Equals(object obj)
        {
            return obj is ColorABGR other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Red, Green, Blue, Alpha);
        }
    }
}