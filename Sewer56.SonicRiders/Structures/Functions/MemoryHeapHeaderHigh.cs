using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewer56.SonicRiders.Structures.Functions
{
    /// <summary>
    /// The individual heap header associated with every memory heap allocation made at the back of the heap.
    /// </summary>
    public unsafe struct MemoryHeapHeaderHigh
    {
        /// <summary>
        /// Shifts the result of a malloc operation to obtain this header.
        /// </summary>
        /// <param name="ptr">The pointer.</param>
        public static MemoryHeapHeaderHigh* FromMalloc(void* ptr)
        {
            return (MemoryHeapHeaderHigh*)((byte*)ptr - sizeof(MemoryHeapHeaderHigh));
        }

        /// <summary>
        /// Pointer to the last item on the back side.
        /// </summary>
        public MemoryHeapHeaderHigh* LastItem;

        /// <summary>
        /// Pointer to the next item on the back side.
        /// </summary>
        public MemoryHeapHeaderHigh* NextItem;
        
        /// <summary>
        /// The size of the buffer after this header.
        /// In practice, this is the size of the allocation previous to this one.
        /// </summary>
        public int BufferSize;

        /// <summary>
        /// Gets the size of this memory allocation by calculating offset between next header
        /// and this header; provided the next item ptr is not null.
        /// </summary>
        /// <param name="thisPtr">Pointer to the next item.</param>
        public int GetSize(MemoryHeapHeaderHigh* thisPtr)
        {
            if (NextItem == (void*)0)
                return 0;

            return (int)((uint) thisPtr - (uint) NextItem);
        }

        /// <summary>
        /// Gets the size of this memory allocation from the next header; where the size of 
        /// this allocation should be stored.
        /// </summary>
        /// <param name="thisPtr">Pointer to the next item.</param>
        public int GetSizeFromNextHeader(MemoryHeapHeaderHigh* thisPtr)
        {
            if (NextItem == (void*)0)
                return 0;

            return NextItem->BufferSize;
        }
    }
}
