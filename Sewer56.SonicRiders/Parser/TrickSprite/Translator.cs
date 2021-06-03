using System.Collections.Generic;
using Sewer56.SonicRiders.Parser.TrickSprite.Formatter;

namespace Sewer56.SonicRiders.Parser.TrickSprite
{
    /// <summary>
    /// Translates given ascii text to sprite data.
    /// </summary>
    public class Translator
    {
        /// <summary>
        /// Translates the provided text with characters a-z, SPACE to game sprite data.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="spaceBetweenCharacters">Amount of space between regular characters.</param>
        /// <param name="spaceSize">Size of the space character.</param>
        public List<TrickChar> Translate(string text, in sbyte spaceBetweenCharacters, in sbyte spaceSize)
        {
            var characters = new List<TrickChar>(text.Length);
            for (int x = 0; x < text.Length; x++)
            {
                char currentChar = text[x];
                char nextChar    = GetCharOrDefault(text, x + 1);

                if (!IsValidLetter(currentChar)) 
                    continue;

                characters.Add(new TrickChar()
                {
                    CharIndex = (byte) CharToIndex(currentChar),
                    PaddingAfterChar = (sbyte) (nextChar == ' ' ? spaceSize : spaceBetweenCharacters)
                });
            }

            // Terminator
            characters.Add(new TrickChar() { CharIndex = 255 });
            return characters;
        }

        /// <summary>
        /// Translates the provided text with characters a-z, SPACE to game sprite data.
        /// Returns a string in a specified format.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="spaceBetweenCharacters">Amount of space between regular characters.</param>
        /// <param name="spaceSize">Size of the space character.</param>
        public string Translate(string text, in sbyte spaceBetweenCharacters, in sbyte spaceSize, ITrickSpriteFormatter formatter)
        {
            return formatter.Format(Translate(text, spaceBetweenCharacters, spaceSize));
        }

        /// <summary>
        /// Gets a character if in range or NULL character.
        /// </summary>
        private char GetCharOrDefault(string text, int index) => index < text.Length ? text[index] : '\0';

        /// <summary>
        /// True if the letter can be represented in trick text.
        /// </summary>
        private bool IsValidLetter(char letter) => letter >= 'a' && letter <= 'z';

        /// <summary>
        /// Converts a character to an index stored in game code.
        /// </summary>
        /// <param name="character">The character to convert.</param>
        private int CharToIndex(char character) => character - 'a';
    }
}
