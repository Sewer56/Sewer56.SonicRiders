using System.IO;
using System.Runtime.CompilerServices;
using Reloaded.Memory.Streams;
using Reloaded.Memory.Streams.Readers;
using Sewer56.BitStream.Interfaces;

namespace Sewer56.SonicRiders.Parser.Archive.Helpers
{
    public struct BufferedStreamReaderByteStream : IByteStream
    {
        public BufferedStreamReader Reader { get; private set; }
        public BufferedStreamReaderByteStream(BufferedStreamReader reader) => Reader = reader;

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        public byte Read(int index)
        {
            if (Reader.Position() != index)
                Reader.Seek(index, SeekOrigin.Begin);

            return Reader.Peek<byte>();
        }

        /// <inheritdoc />
        public void Write(byte value, int index) => throw new System.NotImplementedException();
    }
}
