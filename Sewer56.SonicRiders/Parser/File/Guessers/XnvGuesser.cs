using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class XnvGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public XnvGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "NN-XNV";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        if (data.Peek<int>() != 0x4649584E) // 'NXIF'
            return false;

        data.Seek(32, SeekOrigin.Current);

        // TODO: Texture library comes first???
        return data.Peek<uint>() == 0x414D584E; // 'NXMA' 
    }
}
#nullable disable