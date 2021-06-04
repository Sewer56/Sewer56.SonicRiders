using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Gameplay;
using Sewer56.SonicRiders.Structures.Tasks.Base;
using Sewer56.SonicRiders.Structures.Tasks.Enums.States;

namespace Sewer56.SonicRiders.API
{
    /// <summary>
    /// Contains various miscellaneous variables which do not have enough similar
    /// ones to group in the same category.
    /// </summary>
    public static unsafe class State
    {
        /// <summary>
        /// Number of player characters to spawn. Should be set during stage load (before Stage Task is added).
        /// The range for this is generally 1-8, else expect crashes.
        /// </summary>
        public static readonly int* NumberOfRacers = (int*)0x64B758;

        /// <summary>
        /// Number of human characters in game.
        /// Setting this value to 0 prevents pausing.
        /// </summary>
        public static readonly int* NumberOfHumanRacers = (int*)0x64B75C;

        /// <summary>
        /// Number of cameras to display.
        /// This is normally set during stage initialization, specifically when the Race Task is added.
        /// </summary>
        public static readonly int* NumberOfCameras = (int*) 0x0064B760;

        /// <summary>
        /// True if more than one camera should be rendered, else false.
        /// This is set during stage initialization, specifically when the Race Task is added.
        /// </summary>
        public static readonly int* HasMoreThanOneCamera = (int*) 0x00696C18;

        /// <summary>
        /// The current race mode of operation.
        /// This is set during stage initialization, specifically when the Race Task is added.
        /// That said, it can be changed in real-time for a limited set of scenarios.
        /// Changing this values enables shortcuts in e.g. Race Stage, or can allow racing in Battle Mode.
        /// </summary>
        public static readonly ActiveRaceMode* RaceMode = (ActiveRaceMode*)0x00692B88;

        /// <summary>
        /// Does not affect level timer/state e.g. starting line, interactive elements.
        /// Setting this pauses the game without allowing the user to control the pause menu.
        /// </summary>
        public static readonly bool* IsPaused = (bool*)0x00696C28;

        /// <summary>
        /// Timer of the currently played race.
        /// </summary>
        public static readonly Timer* StageTimer = (Timer*) 0x692AE0;

        /// <summary>
        /// Declares the level/action stage to be loaded.
        /// </summary>
        public static readonly Levels* Level = (Levels*)0x692B90;

        /// <summary>
        /// True if babylon cup is unlocked, else false.
        /// </summary>
        public static readonly bool* IsBabylonCupUnlocked = (bool*) 0x17BE1B8;

        /// <summary>
        /// Pointer to the current stage object layout data.
        /// </summary>
        public static readonly void** CurrentStageObjectLayout = (void**) 0x00696C68;

        /// <summary>
        /// An array of unlocked stages in the game.
        /// Use <see cref="UnlockedLevels"/> as an indexer.
        /// </summary>
        public static RefFixedArrayPtr<bool> UnlockedStages { get; private set; } = new RefFixedArrayPtr<bool>((ulong)0x17BE1A4, (int)UnlockedLevels.SEGAIllusion + 1);

        /// <summary>
        /// An array of unlocked characters in the game.
        /// Use <see cref="Characters"/> as an indexer.
        /// Note: Careful! Exiting character select will freeze if any of the unlocked characters does not have a selectable gear!
        ///       This will happen if you enable all characters but don't unlock some gears.
        /// </summary>
        public static RefFixedArrayPtr<bool> UnlockedCharacters { get; private set; } = new RefFixedArrayPtr<bool>((ulong)0x17BE540, (int)Characters.E10000R + 1);

        /// <summary>
        /// An array of unlocked gears in the game.
        /// Use <see cref="ExtremeGearModel"/> as an indexer.
        /// </summary>
        public static RefFixedArrayPtr<bool> UnlockedGearModels { get; private set; } = new RefFixedArrayPtr<bool>((ulong)0x017BE4E8, (int)ExtremeGearModel.Cannonball + 1);

        /// <summary>
        /// Manual toggle for the heads up display.
        /// Bear in mind that the game constantly overwrites this value - you
        /// need to nop the instructions that write to it.
        /// </summary>
        public static readonly bool* IsHUDVisible = (bool*)0x64B76C;

        /// <summary>
        /// Setting this to 1 zooms in the camera until you pass the start line.
        /// </summary>
        public static readonly bool* EnableStartLine2PCamera = (bool*)0x69126B;

        /// <summary>
        /// [Apply before racing]
        /// Setting this to 1, makes the HUD cover 1/4th of the screen for player 1.
        /// </summary>
        public static readonly bool* TwoPlayerHUDScale = (bool*)0x696C1C;

        /// <summary>
        /// Pointer to the currently loaded task.
        /// </summary>
        public static readonly void** CurrentTask = (void**) 0x017B863C;

        /// <summary>
        /// This value uses a two digit encoding where the 10s column indicates the main menu and 0s submenu
        /// 
        /// 40 = Free Race Submenu
        /// 41 = Time Trial
        /// 42 = Grand Prix
        ///
        /// 50 = Story Hero
        /// 51 = Story Babylon
        /// etc.
        /// </summary>
        public static readonly int* MenuToReturnToFromRace = (int*) 0x6A21D8;

        /// <summary>
        /// Number of total elapsed frames.
        /// </summary>
        public static readonly int* TotalFrameCounter = (int*) 0x00696C08;

        /// <summary>
        /// Current race settings which were set in the race rules menu.
        /// This is a packed bitfield.
        /// </summary>
        public static readonly RaceSettings* CurrentRaceSettings = (RaceSettings*) 0x005F8758;

        /// <summary>
        /// Gets a pointer to the game (menu task) state.
        /// </summary>
        /// <returns>Pointer to the menu task state, else nullptr.</returns>
        public static bool TryGetGameState(out TitleSequenceTaskState* state)
        {
            var baseAddress = *(byte**)0x016BF1D0;
            if (baseAddress != (byte*)0x0)
            {
                state = (TitleSequenceTaskState*)(baseAddress + 0x94);
                return true;
            }

            state = (TitleSequenceTaskState*) 0x0;
            return false;
        }

        /// <summary>
        /// Tries to get the current Task executed by the game.
        /// You should call this in a function that handles a specific task.
        /// </summary>
        /// <param name="task">The executed task.</param>
        public static bool TryGetCurrentTask(out Task* task)
        {
            if (*CurrentTask != (void*) 0x0)
            {
                task = (Task*)(*CurrentTask);
                return true;
            }

            task = (Task*)0x0;
            return false;
        }
    }
}
