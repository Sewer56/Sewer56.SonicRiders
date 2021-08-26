using System;
using System.IO;
using System.Runtime.CompilerServices;
using Reloaded.Memory;
using Reloaded.Memory.Streams;

namespace Sewer56.SonicRiders.Utility.Stream
{
    /// <summary>
    /// Writes to a stream using big endian.
    /// </summary>
    public struct BigEndianStreamWriter : IEndianStreamWriter
    {
        public System.IO.Stream Stream { get; private set; }

        public BigEndianStreamWriter(System.IO.Stream stream)
        {
            Stream = stream;
        }

        /// <inheritdoc />
        public void Write<T>(T[] structure) where T : unmanaged => Stream.WriteBigEndianPrimitive(structure);

        /// <inheritdoc />
        public void Write<T>(T structure) where T : unmanaged => Stream.WriteBigEndianPrimitive(structure);

        /// <inheritdoc />
        public void Write(Span<byte> data) => Stream.Write(data);
    }
}