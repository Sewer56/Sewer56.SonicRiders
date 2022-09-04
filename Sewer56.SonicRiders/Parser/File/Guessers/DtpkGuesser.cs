using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;
using System.Linq;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class DtpkGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public DtpkGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "DTPK";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        return data.Peek<int>() == 0x78626F78; // 'xbox'
    }
}
#nullable disable