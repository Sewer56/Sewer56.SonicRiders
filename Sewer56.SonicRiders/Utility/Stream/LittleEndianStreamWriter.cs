using System;
using Reloaded.Memory.Streams;

namespace Sewer56.SonicRiders.Utility.Stream
{
    public struct LittleEndianStreamWriter : IEndianStreamWriter
    {
        public System.IO.Stream Stream { get; private set; }

        public LittleEndianStreamWriter(System.IO.Stream stream)
        {
            Stream = stream;
        }

        /// <inheritdoc />
        public void Write<T>(T[] structure) where T : unmanaged => Stream.Write(structure);

        /// <inheritdoc />
        public void Write<T>(T structure) where T : unmanaged => Stream.Write(ref structure);

        /// <inheritdoc />
        public void Write(Span<byte> data) => Stream.Write(data);
    }
}