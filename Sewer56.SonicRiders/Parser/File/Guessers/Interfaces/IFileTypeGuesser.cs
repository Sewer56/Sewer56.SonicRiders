using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;

#nullable enable
public interface IFileTypeGuesser
{
    /// <summary>
    /// Retrieves an ID corresponding to those in KnownFileTypes.json
    /// </summary>
    string GetId();

    /// <summary>
    /// Returns the known file type for this guesser.
    /// </summary>
    FileType? GetFileType();

    /// <summary>
    /// Tries to guess the type of file.
    /// </summary>
    /// <param name="data">Stream to read file data.</param>
    /// <param name="fileSize">File size, if known, else -1.</param>
    bool TryGuess(BufferedStreamReader data, int fileSize);
}
#nullable disable