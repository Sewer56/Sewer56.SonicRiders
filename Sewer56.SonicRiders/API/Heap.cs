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
        /*
         *  Some Observations:
         *
         *  ===============================================
         *  Free is ran in opposite order of Malloc.
         *  e.g.
         *
         *  Malloc 1
         *  Malloc 2
         *  Malloc 3
         *  Free 3
         *  Free 2
         *  Free 1
         *
         *  ===============================================
         *  To free multiple things at once, use FreeFrame.
         *  Malloc 1
         *  Malloc 2 
         *  Malloc 3
         *  FreeFrame 1
         *
         *  Malloc 2 and Malloc 3 are now disposed.
         *  ===============================================
         */

        /// <summary>
        /// Contains the remaining amount of free space in the buffer.
        /// </summary>
        public static int* RemainingSize = (int*) 0x017B8DA0;

        /// <summary>
        /// Contains the amount of bytes that were used in the back of the buffer.
        /// </summary>
        public static int* UsedSizeBack = (int*) 0x017B8DA4;

        /// <summary>
        /// Pointer to the start of the heap.
        /// </summary>
        public static int* StartPtr = (int*) 0x017B8658;

        /// <summary>
        /// Pointer to the end of the heap.
        /// </summary>
        public static int* EndPtr = (int*) 0x017B8D80;

        /// <summary>
        /// The address of the start of the memory region containing [<see cref="MemoryHeapHeader"/> + data] blocks (from the front).
        /// </summary>
        public static MallocResult** FirstHeaderFront = (MallocResult**)0x017B8DAC;

        /// <summary>
        /// The address of the start of the memory region containing [<see cref="MemoryHeapHeader"/> + data] blocks (from the back).
        /// </summary>
        public static MallocResult** FirstHeaderBack = (MallocResult**)0x017B8DB4;

        /// <summary>
        /// Contains the pointer to the "head" of the buffer. (from the front)
        /// That is, the first byte in the buffer that is free to use/unused and where allocation will happen when <see cref="Malloc"/> is called.
        /// Memory between <see cref="FrameHeadFront"/> and <see cref="FrameHeadBack"/> is free to allocate.
        /// </summary>
        public static MallocResult** FrameHeadFront = (MallocResult**)0x017B8DA8;

        /// <summary>
        /// Contains the pointer to the "head" of the buffer. (from the back)
        /// That is, the first byte in the buffer that is free to use/unused and where allocation will happen when <see cref="MallocHigh"/> is called.
        /// Memory between <see cref="FrameHeadFront"/> and <see cref="FrameHeadBack"/> is free to allocate.
        /// </summary>
        public static MallocResult** FrameHeadBack = (MallocResult**)0x017B8DB0;

        /// <summary>
        /// Sets up the pointers for the game's native heap.
        /// </summary>
        public static readonly IFunction<InitHeapFn> InitHeap = SDK.ReloadedHooks.CreateFunction<InitHeapFn>(0x00527840);

        /// <summary>
        /// Frees an object from the game's native heap.
        /// The passed in pointer is the location of the new header.
        /// </summary>
        public static readonly IFunction<FreeFn> Free = SDK.ReloadedHooks.CreateFunction<FreeFn>(0x00527890);

        /// <summary>
        /// Sets the header of the game's native heap to a new location.
        /// The passed in pointer is the location of the new header.
        /// Returns the new amount of free memory (i.e. <see cref="RemainingSize"/>).
        /// </summary>
        public static readonly IFunction<FreeFrameFn> FreeFrame = SDK.ReloadedHooks.CreateFunction<FreeFrameFn>(0x005278B0);

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
        public delegate MallocResult* AllocFn(int alignment, int size);

        [Function(CallingConventions.Cdecl)]
        public struct AllocFnPtr { public FuncPtr<int, int, BlittablePointer<MallocResult>> Value; }

        /// <summary>
        /// Frees an memory from the game's native heap.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate MallocResult* FreeFn(MallocResult* address);

        [Function(CallingConventions.Cdecl)]
        public struct FreeFnPtr { public FuncPtr<BlittablePointer<MallocResult>, BlittablePointer<MallocResult>> Value; }

        /// <summary>
        /// Sets a new pointer to the end of the used memory.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate int FreeFrameFn(MallocResult* address);

        [Function(CallingConventions.Cdecl)]
        public struct FreeFrameFnPtr { public FuncPtr<BlittablePointer<MallocResult>, int> Value; }

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
