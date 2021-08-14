using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Structs;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.Structures.Functions;

namespace Sewer56.SonicRiders.API
{
    /// <summary>
    /// Contains variables and functions related to game's internal task heap.
    /// This class is complete. All functions, all variables present, to best of my knowledge.
    /// </summary>
    public static unsafe class Heap
    {
        /// <summary>
        /// Contains the remaining amount of free space in the buffer.
        /// </summary>
        public static int* RemainingSize = (int*) 0x017B8DA0;

        /// <summary>
        /// Contains the amount of bytes that were used in the buffer.
        /// </summary>
        public static int* UsedSizeBack = (int*) 0x017B8DA4;

        /// <summary>
        /// Pointer to the start of the heap.
        /// </summary>
        public static int* StartPtr = (int*)0x017B8658;

        /// <summary>
        /// Pointer to the end of the heap.
        /// </summary>
        public static int* EndPtr = (int*)0x017B8D80;

        /// <summary>
        /// Contains a pointer to the start of the heap.
        /// </summary>
        public static MemoryHeapHeader* FirstHeaderFront = (MemoryHeapHeader*)0x017B8DAC;

        /// <summary>
        /// Contains a pointer to header at the back of the heap.
        /// </summary>
        public static MemoryHeapHeader* FirstHeaderBack = (MemoryHeapHeader*)0x017B8DB4;

        /// <summary>
        /// Contains the pointer to the "head" of the buffer. (from the front)
        /// That is, the first byte in the buffer that is free to use/unused.
        /// Memory between <see cref="FrameHeadFront"/> and <see cref="FrameHeadBack"/> is free to allocate.
        /// </summary>
        public static MemoryHeapHeader* FrameHeadFront = (MemoryHeapHeader*)0x017B8DA8;

        /// <summary>
        /// Contains the pointer to the "head" of the buffer. (from the back)
        /// That is, the first byte in the buffer that is free to use/unused.
        /// Memory between <see cref="FrameHeadFront"/> and <see cref="FrameHeadBack"/> is free to allocate.
        /// </summary>
        public static MemoryHeapHeader* FrameHeadBack = (MemoryHeapHeader*)0x017B8DB0;

        /// <summary>
        /// Sets up the pointers for the game's native heap.
        /// </summary>
        public static readonly IFunction<InitHeapFn> InitHeap = SDK.ReloadedHooks.CreateFunction<InitHeapFn>(0x00527840);

        /// <summary>
        /// Frees an object from the game's native heap.
        /// </summary>
        public static readonly IFunction<FreeFn> Free = SDK.ReloadedHooks.CreateFunction<FreeFn>(0x00527890);

        /// <summary>
        /// Sets the header of the game's native heap to a new location.
        /// </summary>
        public static readonly IFunction<FreeFn> FreeFrame = SDK.ReloadedHooks.CreateFunction<FreeFn>(0x005278B0);

        /// <summary>
        /// Frees a memory region allocated with <see cref="MallocHigh"/> or <see cref="CallocHigh"/>.
        /// </summary>
        public static readonly IFunction<FreeFn> FreeHigh = SDK.ReloadedHooks.CreateFunction<FreeFn>(0x005278E0);

        /// <summary>
        /// Frees all memory allocated with <see cref="MallocHigh"/> or <see cref="CallocHigh"/>.
        /// </summary>
        public static readonly IFunction<Functions.Functions.CdeclReturnIntFn> FreeAllHigh = SDK.ReloadedHooks.CreateFunction<Functions.Functions.CdeclReturnIntFn>(0x00527950);

        /// <summary>
        /// Allocates memory in the game's managed heap.
        /// </summary>
        public static readonly IFunction<AllocFn> Malloc = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x005279B0);

        /// <summary>
        /// Allocates an object on the game's managed heap. (Zeroes memory)
        /// </summary>
        public static readonly IFunction<AllocFn> Calloc = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x00527A00);

        /// <summary>
        /// Allocates memory from the end of the game's managed heap.
        /// </summary>
        public static readonly IFunction<AllocFn> MallocHigh = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x00527A70);

        /// <summary>
        /// Allocates an object from the end of the game's managed heap. (Zeroes memory)
        /// </summary>
        public static readonly IFunction<AllocFn> CallocHigh = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x00527B50);

        /// <summary>
        /// Calculates the total used heap size.
        /// </summary>
        public static int GetUsedSize() => GetHeapSize() - *RemainingSize;

        /// <summary>
        /// Calculates the total heap size.
        /// </summary>
        public static int GetHeapSize() => (*EndPtr - *StartPtr);

        /// <summary>
        /// Allocates memory on the game's native heap.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate void* AllocFn(int alignment, int size);

        [Function(CallingConventions.Cdecl)]
        public struct AllocFnPtr { public FuncPtr<int, int, BlittablePointer<byte>> Value; }

        /// <summary>
        /// Frees an memory from the game's native heap.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate int FreeFn(void* address);

        [Function(CallingConventions.Cdecl)]
        public struct FreeFnPtr { public FuncPtr<BlittablePointer<byte>, BlittablePointer<byte>> Value; }

        /// <summary>
        /// Sets up the pointers for the game's native heap.
        /// </summary>
        /// <param name="bufferAddress">Beginning of game heap.</param>
        /// <param name="endOfBufferAddress">End of game heap.</param>
        [Function(CallingConventions.Cdecl)]
        public delegate int InitHeapFn(void* bufferAddress, void* endOfBufferAddress);

        [Function(CallingConventions.Cdecl)]
        public struct InitHeapFnPtr { public FuncPtr<BlittablePointer<byte>, BlittablePointer<byte>, int> Value; }
    }
}
