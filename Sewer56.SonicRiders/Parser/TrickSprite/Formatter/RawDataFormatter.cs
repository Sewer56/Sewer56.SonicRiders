using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Parser.TrickSprite.Formatter
{
    public class RawDataFormatter : ITrickSpriteFormatter
    {
        /// <inheritdoc />
        public string Format(List<TrickChar> characters)
        {
            var builder = new StringBuilder();
            for (int x = 0; x < characters.Count; x++)
                builder.Append($"{characters[x].CharIndex:X2} {characters[x].PaddingAfterChar:X2} ");

            return builder.ToString();
        }
    }
}
