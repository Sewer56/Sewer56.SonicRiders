namespace Sewer56.SonicRiders.Utility
{
    /// <summary>
    /// Utility class for defining individual bitfields for extracting information from packed values.
    /// </summary>
    public struct BitField
    {
        /// <summary>
        /// The generated mask.
        /// </summary>
        public int Mask;

        /// <summary>
        /// Offset of the first bit.
        /// </summary>
        public int OffsetBits;

        /// <summary>
        /// Number of bits used.
        /// </summary>
        public int NumBits;

        /// <summary>
        /// Maximum value representable by the number of bits given.
        /// </summary>
        public int MaxValue => (int) (1 << NumBits) - 1;

        /// <summary>
        /// Generates a bitfield given a number of bits.
        /// </summary>
        /// <param name="numBits">Number of bits used by the value.</param>
        public BitField(int numBits)
        {
            Mask = Bitfields.GetMask(numBits);
            OffsetBits = 0;
            NumBits = numBits;
        }

        /// <summary>
        /// Generates a bitfield given a number of bits and an offset to the first bit.
        /// </summary>
        /// <param name="offset">Offset of the first bit of the value.</param>
        /// <param name="numBits">Number of bits used by the value.</param>
        public BitField(int offset, int numBits)
        {
            Mask = Bitfields.GetMask(numBits);
            OffsetBits = offset;
            NumBits = numBits;
        }

        /// <summary>
        /// Gets an individual value for an integer bitfield.
        /// </summary>
        /// <param name="rawValue">The value from which to extract.</param>
        public readonly int GetValue(int rawValue)
        {
            // Get mask, shift value and mask out.
            var offset = rawValue >> OffsetBits;
            return offset & Mask;
        }

        /// <summary>
        /// Sets an individual value for an integer bitfield.
        /// </summary>
        /// <param name="rawValue">The value to modify.</param>
        /// <param name="newValue">The new value to insert at the offset.</param>
        /// <returns>Copy of the new value.</returns>
        public readonly int SetValue(ref int rawValue, int newValue)
        {
            // Remove current value.
            rawValue &= (Mask << OffsetBits);

            // Inject new value.
            var masked = newValue & Mask;
            return rawValue |= (masked << OffsetBits);
        }
    }
}
