using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Task = Sewer56.SonicRiders.Structures.Tasks.Base.Task;

namespace Sewer56.SonicRiders.Structures.Tasks.Managed
{
    /// <summary>
    /// A base class that creates a task handled by the game's native task handler.
    /// Creating an instance of this class will cause the function (set in <see cref="Function"/>) to
    /// be executed on every frame.
    /// </summary>
    public abstract unsafe class ManagedTask
    {

        /// <summary>
        /// The function the game code executes.
        /// </summary>
        public Action Function { get; private set; }

        /// <summary>
        /// Pointer to the native task created by the game's Task Allocator.
        /// </summary>
        public Task* NativeTask { get; private set; }
        
        /// <summary>
        /// See class details for more info.
        /// </summary>
        /// <param name="function">The function to be executed every frame.</param>
        /// <param name="nativeTaskGroupId">It's currently unknown what this does. Believed to be a group id to put related tasks close to each other.</param>
        /// <param name="taskDataSize">
        ///     If value is 0, task data has a size of 0 bytes.
        ///     If value is 1, task data has a size of 30 bytes.
        ///     If value is 2, task data has a size of 126 bytes.
        /// </param>
        protected ManagedTask(Action function, int nativeTaskGroupId = 0, int taskDataSize = 0) => Construct(function, nativeTaskGroupId, taskDataSize);
        protected ManagedTask() { }

        /// <summary>
        /// See constructor for documentation.
        /// </summary>
        protected void Construct(Action function, int nativeTaskGroupId = 0, int taskDataSize = 0)
        {
            Function = function;
            var ptr = Marshal.GetFunctionPointerForDelegate(Function);
            NativeTask = SonicRiders.Functions.Functions.SetTask.GetWrapper()((void*) ptr, (uint) nativeTaskGroupId, taskDataSize);
        }

        /// <summary>
        /// Removes this task from the game's native task heap.
        /// </summary>
        public void Kill() => SonicRiders.Functions.Functions.KillTask.GetWrapper()();
    }
}
