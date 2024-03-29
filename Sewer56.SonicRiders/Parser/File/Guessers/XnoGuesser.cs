﻿using System.IO;
using System.Linq;
using Reloaded.Memory.Streams;
using Sewer56.SonicRiders.Parser.File.Guessers.Interfaces;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File.Guessers;

#nullable enable
public class XnoGuesser : IFileTypeGuesser
{
    private FileType? _fileType;

    public XnoGuesser() => _fileType = KnownFileTypes.Types.FirstOrDefault(x => x.Id == GetId());

    public string GetId() => "NN-XNO";
    public FileType? GetFileType() => _fileType;

    public bool TryGuess(BufferedStreamReader data, int streamLength)
    {
        if (data.Peek<int>() != 0x4649584E) // 'NXIF'
            return false;

        data.Seek(32, SeekOrigin.Current);

        var nxtlOrNxob = data.Peek<uint>();
        return nxtlOrNxob is 0x4C54584E or 0x424F584E; // 'NXTL' 
    }
}
#nullable disable