namespace Sewer56.SonicRiders.Utility.Math
{
    /// <summary>
    /// Represents an integer vector composed of 3 elements.
    /// </summary>
    public struct Vector3Short
    {
        public short X;
        public short Y;
        public short Z;

        public Vector3Short(short x, short y, short z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3Short Add(Vector3Short other) => new Vector3Short((short) (X + other.X), (short) (Y + other.Y), (short) (Z + other.Z));
        public Vector3Short Subtract(Vector3Short other) => new Vector3Short((short) (X - other.X), (short) (Y - other.Y), (short) (Z - other.Z));
        public Vector3Short Multiply(Vector3Short other) => new Vector3Short((short) (X * other.X), (short) (Y * other.Y), (short) (Z * other.Z));
        public Vector3Short Divide(Vector3Short other) => new Vector3Short((short) (X / other.X), (short) (Y / other.Y), (short) (Z / other.Z));
    }
}