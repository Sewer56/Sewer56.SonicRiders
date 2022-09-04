using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Readers;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;
using System.Linq;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class SfdGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public SfdGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "SFD";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        // This is actually a modified MPEG container.
        // https://en.wikipedia.org/wiki/MPEG_program_stream
        using var endianStreamReader = new BigEndianStreamReader(data);
        if (endianStreamReader.Read<int>() != 0x1BA)
            return false;

        byte mpegType = endianStreamReader.Read<byte>();
        return mpegType >> 4 == 0b0010; // Check MPEG 1 variant.
    }
}
#nullable disable