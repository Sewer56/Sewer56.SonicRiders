using Reloaded.Hooks.Definitions;
using Sewer56.SonicRiders.Internal;

namespace Sewer56.SonicRiders
{
    public static class SDK
    {
        /// <summary>
        /// Singular source of Reloaded.Hooks library.
        /// Can be replaced with shared library at runtime.
        /// </summary>
        public static IReloadedHooks ReloadedHooks { get; private set; }

        /// <summary>
        /// Initializes the Riders SDK as a Reloaded II mod, setting the shared library to be used.
        /// </summary>
        public static void Init(IReloadedHooks hooks)
        {
            ReloadedHooks = hooks;
            MemoryPermissions.Change();
        }
    }
}
