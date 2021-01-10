using System;
using Reloaded.Hooks.Definitions;
using Sewer56.SonicRiders.Internal.DirectX;
using static Sewer56.SonicRiders.Functions.Functions;
using DX9Hook = Sewer56.SonicRiders.Internal.DirectX.DX9Hook;

namespace Sewer56.SonicRiders.API
{
    public static class Event
    {
        private static IHook<DefaultFn> _endFrameHook = EndFrame.Hook(SleepAndRender).Activate();
        private static IHook<DX9Hook.EndScene> _endSceneHook;

        static Event()
        {
            _endSceneHook = Misc.DX9Hook.Value.DeviceVTable.CreateFunctionHook<DX9Hook.EndScene>((int) IDirect3DDevice9.EndScene, EndSceneHook).Activate();
        }

        /// <summary>
        /// Executed on sleeping and rendering the frame..
        /// </summary>
        public static event Action OnSleep;

        /// <summary>
        /// Executed after sleeping and rendering the frame.
        /// </summary>
        public static event Action AfterSleep;

        /// <summary>
        /// Executed right before rendering a frame using DirectX.
        /// </summary>
        public static event Action OnEndScene;

        /// <summary>
        /// Executed right after rendering a frame using DirectX.
        /// </summary>
        public static event Action AfterEndScene;

        /* Hooks */

        /* Hook Bodies */
        private static void SleepAndRender()
        {
            OnSleep?.Invoke();
            _endFrameHook.OriginalFunction();
            AfterSleep?.Invoke();
        }

        private static IntPtr EndSceneHook(IntPtr device)
        {
            OnEndScene?.Invoke();
            var result = _endSceneHook.OriginalFunction(device);
            AfterEndScene?.Invoke();
            return result;
        }
    }
}
