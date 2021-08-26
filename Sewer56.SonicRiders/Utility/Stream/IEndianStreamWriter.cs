using System;
using Reloaded.Memory;

namespace Sewer56.SonicRiders.Utility.Stream
{
    public interface IEndianStreamWriter
    {
        System.IO.Stream Stream { get; }

        /// <inheritdoc />
        void Write<T>(T[] structure) where T : unmanaged;

        /// <inheritdoc />
        void Write<T>(T structure) where T : unmanaged;

        /// <inheritdoc />
        void Write(Span<byte> data);
    }
}