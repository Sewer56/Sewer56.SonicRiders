namespace Sewer56.SonicRiders.Structures.Misc
{
    public struct ColorABGR
    {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Alpha;

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
    }
}