using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class XnmGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public XnmGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "NN-XNM";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        if (data.Peek<int>() != 0x4649584E) // 'NXIF'
            return false;

        data.Seek(32, SeekOrigin.Current);
        return data.Peek<uint>() == 0x4F4D584E; // 'NXMO'
    }
}
#nullable disable