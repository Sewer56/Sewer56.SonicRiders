using System;
using System.Collections.Generic;
using System.Text;
using Reloaded.Hooks.Definitions;
using static Sewer56.SonicRiders.Functions.Functions;

namespace Sewer56.SonicRiders.API
{
    public static class Event
    {
        private static IHook<DefaultFn> _endFrameHook;
        private static event Action _onSleep;
        private static event Action _afterSleep;

        /// <summary>
        /// Executed after rendering a frame right before the game is about to sleep for frame pacing purposes.
        /// </summary>
        public static event Action OnSleep
        {
            add
            {
                if (_endFrameHook == null)
                    _endFrameHook = EndFrame.Hook(OnEndFrame).Activate();

                _onSleep += value;
            }
            remove => _onSleep -= value;
        }

        /// <summary>
        /// Executed after rendering a frame and sleeping for frame pacing purposes.
        /// </summary>
        public static event Action AfterSleep
        {
            add
            {
                if (_endFrameHook == null)
                    _endFrameHook = EndFrame.Hook(OnEndFrame).Activate();

                _afterSleep += value;
            }
            remove => _afterSleep -= value;
        }

        /* Hooks */
        
        /* Hook Bodies */
        private static void OnEndFrame()
        {
            _onSleep?.Invoke();
            _endFrameHook.OriginalFunction();
            _afterSleep?.Invoke();
        }
    }
}
