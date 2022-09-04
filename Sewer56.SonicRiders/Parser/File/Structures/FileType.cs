using System;

namespace Sewer56.SonicRiders.Parser.File.Structures;

#nullable enable
public class FileType
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public string Id { get; set; } = "";
    
    /// <summary>
    /// Official file extension.
    /// </summary>
    public string? Extension;

    /// <summary>
    /// Custom user defined extension by the community for formats without one.
    /// </summary>
    public string? CustomExtension { get; set; } = null;

    /// <summary>
    /// Short name for the format.
    /// </summary>
    public string Format { get; set; } = "";

    /// <summary>
    /// Category for the format e.g. Audio
    /// </summary>
    public string Category { get; set; } = "";

    /// <summary>
    /// Tools that can be used to edit the format.
    /// </summary>
    public Tool[] Tools { get; set; } = Array.Empty<Tool>();

    /// <summary>
    /// Documentation that can be used to study the format.
    /// </summary>
    public Documentation[] Documentation { get; set; } = Array.Empty<Documentation>();
    
    /// <summary>
    /// Description of the format.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// An example file for this format.
    /// </summary>
    public string Example { get; set; } = "";

    /// <summary>
    /// Returns either an extension of a custom designated extension.
    /// </summary>
    public string? GetExtensionOrCustomExtension()
    {
        if (!string.IsNullOrEmpty(Extension))
            return Extension;

        return CustomExtension;
    }
}

/// <summary>
/// Describes a tool that can be used to edit format in question.
/// </summary>
public class Tool
{
    /// <summary>
    /// Name of the tool.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Description of the tool.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// URL for the tool.
    /// </summary>
    public string Url { get; set; } = "";

    /// <summary>
    /// Author of the tool
    /// </summary>
    public string Author { get; set; } = "";

    public Tool(string name, string url, string author, string description)
    {
        Name = name;
        Url = url;
        Author = author;
        Description = description;
    }

    public Tool() { }
}

/// <summary>
/// Describes a piece of documentation that can be used to study the format.
/// </summary>
public class Documentation 
{
    /// <summary>
    /// Name of the piece of documentation.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Link to the piece of documentation.
    /// </summary>
    public string Url { get; set; } = "";

    /// <summary>
    /// People responsible for the documentation.
    /// </summary>
    public string Authors { get; set; } = "";

    public Documentation(string name, string url, string authors)
    {
        Name = name;
        Url = url;
        Authors = authors;
    }

    public Documentation()
    {
    }
}
#nullable disable