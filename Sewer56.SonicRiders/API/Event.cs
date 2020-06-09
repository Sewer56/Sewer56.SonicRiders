using System;
using Reloaded.Hooks.Definitions;
using static Sewer56.SonicRiders.Functions.Functions;

namespace Sewer56.SonicRiders.API
{
    public static class Event
    {
        private static IHook<DefaultFn> _endFrameHook = EndFrame.Hook(OnEndFrame).Activate();
        
        /// <summary>
        /// Executed after rendering a frame right before the game is about to sleep for frame pacing purposes.
        /// </summary>
        public static event Action OnSleep;

        /// <summary>
        /// Executed after rendering a frame and sleeping for frame pacing purposes.
        /// </summary>
        public static event Action AfterSleep;

        /* Hooks */
        
        /* Hook Bodies */
        private static void OnEndFrame()
        {
            OnSleep?.Invoke();
            _endFrameHook.OriginalFunction();
            AfterSleep?.Invoke();
        }
    }
}
