using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;
using System.Linq;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class ObjectLayoutGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public ObjectLayoutGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());
    
    public string GetId() => "RIDERS-OBJLAYOUT";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        data.Read<short>(out var objectCount);
        data.Read<ushort>(out var magic);

        if (magic != 0x8000)
            return false;

        // Check size after header minus last section.
        return data.Read<int>() == (objectCount * 46) + 8;
    }
}
#nullable disable