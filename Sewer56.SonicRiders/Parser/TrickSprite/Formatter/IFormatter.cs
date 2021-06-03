using System.Collections.Generic;

namespace Sewer56.SonicRiders.Parser.TrickSprite.Formatter
{
    public interface ITrickSpriteFormatter
    {
        /// <summary>
        /// Formats the output and returns the formatted result.
        /// </summary>
        /// <param name="characters">The characters to format.</param>
        public string Format(List<TrickChar> characters);
    }
}