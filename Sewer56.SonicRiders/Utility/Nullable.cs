namespace Sewer56.SonicRiders.Utility;

#nullable enable
public static class NullableExtensions
{
    /// <summary>
    /// Assigns a string if it's not null or empty.
    /// </summary>
    public static void AssignIfNotNullOrEmpty(ref string value, string? newValue)
    {
        if (!string.IsNullOrEmpty(newValue))
            value = newValue;
    }
}
#nullable disable