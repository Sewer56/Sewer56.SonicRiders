using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Utility
{
    public static class Bitfields
    {
        /// <summary>
        /// Gets an individual value for an integer bitfield.
        /// </summary>
        /// <param name="rawValue">The value from which to extract.</param>
        /// <param name="offsetBits">Offset to the first bit of the value to extract.</param>
        /// <param name="numBits">Number of bits used by the value.</param>
        public static int GetValue(this ref int rawValue, int offsetBits, int numBits)
        {
            // Get mask, shift value and mask out.
            var mask   = GetMask(numBits);
            var offset = rawValue >> offsetBits;
            return offset & mask;
        }

        /// <summary>
        /// Sets an individual value for an integer bitfield.
        /// </summary>
        /// <param name="rawValue">The value to modify.</param>
        /// <param name="newValue">The new value to insert at the offset.</param>
        /// <param name="offsetBits">Offset to the first bit of the value to extract.</param>
        /// <param name="numBits">Number of bits used by the value.</param>
        /// <returns>Copy of the new value.</returns>
        public static int SetValue(this ref int rawValue, int newValue, int offsetBits, int numBits)
        {
            // Get masked value.
            var mask   = GetMask(numBits);

            // Remove current value.
            rawValue &= (mask << offsetBits);

            // Inject new value.
            var masked = newValue & mask;
            return rawValue |= (masked << offsetBits);
        }

        /// <summary>
        /// Gets a bitmask (all 1s) from a specified number of bits.
        /// </summary>
        public static int GetMask(int numBits)
        {
            return (1 << numBits) - 1;
        }
    }
}
