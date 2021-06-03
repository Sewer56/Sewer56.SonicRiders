using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Parser.TrickSprite.Formatter
{
    public class CSharpFormatter : ITrickSpriteFormatter
    {
        /// <inheritdoc />
        public string Format(List<TrickChar> characters)
        {
            var builder = new StringBuilder();
            for (int x = 0; x < characters.Count; x++)
                builder.Append($"0x{characters[x].CharIndex:X2},0x{characters[x].PaddingAfterChar:X2}, ");

            builder.Remove(builder.Length - 2, 2);
            return $"new byte[] {{ {builder} }}";
        }
    }
}
