using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ProcessThread = System.Diagnostics.ProcessThread;

namespace Sewer56.SonicRiders.API
{
    public static class Window
    {
        public const string WindowClass = "SonicRidersClass";
        private static IntPtr _cachedWindowHandle;
        private static Process _currentProcess = Process.GetCurrentProcess();

        /// <summary>
        /// Retrieves the handle of the game window based off of the class of the window.
        /// </summary>
        public static IntPtr WindowHandle
        {
            get
            {
                if (IsWindow(_cachedWindowHandle))
                    return _cachedWindowHandle;

                _cachedWindowHandle = EnumerateThisProcessWindowHandles().FirstOrDefault();
                return _cachedWindowHandle;
            }
        }

        /// <summary>
        /// Returns true if any of the windows belonging to the game process are in focus.
        /// </summary>
        public static bool IsAnyWindowActivated()
        {
            IntPtr activatedHandle = GetForegroundWindow();

            if (activatedHandle == IntPtr.Zero)
                return false;

            GetWindowThreadProcessId(activatedHandle, out int activeProcessId);
            return activeProcessId == _currentProcess.Id;
        }

        private static IEnumerable<IntPtr> EnumerateThisProcessWindowHandles()
        {
            IntPtr handle = IntPtr.Zero;
            foreach (ProcessThread thread in _currentProcess.Threads)
            {
                handle = IntPtr.Zero;
                EnumThreadWindows(thread.Id, (hWnd, lParam) =>
                {
                    var stringBuilder = new StringBuilder(256);
                    GetClassName(hWnd, stringBuilder, 256);
                    if (stringBuilder.ToString().Equals(WindowClass, StringComparison.OrdinalIgnoreCase))
                        handle = hWnd;

                    return true;
                }, IntPtr.Zero);
                
                if (handle != IntPtr.Zero)
                    yield return handle;
            }
        }

        /* Windows API Imports */
        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        #region MyRegion
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
        #endregion

    }
}
