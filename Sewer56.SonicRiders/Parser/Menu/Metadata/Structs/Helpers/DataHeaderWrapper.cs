namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs.Helpers
{
    /// <summary>
    /// Wraps the contents of <see cref="Type2DataHeader"/> and <see cref="Type3DataHeader"/> for easy use.
    /// </summary>
    public unsafe struct DataHeaderWrapper
    {
        public const int InvalidDataType = -1;

        /// <summary>
        /// Denotes the data type used to store.
        /// This is <see cref="InvalidDataType"/> if the type is unknown.
        /// </summary>
        public short DataType;

        /// <summary>
        /// Denotes the number of bytes used to store this information.
        /// </summary>
        public short NumBytes;

        /// <summary>
        /// Pointer to the data in question.
        /// </summary>
        public byte* DataPtr;
    }
}
