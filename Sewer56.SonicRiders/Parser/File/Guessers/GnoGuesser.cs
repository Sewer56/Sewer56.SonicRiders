using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class GnoGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    // Added for convenience of people doing model work while PC Riders is worked on.
    public GnoGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "NN-GNO";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        if (data.Peek<int>() != 0x4649474E) // 'NGIF'
            return false;

        data.Seek(32, SeekOrigin.Current);

        var ngtlOrNxob = data.Peek<uint>();
        return ngtlOrNxob is 0x4C54474E or 0x424F474E; // 'NGTL' or 'NGOB' 
    }
}
#nullable disable