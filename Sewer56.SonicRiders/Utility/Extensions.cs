using Reloaded.Memory.Pointers;
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
        /// Writes a colour to a managed memory stream.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="color"></param>
        public static void Write(this EndianMemoryStream writer, ColorABGR color)
        {
            writer.Write(color.Alpha);
            writer.Write(color.Blue);
            writer.Write(color.Green);
            writer.Write(color.Red);
        }
    }
}
