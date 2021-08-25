using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.Internal.DirectX;
using Sewer56.SonicRiders.Structures.Enums;

namespace Sewer56.SonicRiders.API
{
    public static unsafe class Misc
    {
        /// <summary>
        /// The currently executing process.
        /// </summary>
        public static Process CurrentProcess { get; private set; } = Process.GetCurrentProcess();

        /// <summary>
        /// The directory containing the main executable for the current process.
        /// </summary>
        public static string ExecutingDirectory { get; private set; } = Path.GetDirectoryName(CurrentProcess.MainModule.FileName);

        /// <summary>
        /// Relative spawn positions for each player.
        /// </summary>
        public static RefFixedArrayPtr<Vector3> RelativeSpawnPosition = new RefFixedArrayPtr<Vector3>(0x5F8760, Player.MaxNumberOfPlayers);

        /// <summary>
        /// Utility class that allows you to access the DirectX 9 VTable.
        /// </summary>
        public static Lazy<DX9Hook> DX9Hook { get; set; } = DX9Hook = new Lazy<DX9Hook>(() => new DX9Hook(SDK.ReloadedHooks));

        /// <summary>
        /// Horizontal resolution of the game (as configured in launcher).
        /// </summary>
        public static int* ResolutionX = (int*) 0x16BC678;

        /// <summary>
        /// Vertical resolution of the game (as configured in launcher).
        /// </summary>
        public static int* ResolutionY = (int*) 0x016BC7BC;

        /// <summary>
        /// Greater than 0 if CRI middleware components are initialised, else 0.
        /// </summary>
        public static int* IsCriInitialized = (int*) 0x016BFC04;

        /// <summary>
        /// Horizontal resolution of the game (as configured in launcher).
        /// </summary>
        public static float* AspectRatio2dResolutionX = (float*)0x005B0228;

        /// <summary>
        /// Horizontal resolution of the game (as configured in launcher).
        /// </summary>
        public static float* AspectRatio2dResolutionY = (float*)0x005B022C;

        /// <summary>
        /// Whether fullscreen is set to on in the game configuration.
        /// </summary>
        public static bool* ConfigFullscreen = (bool*)0x016BCD38;

        /// <summary>
        /// The current game language in the game configuration.
        /// </summary>
        public static MessageLanguage* ConfigMessageLanguage = (MessageLanguage*)0x016BCBE8;

        /// <summary>
        /// The current game voice language in the game configuration.
        /// </summary>
        public static VoiceLanguage* ConfigVoiceLanguage = (VoiceLanguage*)0x016BC558;

        /// <summary>
        /// The current game language.
        /// </summary>
        public static MessageLanguage* MessageLanguage = (MessageLanguage*)0x64B778;

        /// <summary>
        /// The current game voice language.
        /// </summary>
        public static VoiceLanguage* VoiceLanguage = (VoiceLanguage*)0x64B77C;

        /// <summary>
        /// Whether fullscreen is set to on.
        /// </summary>
        public static int* MultiSampleType = (int*)0x016BC7B0;

        /// <summary>
        /// Whether motion blur is currently enabled.
        /// </summary>
        public static bool* Blur = (bool*)0x016BC568;

        /// <summary>
        /// Swaps the spawn positions of two players.
        /// </summary>
        /// <param name="playerOne">Index 0-7 of player one.</param>
        /// <param name="playerTwo">Index 0-7 of player two.</param>
        public static void SwapSpawnPositions(int playerOne, int playerTwo)
        {
            var playerOneCopy = RelativeSpawnPosition[playerOne];
            RelativeSpawnPosition[playerOne] = RelativeSpawnPosition[playerTwo];
            RelativeSpawnPosition[playerTwo] = playerOneCopy;
        }
    }
}
