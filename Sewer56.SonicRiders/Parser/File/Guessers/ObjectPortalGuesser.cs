using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class ObjectPortalGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public ObjectPortalGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "RIDERS-OBJPORTAL";

    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        // Read header.
        data.Read<byte>(out var numPortals);
        data.Read<byte>(out var magic);

        if (magic != 0x80)
            return false;

        // Min-max portal ASCII chars.
        data.Read<byte>(out var minPortal);
        data.Read<byte>(out var maxPortal);

        data.Seek(4, SeekOrigin.Current);
        for (int x = 0; x < numPortals; x++)
        {
            var portal = data.Read<Portal.Structs.Portal>();
            var min = portal.Minimum;
            var max = portal.Maximum;

            // Bounds checks, minimum should always be smaller than max.
            if (min.X > max.X || min.Y > max.Y || min.Z > max.Z)
                return false;

            // Check for valid portal.
            if (portal.PortalChar > maxPortal || portal.PortalChar < minPortal)
                return false;
        }

        return true;
    }
}
#nullable disable