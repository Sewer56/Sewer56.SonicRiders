using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;
using Sewer56.SonicRiders.Utility;
using System.IO;
using System;

namespace Sewer56.SonicRiders.Parser.File;

#nullable enable
/// <summary>
/// Utility for guessing file types.
/// </summary>
public static class FileTypeGuesser
{
    public static readonly IFileTypeGuesser[] Guessers = ReflectionHelpers.MakeAllInstances<IFileTypeGuesser>();

    /// <summary>
    /// Tries to guess the file type of a file.
    /// Does not advance the stream.
    /// </summary>
    /// <param name="data">Stream containing the data.</param>
    /// <param name="fileType">Type of the file, if guess is successful.</param>
    /// <remarks>Does not advance the stream.</remarks>
    public static bool TryGuess(byte[] data, out FileType? fileType)
    {
        using var stream = new MemoryStream(data);
        return TryGuess(stream, data.Length, out fileType);
    }

    /// <summary>
    /// Tries to guess the file type of a file.
    /// Does not advance the stream.
    /// </summary>
    /// <param name="data">Stream containing the data.</param>
    /// <param name="streamLength">Length of the stream.</param>
    /// <param name="fileType">Type of the file, if guess is successful.</param>
    /// <returns></returns>
    /// <remarks>Does not advance the stream.</remarks>
    public static bool TryGuess(Stream data, int streamLength, out FileType? fileType)
    {
        var pos = data.Position;
        using var extendedStream = new BufferedStreamReader(data, 2048);
        var extendedStreamPos = extendedStream.Position();

        foreach (var guesser in Guessers)
        {
            extendedStream.Seek(extendedStreamPos, SeekOrigin.Begin);

            try
            {
                if (!guesser.TryGuess(extendedStream, streamLength)) 
                    continue;

                fileType = guesser.GetFileType();
                data.Position = pos;
                return true;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        fileType = new FileType() { Id = "UNK", Format = "Unknown" };
        data.Position = pos;
        return false;
    }
}
#nullable disable