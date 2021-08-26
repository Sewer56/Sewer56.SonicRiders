using System;
using System.ComponentModel;
using System.Text;
using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Structures.Enums;

namespace Sewer56.SonicRiders
{
    public static class Utilities
    {
        /// <summary>
        /// Gets the name of an individual level using reflection.
        /// </summary>
        /// <param name="level">The level to get the name of.</param>
        /// <returns>Empty if unknown, else level name.</returns>
        public static string GetLevelName(Levels level)
        {
            var description = GetAttributeOfType<DescriptionAttribute>(level);
            if (description != null)
                return description.Description;

            return String.Empty;
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example><![CDATA[string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;]]></example>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        /// <summary>
        /// Rounds a number up to the next multiple unless the number is already a multiple.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="multiple">The multiple.</param>
        public static uint RoundUp(uint number, uint multiple)
        {
            if (multiple == 0)
                return number;

            uint remainder = number % multiple;
            if (remainder == 0)
                return number;

            return number + multiple - remainder;
        }

        /// <summary>
        /// Rounds a number up to the next multiple unless the number is already a multiple.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="multiple">The multiple.</param>
        public static int RoundUp(int number, int multiple)
        {
            if (multiple == 0)
                return number;

            int remainder = number % multiple;
            if (remainder == 0)
                return number;

            return number + multiple - remainder;
        }

        /// <summary>
        /// Reads a null terminated ASCII string, up to 1024 characters.
        /// </summary>
        public static string ReadString(this BufferedStreamReader reader)
        {
            Span<byte> data = stackalloc byte[1024];
            int numCharactersRead = 0;

            byte currentByte = 0;
            while ((currentByte = reader.Read<byte>()) != 0)
                data[numCharactersRead++] = currentByte;

            return Encoding.ASCII.GetString(data.Slice(0, numCharactersRead));
        }

        /// <summary>
        /// Replaces slashes with Unicode Lookalikes.
        /// </summary>
        public static string UnicodeReplaceSlash(this string text) => text.Replace('/', '∕').Replace('\\', '⧵').Replace('.', '•');

        /// <summary>
        /// Unreplaces slashes with Unicode Lookalikes.
        /// </summary>
        public static string UnicodeUnReplaceSlash(this string text) => text.Replace('∕', '/').Replace('⧵', '\\').Replace('•', '.');
    }
}
