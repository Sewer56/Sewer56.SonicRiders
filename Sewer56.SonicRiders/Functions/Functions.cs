using System.Runtime.InteropServices;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Functions;
using Sewer56.SonicRiders.Structures.Tasks.Base;
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

        /// <summary>
        /// Sets an itembox pickup to be rendered to the screen.
        /// </summary>
        public static readonly IFunction<SetRenderItemPickupTaskFn> SetRenderItemPickupTask = SDK.ReloadedHooks.CreateFunction<SetRenderItemPickupTaskFn>(0x004C5C50);

        /// <summary>
        /// Sets the spawn locations for all players at the start of race.
        /// Parameter: Number of players 0-7
        /// </summary>
        public static readonly IFunction<SetSpawnLocationsStartOfRaceFn> SetSpawnLocationsStartOfRace = SDK.ReloadedHooks.CreateFunction<SetSpawnLocationsStartOfRaceFn>(0x004139F0);

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
        public static readonly IFunction<DefaultReturnFn> InitThirdPartyLibraries       = SDK.ReloadedHooks.CreateFunction<DefaultReturnFn>(0x004EDE50);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetInputsFn();

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate byte DefaultTaskFnWithReturn();

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DefaultFn();

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int DefaultReturnFn();

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

        [Function(esi, eax, Caller)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate Task* SetRenderItemPickupTaskFn(Structures.Gameplay.Player* player, byte a2, ushort a3);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int SetSpawnLocationsStartOfRaceFn(int numberOfPlayers);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate void SRandFn(uint seed);

        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int RandFn();

        /// <returns>Unique index for the file</returns>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int ArchiveSetLoadFileFn(void* fileName, int typicallyOne, int typicallyOne_1, int typicallyZero, void* someKindOfBuffer, void* someKindOfOtherBuffer, int typicallyOne_2, int typicallyOne_3, int playerIndex);

        /// <summary>
        /// Unloads a file from memory.
        /// </summary>
        /// <param name="fileIndex">File index returned from <see cref="ArchiveSetLoadFileFn"/></param>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int ArchiveUnsetLoadFileFn(int fileIndex);

        /// <param name="comp">Pointer to compressor data to initialize.</param>
        /// <param name="pUncompressedData">Pointer to uncompressed buffer.</param>
        /// <param name="archiveType">Archive type (of some kind).</param>
        /// <param name="archiveSize">Size of uncompressed data (<see cref="pUncompressedData"/>)</param>
        /// <param name="a5"></param>
        /// <param name="blockSize">Block size.</param>
        /// <returns></returns>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate CompressorData* InitDecompressionFn(CompressorData* comp, void* pUncompressedData, byte archiveType, int archiveSize, byte a5, int blockSize);

        /// <param name="comp">Compressor data.</param>
        /// <param name="pCompressedData">Pointer to the compressed data.</param>
        /// <param name="blockSize">Block size.</param>
        /// <param name="pBlockSizeRead">Amount of data in the current block that has been read.</param>
        /// <param name="pMaybeFinishedDecompressing">Set to 1 if end of data.</param>
        /// <returns></returns>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate byte DecompressFn(CompressorData* comp, void* pCompressedData, int blockSize, int* pBlockSizeRead, bool* pMaybeFinishedDecompressing);

        /// <summary>
        /// Sets a file to be loaded in-game.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="header">Shared file buffer header</param>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate SharedFileBufferHeader* ArchiveInGameSetLoadFileFn(string fileName, SharedFileBufferHeader* header);

        /// <summary>
        /// Deallocates a file from shared buffer space.
        /// </summary>
        [Function(CallingConventions.Cdecl)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate int FileDeallocateFn(SharedFileBufferHeader* header);
    }
}
