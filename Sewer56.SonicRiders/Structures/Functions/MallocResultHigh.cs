using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewer56.SonicRiders.Structures.Functions
{
    /// <summary>
    /// Wrapper around the result of a malloc/free performed on the game's native heap.
    /// </summary>
    public unsafe struct MallocResultHigh
    {
        /// <summary>
        /// Gets the heap header containing object info associated with this Malloc result.
        /// </summary>
        /// <param name="self">Address of this <see cref="MallocResult"/> instance.</param>
        public MemoryHeapHeader* GetHeader(MallocResultHigh* self) => MemoryHeapHeader.FromMalloc(self);
    }
}
