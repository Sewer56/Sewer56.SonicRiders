namespace Sewer56.SonicRiders.Utility.Math
{
    /// <summary>
    /// Represents an integer vector composed of 3 elements.
    /// </summary>
    public struct Vector3Int
    {
        public int X;
        public int Y;
        public int Z;

        public Vector3Int(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3Int Add(Vector3Int other) => new Vector3Int(X + other.X, Y + other.Y, Z + other.Z);
        public Vector3Int Subtract(Vector3Int other) => new Vector3Int(X - other.X, Y - other.Y, Z -other.Z);
        public Vector3Int Multiply(Vector3Int other) => new Vector3Int(X * other.X, Y * other.Y, Z * other.Z);
        public Vector3Int Divide(Vector3Int other) => new Vector3Int(X / other.X, Y / other.Y, Z / other.Z);
    }
}