using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Sewer56.SonicRiders.Internal.DirectX;
using Sewer56.SonicRiders.Structures.Tasks.Base;
using static Sewer56.SonicRiders.Functions.Functions;
using DX9Hook = Sewer56.SonicRiders.Internal.DirectX.DX9Hook;

namespace Sewer56.SonicRiders.API
{
    public static unsafe class Event
    {
        private static IHook<ReturnVoidFn>        _endFrameHook;
        private static IHook<DX9Hook.EndScene> _endSceneHook;
        private static IHook<SetTaskFnPtr>     _setTaskFnPtr;
        private static IHook<KillTaskFnPtr>    _killTaskFnPtr;
        private static IHook<CdeclReturnIntFnPtr> _killAllTasksFnPtr;

        /// <summary>
        /// Executed on sleeping and rendering the frame.
        /// </summary>
        public static event Action OnSleep
        {
            add
            {
                _endFrameHook ??= EndFrame.Hook(SleepAndRender).Activate();
                _onSleep += value;
            }
            remove => _onSleep -= value;
        }

        /// <summary>
        /// Executed after sleeping and rendering the frame.
        /// </summary>
        public static event Action AfterSleep
        {
            add
            {
                _endFrameHook ??= EndFrame.Hook(SleepAndRender).Activate();
                _afterSleep += value;
            }
            remove => _afterSleep -= value;
        }

        /// <summary>
        /// Executed right before rendering a frame using DirectX.
        /// </summary>
        public static event Action OnEndScene
        {
            add
            {
                _endSceneHook ??= Misc.DX9Hook.Value.DeviceVTable.CreateFunctionHook<DX9Hook.EndScene>((int)IDirect3DDevice9.EndScene, EndSceneHook).Activate();
                _onEndScene += value;
            }
            remove => _onEndScene -= value;
        }

        /// <summary>
        /// Executed right after rendering a frame using DirectX.
        /// </summary>
        public static event Action AfterEndScene
        {
            add
            {
                _endSceneHook ??= Misc.DX9Hook.Value.DeviceVTable.CreateFunctionHook<DX9Hook.EndScene>((int)IDirect3DDevice9.EndScene, EndSceneHook).Activate();
                _afterEndScene += value;
            }
            remove => _afterEndScene -= value;
        }

        /// <summary>
        /// Executed before a new task is to be set.
        /// </summary>
        public static event SetTaskFn OnSetTask
        {
            add
            {
                _setTaskFnPtr ??= SetTask.HookAs<SetTaskFnPtr>(typeof(Event), nameof(SetTaskFnHook)).Activate();
                _onSetTask += value;
            }
            remove => _onSetTask -= value;
        }

        /// <summary>
        /// Executed after a new task is set.
        /// </summary>
        public static event SetTaskFn AfterSetTask
        {
            add
            {
                _setTaskFnPtr ??= SetTask.HookAs<SetTaskFnPtr>(typeof(Event), nameof(SetTaskFnHook)).Activate();
                _afterSetTask += value;
            }
            remove => _afterSetTask -= value;
        }

        /// <summary>
        /// Executed before a task is about to be killed.
        /// </summary>
        public static event KillTaskFn OnKillTask
        {
            add
            {
                _killTaskFnPtr ??= KillTask.HookAs<KillTaskFnPtr>(typeof(Event), nameof(KillTaskFnHook)).Activate();
                _onKillTask += value;
            }
            remove => _onKillTask -= value;
        }

        /// <summary>
        /// Executed after a task is about to be killed.
        /// </summary>
        public static event KillTaskFn AfterKillTask
        {
            add
            {
                _killTaskFnPtr ??= KillTask.HookAs<KillTaskFnPtr>(typeof(Event), nameof(KillTaskFnHook)).Activate();
                _afterKillTask += value;
            }
            remove => _afterKillTask -= value;
        }

        /// <summary>
        /// Executed before a task is about to be killed.
        /// </summary>
        public static event Action OnKillAllTasks
        {
            add
            {
                _killAllTasksFnPtr ??= RemoveAllTasks.HookAs<CdeclReturnIntFnPtr>(typeof(Event), nameof(KillAllTasksFnHook)).Activate();
                _onKillAllTasks += value;
            }
            remove => _onKillAllTasks -= value;
        }

        /// <summary>
        /// Executed before a task is about to be killed.
        /// </summary>
        public static event Action AfterKillAllTasks
        {
            add
            {
                _killAllTasksFnPtr ??= RemoveAllTasks.HookAs<CdeclReturnIntFnPtr>(typeof(Event), nameof(KillAllTasksFnHook)).Activate();
                _afterKillAllTasks += value;
            }
            remove => _afterKillAllTasks -= value;
        }

        /* Private Events */  
        private static event Action _onSleep;
        private static event Action _afterSleep;
        private static event Action _onEndScene;
        private static event Action _afterEndScene;
        private static event SetTaskFn _onSetTask;
        private static event SetTaskFn _afterSetTask;
        private static event KillTaskFn _onKillTask;
        private static event KillTaskFn _afterKillTask;
        private static event Action _onKillAllTasks;
        private static event Action _afterKillAllTasks;

        /* Hooks */

        /* Hook Bodies */
        private static void SleepAndRender()
        {
            _onSleep?.Invoke();
            _endFrameHook.OriginalFunction();
            _afterSleep?.Invoke();
        }

        private static IntPtr EndSceneHook(IntPtr device)
        {
            _onEndScene?.Invoke();
            var result = _endSceneHook.OriginalFunction(device);
            _afterEndScene?.Invoke();
            return result;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static unsafe Task* SetTaskFnHook(void* methodPtr, uint maybeMaxTaskHeapSize, int heapType)
        {
            _onSetTask?.Invoke(methodPtr, maybeMaxTaskHeapSize, heapType);
            var result = _setTaskFnPtr.OriginalFunction.Value.Invoke((IntPtr) methodPtr, maybeMaxTaskHeapSize, heapType);
            _afterSetTask?.Invoke(methodPtr, maybeMaxTaskHeapSize, heapType);
            return result.Pointer;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static unsafe Task* KillTaskFnHook()
        {
            _onKillTask?.Invoke();
            var result = _killTaskFnPtr.OriginalFunction.Value.Invoke();
            _afterKillTask?.Invoke();
            return result.Pointer;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static unsafe int KillAllTasksFnHook()
        {
            _onKillAllTasks?.Invoke();
            var result = _killAllTasksFnPtr.OriginalFunction.Value.Invoke();
            _afterKillAllTasks?.Invoke();
            return result;
        }

        /// <summary>
        /// See <see cref="Functions.Functions.SetTaskFn"/>
        /// </summary>
        public unsafe delegate void SetTaskFn(void* methodPtr, uint maybeMaxTaskHeapSize, int taskDataSize);

        /// <summary>
        /// See <see cref="Functions.Functions.KillTaskFn"/>
        /// </summary>
        public unsafe delegate void KillTaskFn();
    }
}
