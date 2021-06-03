namespace Sewer56.SonicRiders.Parser.Archive.Structs
{
    /// <summary>
    /// Represents an individual file inside a group.
    /// </summary>
    public struct File
    {
        /// <summary>
        /// The offset of the file.
        /// </summary>
        public int Offset; 

        /// <summary>
        /// The size of the file.
        /// </summary>
        public int Size;
    }
}