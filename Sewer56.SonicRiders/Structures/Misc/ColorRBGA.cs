using System;

namespace Sewer56.SonicRiders.Structures.Misc
{
    public struct ColorRGBA
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;

        public static implicit operator System.Drawing.Color(ColorRGBA color) => System.Drawing.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
        public static implicit operator ColorRGBA(System.Drawing.Color color) => new ColorRGBA()
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

        public bool Equals(ColorRGBA other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha;
        }

        public override bool Equals(object obj)
        {
            return obj is ColorRGBA other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Red, Green, Blue, Alpha);
        }
    }
}