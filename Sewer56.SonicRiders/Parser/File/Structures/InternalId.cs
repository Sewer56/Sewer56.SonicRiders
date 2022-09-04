namespace Sewer56.SonicRiders.Parser.File.Structures;

/// <summary>
/// Describes an internal ID/Group of objects found within a Riders archive.
/// </summary>
public class InternalId
{
    /// <summary>
    /// Unique ID of the group.
    /// </summary>
    public ushort Id { get; set; }

    /// <summary>
    /// Name of the group.
    /// </summary>
    public string Name { get; set; }

    public InternalId() { }

    public InternalId(ushort id, string name)
    {
        Id = id;
        Name = name;
    }
}