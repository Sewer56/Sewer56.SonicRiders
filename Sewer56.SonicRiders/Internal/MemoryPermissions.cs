using System.Diagnostics;
using Reloaded.Memory.Kernel32;
using Reloaded.Memory.Sources;

namespace Sewer56.SonicRiders.Internal
{
    /// <summary>
    /// Utility class that changes all memory permissions to read/write/execute for the current process.
    /// </summary>
    public static class MemoryPermissions
    {
        private static bool _isChanged = false;

        /// <summary>
        /// Changes permissions for the whole process to read/write/execute.
        /// </summary>
        public static void Change()
        {
            if (_isChanged)
                return;

            var mainModule = Process.GetCurrentProcess().MainModule;
            if (mainModule != null)
                Memory.CurrentProcess.ChangePermission((nuint)(nint)mainModule.BaseAddress, mainModule.ModuleMemorySize, Kernel32.MEM_PROTECTION.PAGE_EXECUTE_READWRITE);

            _isChanged = true;
        }
    }
}
