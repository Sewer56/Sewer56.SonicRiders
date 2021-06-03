namespace Sewer56.SonicRiders.Parser.TrickSprite
{
    /// <summary>
    /// Represents an individual trick character.
    /// </summary>
    public struct TrickChar 
    {
        /// <summary>
        /// Character index. Encoded as a = 0, b = 1 etc.
        /// </summary>
        public byte CharIndex;

        /// <summary>
        /// Padding to add after the character.
        /// </summary>
        public sbyte PaddingAfterChar;
    }
}