using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;

namespace Sewer56.SonicRiders.Functions
{
    public static class Functions
    {
        /// <summary>
        /// Writes the inputs to the current input struct at <see cref="Sewer56.SonicRiders.Fields.Players.PlayerInputs"/>
        /// </summary>
        public static readonly IFunction<HandleInputs> GetInputs = SDK.ReloadedHooks.CreateFunction<HandleInputs>(0x00513B70);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int HandleInputs();
    }
}
