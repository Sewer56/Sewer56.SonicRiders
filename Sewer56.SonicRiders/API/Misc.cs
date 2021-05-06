using System;
using System.Numerics;
using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.Internal.DirectX;

namespace Sewer56.SonicRiders.API
{
    public static unsafe class Misc
    {
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
        /// Horizontal resolution of the game (as configured in launcher).
        /// </summary>
        public static float* AspectRatio2dResolutionX = (float*)0x005B0228;

        /// <summary>
        /// Horizontal resolution of the game (as configured in launcher).
        /// </summary>
        public static float* AspectRatio2dResolutionY = (float*)0x005B022C;

        /// <summary>
        /// Whether fullscreen is set to on.
        /// </summary>
        public static bool* Fullscreen = (bool*)0x016BCD38;

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
