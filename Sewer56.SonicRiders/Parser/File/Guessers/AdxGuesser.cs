using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Readers;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class AdxGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public AdxGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "ADX";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        using var bigEndianReader = new BigEndianStreamReader(data);
        var pos = bigEndianReader.Position();
            
        // Magic Header
        if (bigEndianReader.Read<ushort>() != 0x8000)
            return false;

        // Copyright offset
        var copyrightOffset = bigEndianReader.Read<ushort>();
        bigEndianReader.Seek(pos + copyrightOffset, SeekOrigin.Begin);

        return bigEndianReader.Read<int>() == 0x29435249; // )CRI
    }
}
#nullable disable