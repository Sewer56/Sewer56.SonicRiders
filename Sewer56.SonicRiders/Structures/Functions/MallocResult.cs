using Sewer56.SonicRiders.API;

namespace Sewer56.SonicRiders.Structures.Functions
{
    /// <summary>
    /// Wrapper around the result of a malloc/free performed on the game's native heap.
    /// </summary>
    public unsafe struct MallocResult
    {
        /// <summary>
        /// Gets the heap header containing object info associated with this Malloc result.
        /// </summary>
        /// <param name="self">Address of this <see cref="MallocResult"/> instance.</param>
        public MemoryHeapHeader* GetHeader(MallocResult* self) => MemoryHeapHeader.FromMalloc(self);
    }
}