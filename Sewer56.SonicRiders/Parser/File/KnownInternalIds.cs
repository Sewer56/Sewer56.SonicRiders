using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File;

/// <summary>
/// List of known groups inside Riders archives.
/// </summary>
public static class KnownInternalIds
{
    /// <summary>
    /// Riders archive groups.
    /// </summary>
    public static readonly InternalId[] Ids =
    {
        new (1005, "Stage Title Texture")
    };
}