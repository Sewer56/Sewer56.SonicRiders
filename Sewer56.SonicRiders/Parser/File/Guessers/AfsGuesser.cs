using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;
using System.Linq;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class AfsGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public AfsGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "AFS";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        return data.Read<int>() == 0x534641; // 'AFS'
    }
}
#nullable disable