using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class PvrTexLibraryGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public PvrTexLibraryGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "PVR-XVRS";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        var initialPos = data.Position();

        // Check file count.
        data.Read<short>(out var numTextures);
        if (numTextures < 1)
            return false;

        // Check optional section flag.
        data.Read<short>(out var hasOptionalSection);
        if (hasOptionalSection is not (0 or 256))
            return false;

        // Check if offsets are sequential.
        for (int x = 0; x < numTextures; x++)
        {
            // Get next offset.
            data.Read<int>(out var offset);
            var nextOffset = data.Position();

            // Seek to texture header.
            data.Seek(initialPos + offset, SeekOrigin.Begin);
            if (data.Peek<int>() != 0x58494247) // 'GBIX'
                return false;

            data.Seek(nextOffset, SeekOrigin.Begin);
        }

        return true;
    }
}
#nullable disable