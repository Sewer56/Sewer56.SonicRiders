using Reloaded.Memory.Pointers;

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

    }
}
