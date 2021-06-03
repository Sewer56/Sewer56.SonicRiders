using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Structs;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory.Pointers;
using Task = Sewer56.SonicRiders.Structures.Tasks.Base.Task;

namespace Sewer56.SonicRiders.Functions
{
    public static unsafe partial class Functions
    {
        /// <summary>
        /// Sets up the pointers for the game's native heap.
        /// </summary>
        public static IFunction<InitHeapFn> InitHeap = SDK.ReloadedHooks.CreateFunction<InitHeapFn>(0x00527840);

        /// <summary>
        /// Frees an object from the game's native heap.
        /// </summary>
        public static IFunction<FreeFn> Free = SDK.ReloadedHooks.CreateFunction<FreeFn>(0x00527890);

        /// <summary>
        /// Sets the header of the game's native heap to a new location.
        /// </summary>
        public static IFunction<FreeFn> FreeFrame = SDK.ReloadedHooks.CreateFunction<FreeFn>(0x005278B0);

        /// <summary>
        /// Frees a memory region allocated with <see cref="MallocHigh"/> or <see cref="CallocHigh"/>.
        /// </summary>
        public static IFunction<FreeFn> FreeHigh = SDK.ReloadedHooks.CreateFunction<FreeFn>(0x005278E0);

        /// <summary>
        /// Frees all memory allocated with <see cref="MallocHigh"/> or <see cref="CallocHigh"/>.
        /// </summary>
        public static IFunction<CdeclReturnIntFn> FreeAllHigh = SDK.ReloadedHooks.CreateFunction<CdeclReturnIntFn>(0x00527950);

        /// <summary>
        /// Allocates memory in the game's managed heap.
        /// </summary>
        public static IFunction<AllocFn> Malloc = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x005279B0);

        /// <summary>
        /// Allocates an object on the game's managed heap. (Zeroes memory)
        /// </summary>
        public static IFunction<AllocFn> Calloc = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x00527A00);

        /// <summary>
        /// Allocates memory from the end of the game's managed heap.
        /// </summary>
        public static IFunction<AllocFn> MallocHigh = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x00527A70);

        /// <summary>
        /// Allocates an object from the end of the game's managed heap. (Zeroes memory)
        /// </summary>
        public static IFunction<AllocFn> CallocHigh = SDK.ReloadedHooks.CreateFunction<AllocFn>(0x00527B50);

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
