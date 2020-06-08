using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Sewer56.SonicRiders.API;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute.Register;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute.StackCleanup;

namespace Sewer56.SonicRiders.Functions
{
    public static class Functions
    {
        /// <summary>
        /// Writes the inputs to the current input struct at <see cref="Player.Inputs"/>
        /// </summary>
        public static readonly IFunction<GetInputsFn> GetInputs = SDK.ReloadedHooks.CreateFunction<GetInputsFn>(0x00513B70);

        /// <summary>
        /// The task handler for the main menu (title sequence).
        /// </summary>
        public static readonly IFunction<TitleSequenceTaskFn> TitleSequenceTask = SDK.ReloadedHooks.CreateFunction<TitleSequenceTaskFn>(0x0046ABD0);

        /// <summary>
        /// The task handler for the stage select.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> CourseSelectTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x00465070);

        /// <summary>
        /// The task handler for the race settings.
        /// </summary>
        public static readonly IFunction<DefaultFn> RaceSettingTask = SDK.ReloadedHooks.CreateFunction<DefaultFn>(0x00473270);

        /// <summary>
        /// The task handler for character select.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> CharaSelectTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x00462000);

        /// <summary>
        /// Executed every frame while the character is racing.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> UnknownRaceTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x004159A0);

        /// <summary>
        /// Sleeps the game until the next frame.
        /// </summary>
        public static readonly IFunction<DefaultFn> EndFrame = SDK.ReloadedHooks.CreateFunction<DefaultFn>(0x00527CE0);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetInputsFn();

        [Function(new [] { ecx, edx }, eax, Caller)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte TitleSequenceTaskFn(int a1, int a2);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte DefaultTaskFnWithReturn();

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DefaultFn();
    }
}
