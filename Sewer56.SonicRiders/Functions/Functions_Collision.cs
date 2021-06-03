using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Structs;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory.Pointers;

namespace Sewer56.SonicRiders.Functions
{
    public static unsafe partial class Functions
    {
        /// <summary>
        /// Reset the collision data pointers.
        /// </summary>
        public static readonly IFunction<AllocateCollisionHeapFn> ResetCollisionHeap = SDK.ReloadedHooks.CreateFunction<AllocateCollisionHeapFn>(0x004408D0);

        /// <summary>
        /// Allocates the collision data on the heap.
        /// Note: You need to deallocate manually using <see cref="Functions.Free"/>, else it's a memory leak.
        /// </summary>
        public static readonly IFunction<AllocateCollisionHeapFn> AllocateCollisionHeap = SDK.ReloadedHooks.CreateFunction<AllocateCollisionHeapFn>(0x00441950);

        /// <summary>
        /// Allocates the native collision heap.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public delegate void* AllocateCollisionHeapFn();

        [Function(CallingConventions.Cdecl)] 
        public struct AllocateCollisionHeapFnPtr { public FuncPtr<BlittablePointer<byte>> Value; }
    }
}