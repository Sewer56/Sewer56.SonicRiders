using System;
using System.Runtime.CompilerServices;
using Reloaded.Memory.Pointers;
using Reloaded.Memory.Streams.Readers;
using Reloaded.Memory.Streams.Writers;
using Sewer56.SonicRiders.Structures.Misc;

namespace Sewer56.SonicRiders.Utility
{
    public static class Extensions
    {
        /// <summary>
        /// Copies items from a RefFixedArrayPtr to a managed array.
        /// </summary>
        public static T[] ToArray<T>(this RefFixedArrayPtr<T> items) where T : unmanaged
        {
            var result = new T[items.Count];
            items.CopyTo(result, result.Length);
            return result;
        }

        /// <summary>
        /// Reads a colour from a managed memory stream.
        /// </summary>
        /// <param name="reader">Reader used for reading the stream.</param>
        /// <param name="color">The read colour value.</param>
        public static void Read(this EndianStreamReader reader, out ColorABGR color)
        {
            color = new ColorABGR();
            color.Alpha = reader.Read<byte>();
            color.Blue  = reader.Read<byte>();
            color.Green = reader.Read<byte>();
            color.Red   = reader.Read<byte>();
        }

        /// <summary>
        /// Writes a colour to a managed memory stream.
        /// </summary>
        /// <param name="writer">Writer used for writing the stream.</param>
        /// <param name="color">Colour to write.</param>
        public static void Write(this EndianMemoryStream writer, ColorABGR color)
        {
            writer.Write(color.Alpha);
            writer.Write(color.Blue);
            writer.Write(color.Green);
            writer.Write(color.Red);
        }

        /// <summary>
        /// Reads a given number of bytes from a stream.
        /// </summary>
        /// <param name="stream">The stream to read the value from.</param>
        /// <param name="result">The buffer to receive the bytes.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryReadSafe(this System.IO.Stream stream, Span<byte> result)
        {
            int numBytesRead = 0;
            int numBytesToRead = result.Length;

            do
            {
                int bytesRead = stream.Read(result.Slice(numBytesRead));
                if (bytesRead <= 0)
                    return false;

                numBytesRead += bytesRead;
                numBytesToRead -= bytesRead;
            }
            while (numBytesRead < numBytesToRead);

            return true;
        }
    }
}
