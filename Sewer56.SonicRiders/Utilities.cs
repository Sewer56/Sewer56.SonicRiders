using System;
using System.ComponentModel;
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
    }
}
