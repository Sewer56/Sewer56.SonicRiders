using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Parser.TrickSprite.Formatter
{
    public class GeckoFormatter : ITrickSpriteFormatter
    {
        /// <inheritdoc />
        public string Format(List<TrickChar> characters)
        {
            // Code in PPC requires 4 byte alignment.
            bool needsPadding = characters.Count % 2 != 0;

            var builder = new StringBuilder();
            for (int x = 0; x < characters.Count; x++)
            {
                builder.AppendLine($".byte 0x{characters[x].CharIndex:X2}");
                builder.AppendLine($".byte 0x{characters[x].PaddingAfterChar:X2}");
            }

            if (needsPadding)
                builder.AppendLine($".2byte 0x00");

            return 
@$"# Note: Address of text stored in r31. Change if needed.
bl text
mflr r31
lwz r31,0(r31)
b aftertext

text:
blrl
{builder.ToString()}
aftertext:
";
        }
    }
}
