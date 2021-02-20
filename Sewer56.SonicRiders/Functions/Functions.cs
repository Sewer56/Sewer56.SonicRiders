using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Structs;
using Reloaded.Hooks.Definitions.X86;
using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Functions;
using Sewer56.SonicRiders.Structures.Tasks;
using Sewer56.SonicRiders.Structures.Tasks.Base;
using Sewer56.SonicRiders.Structures.Tasks.Enums.States;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute.Register;
using static Reloaded.Hooks.Definitions.X86.FunctionAttribute.StackCleanup;
using Void = Reloaded.Hooks.Definitions.Structs.Void;

namespace Sewer56.SonicRiders.Functions
{
    public static class Functions
    {
        /// <summary>
        /// Writes the inputs to the current input struct at <see cref="Player.Inputs"/>
        /// </summary>
        public static readonly IFunction<CdeclReturnIntFn> GetInputs = SDK.ReloadedHooks.CreateFunction<CdeclReturnIntFn>(0x00513B70);

        /// <summary>
        /// Task responsible for player movement, physics simulation and various other similar traits.
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> PlayerCtrlTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x004BCEC0);

        /// <summary>
        /// The task handler for the main menu (title sequence).
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> TitleSequenceTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x0046ABD0);

        /// <summary>
        /// The task handler for the stage select.
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> CourseSelectTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x00465070);

        /// <summary>
        /// The task handler for the race settings.
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> RaceSettingTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x00473270);

        /// <summary>
        /// The task handler for character select.
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> CharaSelectTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x00462000);

        /// <summary>
        /// Executed every frame while the character is racing.
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> UnknownRaceTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x004159A0);

        /// <summary>
        /// Executed when a MessageBox is being displayed.
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> MessageBoxTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x0050DB90);

        /// <summary>
        /// Starts an attack task, making <param name="playerOne"/> attack <param name="playerTwo"/>.
        /// </summary>
        public static readonly IFunction<StartAttackTaskFn> StartAttackTask = SDK.ReloadedHooks.CreateFunction<StartAttackTaskFn>(0x004CDE60);

        /// <summary>
        /// Sleeps the game until the next frame.
        /// </summary>
        public static readonly IFunction<ReturnVoidFn> EndFrame = SDK.ReloadedHooks.CreateFunction<ReturnVoidFn>(0x00527CE0);

        /// <summary>
        /// Handles various movement flags that player has.
        /// See: <see cref="Structures.Gameplay.Player.MovementFlags"/>
        /// </summary>
        public static readonly IFunction<PlayerFn> HandleBoostMovementFlagsFn = SDK.ReloadedHooks.CreateFunction<PlayerFn>(0x004CFD70);

        /// <summary>
        /// Sets player movement flags based on player inputs.
        /// <see cref="Structures.Gameplay.Player.MovementFlags"/>
        /// </summary>
        public static readonly IFunction<SetMovementFlagsBasedOnInputFn> SetMovementFlagsOnInput = SDK.ReloadedHooks.CreateFunction<SetMovementFlagsBasedOnInputFn>(0x004B37F0);

        /// <summary>
        /// Sets the next player state. Called typically at the end of a state handler.
        /// </summary>
        public static readonly IFunction<SetNewPlayerStateFn> SetPlayerState = SDK.ReloadedHooks.CreateFunction<SetNewPlayerStateFn>(0x004BD850);

        /// <summary>
        /// Sets an itembox pickup to be rendered to the screen.
        /// </summary>
        public static readonly IFunction<SetRenderItemPickupTaskFn> SetRenderItemPickupTask = SDK.ReloadedHooks.CreateFunction<SetRenderItemPickupTaskFn>(0x004C5C50);

        /// <summary>
        /// Sets the spawn locations for all players at the start of race.
        /// Parameter: Number of players 0-7
        /// </summary>
        public static readonly IFunction<StartLineSetSpawnLocationsFn> SetSpawnLocationsStartOfRace = SDK.ReloadedHooks.CreateFunction<StartLineSetSpawnLocationsFn>(0x004139F0);

        /// <summary>
        /// C srand
        /// </summary>
        public static readonly IFunction<SRandFn> SRand = SDK.ReloadedHooks.CreateFunction<SRandFn>(0x0059B7BD);

        /// <summary>
        /// C rand
        /// </summary>
        public static readonly IFunction<RandFn> Rand = SDK.ReloadedHooks.CreateFunction<RandFn>(0x0059B7CA);

        /// <summary>
        /// Sets a new file to be opened by the game.
        /// </summary>
        public static readonly IFunction<ArchiveSetLoadFileFn> ArchiveAddLoadFile      = SDK.ReloadedHooks.CreateFunction<ArchiveSetLoadFileFn>(0x0041FA10);

        /// <summary>
        /// Sets a new file to be opened by the game.
        /// </summary>
        public static readonly IFunction<ArchiveInGameSetLoadFileFn> ArchiveInGameLoadFile = SDK.ReloadedHooks.CreateFunction<ArchiveInGameSetLoadFileFn>(0x00514570);

        /// <summary>
        /// Removes a file opened by the game.
        /// </summary>
        public static readonly IFunction<ArchiveUnsetLoadFileFn> ArchiveRemoveLoadFile  = SDK.ReloadedHooks.CreateFunction<ArchiveUnsetLoadFileFn>(0x0041F540);

        /// <summary>
        /// Sets up the <see cref="CompressorData"/> structure.
        /// </summary>
        public static readonly IFunction<InitDecompressionFn> InitDecompression         = SDK.ReloadedHooks.CreateFunction<InitDecompressionFn>(0x004110B0);

        /// <summary>
        /// Decompresses a block of data.
        /// </summary>
        public static readonly IFunction<DecompressFn> Decompress                       = SDK.ReloadedHooks.CreateFunction<DecompressFn>(0x004111B0);

        /// <summary>
        /// Deallocates a file from shared buffer space.
        /// </summary>
        public static readonly IFunction<FileDeallocateFn> FileDeallocate = SDK.ReloadedHooks.CreateFunction<FileDeallocateFn>(0x005278E0);

        /// <summary>
        /// Initializes third party libraries.
        /// </summary>
        public static readonly IFunction<CdeclReturnIntFn> InitThirdPartyLibraries = SDK.ReloadedHooks.CreateFunction<CdeclReturnIntFn>(0x004EDE50);

        /// <summary>
        /// Reads the user config file.
        /// </summary>
        public static readonly IFunction<CdeclReturnIntFn> ReadConfigFile = SDK.ReloadedHooks.CreateFunction<CdeclReturnIntFn>(0x005128C0);

        /// <summary>
        /// Renders a 2 dimensional texture to the screen.
        /// </summary>
        public static readonly IFunction<RenderTexture2DFn> RenderTexture2D = SDK.ReloadedHooks.CreateFunction<RenderTexture2DFn>(0x005327F0);

        /// <summary>
        /// Renders an individual player indicator to the screen.
        /// </summary>
        public static readonly IFunction<RenderPlayerIndicatorFn> RenderPlayerIndicator = SDK.ReloadedHooks.CreateFunction<RenderPlayerIndicatorFn>(0x00426980);

        /// <summary>
        /// Sets the task which presents the final results screen onto the screen.
        /// </summary>
        public static readonly IFunction<SetGoalRaceFinishTaskFn> SetGoalRaceFinishTask = SDK.ReloadedHooks.CreateFunction<SetGoalRaceFinishTaskFn>(0x00426040);

        /// <summary>
        /// Updates the lap counter of the individual player once they cross the finish line.
        /// </summary>
        public static readonly IFunction<UpdateLapCounterFn> UpdateLapCounter = SDK.ReloadedHooks.CreateFunction<UpdateLapCounterFn>(0x004B3E70);

        /// <summary>
        /// Saves current settings set inside the rule settings menu.
        /// </summary>
        public static readonly IFunction<RuleSettingsSaveCurrentSettingsFn> RuleSettingsSaveCurrentSettings = SDK.ReloadedHooks.CreateFunction<RuleSettingsSaveCurrentSettingsFn>(0x00472AE0);

        /// <summary>
        /// Sets a new task to be executed on the game's native task heap.
        /// </summary>
        public static readonly IFunction<SetTaskFn> SetTask = SDK.ReloadedHooks.CreateFunction<SetTaskFn>(0x00527E00);

        /// <summary>
        /// Sets a new task to be executed on the game's native task heap.
        /// </summary>
        public static readonly IFunction<KillTaskFn> KillTask = SDK.ReloadedHooks.CreateFunction<KillTaskFn>(0x00527F20);

        /// <summary>
        /// The task used to render the race finish sequence after the final player crosses the finish line.
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> GoalRaceFinishTask = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x0043AC20);

        /// <summary>
        /// Removes all the tasks from the task heap.
        /// </summary>
        public static readonly IFunction<CdeclReturnIntFn> RemoveAllTasks = SDK.ReloadedHooks.CreateFunction<CdeclReturnIntFn>(0x00527F80);

        /// <summary>
        /// Removes all the tasks from the task heap.
        /// </summary>
        public static readonly IFunction<RunPlayerPhysicsSimulationFn> RunPlayerPhysicsSimulation = SDK.ReloadedHooks.CreateFunction<RunPlayerPhysicsSimulationFn>(0x004BAE00);

        /// <summary>
        /// Loads the assets to be used during the race.
        /// The stage geometry, survival items, gears, etc.
        /// </summary>
        public static readonly IFunction<CdeclReturnIntFn> LoadWorldAssets = SDK.ReloadedHooks.CreateFunction<CdeclReturnIntFn>(0x00408A10);

        /// <summary>
        /// Reads the object layout data from memory and 
        /// </summary>
        public static readonly IFunction<CdeclReturnByteFn> InitializeStageObjects = SDK.ReloadedHooks.CreateFunction<CdeclReturnByteFn>(0x004196D0);

        /* Definitions */
        [Function(CallingConventions.Cdecl)]
        public delegate int CdeclReturnIntFn();
        [Function(CallingConventions.Cdecl)]
        public struct CdeclReturnIntFnPtr { public FuncPtr<int> Value; }

        [Function(CallingConventions.Cdecl)]
        public delegate byte CdeclReturnByteFn();
        [Function(CallingConventions.Cdecl)]
        public struct CdeclReturnByteFnPtr { public FuncPtr<byte> Value; }

        [Function(CallingConventions.Cdecl)]
        public delegate void ReturnVoidFn();
        [Function(CallingConventions.Cdecl)]
        public struct ReturnVoidFnPtr { public FuncPtr<Void> Value; }

        /// <summary>
        /// Starts an attack task, making <param name="playerOne"/> attack <param name="playerTwo"/>.
        /// </summary>
        /// <param name="playerOne">The player attacking the other player.</param>
        /// <param name="playerTwo">The player getting attacked by.</param>
        /// <param name="a3">Unknown, typically 1.</param>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int StartAttackTaskFn(Structures.Gameplay.Player* playerOne, Structures.Gameplay.Player* playerTwo, int a3);
        [Function(CallingConventions.Cdecl)]
        public struct StartAttackTaskFnPtr { public FuncPtr<BlittablePointer<Structures.Gameplay.Player>, BlittablePointer<Structures.Gameplay.Player>, int, int> Value; }

        /// <summary>
        /// Used for functions which accept a singular player as a parameter.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int PlayerFn(Structures.Gameplay.Player* player);
        [Function(CallingConventions.Cdecl)]
        public struct PlayerFnPtr { public FuncPtr<BlittablePointer<Structures.Gameplay.Player>, int> Value; }

        /// <summary>
        /// Updates the current <see cref="PlayerState"/> for the player.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate byte SetNewPlayerStateFn(Structures.Gameplay.Player* player, PlayerState state);
        [Function(CallingConventions.Cdecl)]
        public struct SetNewPlayerStateFnPtr { public FuncPtr<BlittablePointer<Structures.Gameplay.Player>, PlayerState, byte> Value; }

        /// <summary>
        /// Checks for player input and sets movement flags (<see cref="MovementFlags"/>) such as Boost and Tornado.
        /// </summary>
        [Function(eax, eax, Caller)]
        public unsafe delegate Structures.Gameplay.Player* SetMovementFlagsBasedOnInputFn(Structures.Gameplay.Player* player);
        [Function(eax, eax, Caller)]
        public struct SetMovementFlagsBasedOnInputFnPtr { public FuncPtr<BlittablePointer<Structures.Gameplay.Player>, BlittablePointer<Structures.Gameplay.Player>> Value; }

        /// <summary>
        /// Adds a task onto the game's task heap that renders the pickup of a new item onto the HUD.
        /// </summary>
        [Function(esi, eax, Caller)]
        public unsafe delegate Task* SetRenderItemPickupTaskFn(Structures.Gameplay.Player* player, byte a2, ushort a3);
        [Function(esi, eax, Caller)]
        public struct SetRenderItemPickupTaskFnPtr { public FuncPtr<BlittablePointer<Structures.Gameplay.Player>, byte, ushort, BlittablePointer<Task>> Value; }

        /// <summary>
        /// Sets the spawn locations at the start of race for each player depending on the location of the start line.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int StartLineSetSpawnLocationsFn(int numberOfPlayers);
        [Function(CallingConventions.Cdecl)]
        public struct StartLineSetSpawnLocationsFnPtr { public FuncPtr<int, int> Value; }

        /// <summary>
        /// Visual C++'s implementation of srand.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate void SRandFn(uint seed);
        [Function(CallingConventions.Cdecl)]
        public struct SRandFnPtr { public FuncPtr<uint, Void> Value; }

        /// <summary>
        /// Visual C++'s implementation of rand.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int RandFn();
        [Function(CallingConventions.Cdecl)]
        public struct RandFnPtr { public FuncPtr<int> Value; }

        /// <summary>
        /// Adds a file to the linked list of loaded files such that the game will load it.
        /// </summary>
        /// <returns>Unique index for the file</returns>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int ArchiveSetLoadFileFn(void* fileName, int typicallyOne, int typicallyOne_1, int typicallyZero, void* someKindOfBuffer, void* someKindOfOtherBuffer, int typicallyOne_2, int typicallyOne_3, int playerIndex);

        /// <summary>
        /// Unloads a file from memory.
        /// </summary>
        /// <param name="fileIndex">File index returned from <see cref="ArchiveSetLoadFileFn"/></param>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int ArchiveUnsetLoadFileFn(int fileIndex);

        /// <param name="comp">Pointer to compressor data to initialize.</param>
        /// <param name="pUncompressedData">Pointer to uncompressed buffer.</param>
        /// <param name="archiveType">Archive type (of some kind).</param>
        /// <param name="archiveSize">Size of uncompressed data (<see paramref="pUncompressedData"/>)</param>
        /// <param name="a5"></param>
        /// <param name="blockSize">Block size.</param>
        /// <returns></returns>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate CompressorData* InitDecompressionFn(CompressorData* comp, void* pUncompressedData, byte archiveType, int archiveSize, byte a5, int blockSize);

        /// <param name="comp">Compressor data.</param>
        /// <param name="pCompressedData">Pointer to the compressed data.</param>
        /// <param name="blockSize">Block size.</param>
        /// <param name="pBlockSizeRead">Amount of data in the current block that has been read.</param>
        /// <param name="pMaybeFinishedDecompressing">Set to 1 if end of data.</param>
        /// <returns></returns>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate byte DecompressFn(CompressorData* comp, void* pCompressedData, int blockSize, int* pBlockSizeRead, bool* pMaybeFinishedDecompressing);

        /// <summary>
        /// Sets a file to be loaded in-game.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="header">Shared file buffer header</param>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate SharedFileBufferHeader* ArchiveInGameSetLoadFileFn(string fileName, SharedFileBufferHeader* header);

        /// <summary>
        /// Deallocates a file from shared buffer space.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int FileDeallocateFn(SharedFileBufferHeader* header);

        /// <summary>
        /// Renders a 2D texture to the screen.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate int RenderTexture2DFn(int isQuad, Vector3* vertices, int numVertices, float opacity);
        [Function(CallingConventions.Cdecl)]
        public struct RenderTexture2DFnPtr { public FuncPtr<int, BlittablePointer<Vector3>, int, float, int> Value; }

        /// <summary>
        /// Renders a player indicator to the screen.
        /// </summary>
        [Function(new[] { eax, ecx, edi, esi }, eax, Caller)]
        public unsafe delegate int RenderPlayerIndicatorFn(int a1, int a2, int a3, int a4, int horizontalOffset, int a6, int a7, int a8, int a9, int a10);
        [Function(new[] { eax, ecx, edi, esi }, eax, Caller)]
        public struct RenderPlayerIndicatorFnPtr { public FuncPtr<int, int, int, int, int, int, int, int, int, int, int> Value; }

        /// <summary>
        /// Sets up the task that displays the new lap and results screen once the player crosses for a new lap.
        /// </summary>
        /// <param name="player">The player to show the results screen for.</param>
        [Function(new[] { esi }, eax, Caller)]
        public unsafe delegate int SetGoalRaceFinishTaskFn(Structures.Gameplay.Player* player);

        /// <summary>
        /// Updates the player's lap counter.
        /// </summary>
        [Function(new[] { eax }, eax, Caller)]
        public unsafe delegate int UpdateLapCounterFn(Structures.Gameplay.Player* player, int a2);

        /// <summary>
        /// Saves the current rule settings menu content to game memory
        /// </summary>
        [Function(new[] { eax }, eax, Caller)]
        public unsafe delegate int RuleSettingsSaveCurrentSettingsFn(RaceRules* taskData);

        /// <summary>
        /// Sets a new task to be executed.
        /// </summary>
        /// <param name="methodPtr">Address of the method to be executed. Method is of type <see cref="CdeclReturnIntFn"/>.</param>
        /// <param name="maybeMaxTaskHeapSize"></param>
        /// <param name="taskDataSize">
        ///     If value is 1, task data pointer has a size of 30 bytes.
        ///     If value is 2, task data pointer has a size of 126 bytes.
        /// </param>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate Task* SetTaskFn(void* methodPtr, uint maybeMaxTaskHeapSize, int taskDataSize);
        [Function(CallingConventions.Cdecl)] 
        public struct SetTaskFnPtr { public FuncPtr<IntPtr, uint, int, BlittablePointer<Task>> Value; }

        /// <summary>
        /// Kills the current task (<see cref="State.CurrentTask"/>).
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate Task* KillTaskFn();
        [Function(CallingConventions.Cdecl)]
        public struct KillTaskFnPtr { public FuncPtr<BlittablePointer<Task>> Value; }

        /// <summary>
        /// Kills the current task (<see cref="State.CurrentTask"/>).
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        public unsafe delegate void RunPlayerPhysicsSimulationFn(void* somePhysicsObjectPtr, Vector4* vector, int* playerIndex);
        
        [Function(CallingConventions.Cdecl)]
        public struct RunPlayerPhysicsSimulationFnPtr { public FuncPtr<BlittablePointer<Void>, BlittablePointer<Vector4>, BlittablePointer<int>, Void> Value; }
    }
}
