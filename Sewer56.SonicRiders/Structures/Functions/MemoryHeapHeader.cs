using System.Runtime.InteropServices;
using Sewer56.SonicRiders.API;

namespace Sewer56.SonicRiders.Structures.Functions
{
    /// <summary>
    /// The individual heap header associated with every memory heap allocation made at the front of the heap.
    /// </summary>
    public unsafe struct MemoryHeapHeader
    {
        /// <summary>
        /// Shifts the result of a malloc operation to obtain this header.
        /// </summary>
        /// <param name="ptr">The pointer.</param>
        public static MemoryHeapHeader* FromMalloc(void* ptr)
        {
            return (MemoryHeapHeader*) ((byte*) ptr - sizeof(MemoryHeapHeader));
        }

        /// <summary>
        /// Returns true if this is the first entry of the front of the buffer.
        /// </summary>
        public bool IsLastEntry(MemoryHeapHeader* address) => address == *Heap.FrameHeadFront;

        /// <summary>
        /// Gets the next item.
        /// </summary>
        public MemoryHeapHeader* GetNextItem() => (MemoryHeapHeader*)((byte*)Base + AllocationSize);
        
        /// <summary>
        /// The base address of this individual memory allocation.
        /// This is where the heap head was made before allocation and alignment were made.
        /// </summary>
        public MallocResult* Base;
        
        /// <summary>
        /// Size of the individual allocation, including the <see cref="MemoryHeapHeader"/> itself.
        /// </summary>
        public int AllocationSize;
    }
}
