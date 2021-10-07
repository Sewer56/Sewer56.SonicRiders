using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reloaded.Memory.Streams;

namespace Sewer56.SonicRiders.Parser.Archive
{
    public static class ArchiveGuesser
    {
        public static bool TryGuess(Stream stream, int streamLength)
        {
            var data = new BufferedStreamReader(stream, 4096);
            var pos  = stream.Position;

            try
            {
                var initialPos = data.Position();

                // Total Groups
                data.Read(out int binCount);

                // Safeguard against unlikely big files.
                if (binCount is > short.MaxValue or < 1)
                    return false;

                // Total Items
                Span<byte> groups = stackalloc byte[binCount];
                for (int x = 0; x < binCount; x++)
                    groups[x] = data.Read<byte>();

                // Alignment
                data.Seek(Utilities.RoundUp((int)data.Position(), 4) - data.Position(), SeekOrigin.Current);

                // Now compare against total running file count.
                int currentCount = 0;
                int expectedCount = 0;

                for (int x = 0; x < binCount; x++)
                {
                    expectedCount = data.Read<short>();
                    if (currentCount != expectedCount)
                        return false;

                    currentCount += groups[x];
                }

                // Skip group ids.
                data.Seek(sizeof(short) * binCount, SeekOrigin.Current);

                // Check offsets.
                var firstFileOffset = data.Peek<int>();

                if (streamLength != -1 && firstFileOffset > streamLength)
                    return false;

                // Seek to expected first file position.
                data.Seek(sizeof(int) * currentCount, SeekOrigin.Current);
                data.Seek(Utilities.RoundUp((int)data.Position(), 16), SeekOrigin.Begin); // Alignment

                // Try checking if first file is past expected header size, or empty 0.
                var currentOffset = data.Position() - initialPos;
                return firstFileOffset == 0 || firstFileOffset >= (currentOffset);
            }
            finally
            {
                stream.Position = pos;
            }
        }

    }
}
