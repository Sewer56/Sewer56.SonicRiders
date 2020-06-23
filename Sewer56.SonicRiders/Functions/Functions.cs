using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Structures.Enums;
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
        public static readonly IFunction<DefaultTaskFnWithReturn> TitleSequenceTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x0046ABD0);

        /// <summary>
        /// The task handler for the stage select.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> CourseSelectTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x00465070);

        /// <summary>
        /// The task handler for the race settings.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> RaceSettingTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x00473270);

        /// <summary>
        /// The task handler for character select.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> CharaSelectTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x00462000);

        /// <summary>
        /// Executed every frame while the character is racing.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> UnknownRaceTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x004159A0);

        /// <summary>
        /// Executed when a MessageBox is being displayed.
        /// </summary>
        public static readonly IFunction<DefaultTaskFnWithReturn> MessageBoxTask = SDK.ReloadedHooks.CreateFunction<DefaultTaskFnWithReturn>(0x0050DB90);

        /// <summary>
        /// Starts an attack task, making <param name="playerOne"/> attack <param name="playerTwo"/>.
        /// </summary>
        public static readonly IFunction<StartAttackTaskFn> StartAttackTask = SDK.ReloadedHooks.CreateFunction<StartAttackTaskFn>(0x004CDE60);

        /// <summary>
        /// Sleeps the game until the next frame.
        /// </summary>
        public static readonly IFunction<DefaultFn> EndFrame = SDK.ReloadedHooks.CreateFunction<DefaultFn>(0x00527CE0);

        /// <summary>
        /// Handles various movement flags that player has.
        /// See: <see cref="Structures.Gameplay.Player.NewMovementFlags"/>
        /// </summary>
        public static readonly IFunction<PlayerFn> HandleBoostMovementFlagsFn = SDK.ReloadedHooks.CreateFunction<PlayerFn>(0x004CFD70);

        /// <summary>
        /// Sets player movement flags based on player inputs.
        /// <see cref="Structures.Gameplay.Player.NewMovementFlags"/>
        /// </summary>
        public static readonly IFunction<SetMovementFlagsBasedOnInputFn> SetMovementFlagsOnInput = SDK.ReloadedHooks.CreateFunction<SetMovementFlagsBasedOnInputFn>(0x004B37F0);

        /// <summary>
        /// Sets the next player state. Called typically at the end of a state handler.
        /// </summary>
        public static readonly IFunction<SetNewPlayerStateFn> SetPlayerState = SDK.ReloadedHooks.CreateFunction<SetNewPlayerStateFn>(0x004BD850);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetInputsFn();

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte DefaultTaskFnWithReturn();

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DefaultFn();

        /// <summary>
        /// Starts an attack task, making <param name="playerOne"/> attack <param name="playerTwo"/>.
        /// </summary>
        /// <param name="playerOne">The player attacking the other player.</param>
        /// <param name="playerTwo">The player getting attacked by.</param>
        /// <param name="a3">Unknown, typically 1.</param>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int StartAttackTaskFn(Structures.Gameplay.Player* playerOne, Structures.Gameplay.Player* playerTwo, int a3);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int PlayerFn(Structures.Gameplay.Player* player);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate byte SetNewPlayerStateFn(Structures.Gameplay.Player* player, PlayerState state);

        [Function(eax, eax, Caller)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Structures.Gameplay.Player* SetMovementFlagsBasedOnInputFn(Structures.Gameplay.Player* player);
    }
}
