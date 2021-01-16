﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using Reloaded.Memory.Kernel32;
using Reloaded.Memory.Pointers;
using Reloaded.Memory.Sources;
using Sewer56.SonicRiders.Internal.DirectX;
using Sewer56.SonicRiders.Structures.Gameplay;

namespace Sewer56.SonicRiders.API
{
    public static unsafe class Misc
    {
        /// <summary>
        /// True if the current process is Sonic Riders, else false.
        /// </summary>
        public static bool IsSonicRiders = Process.GetCurrentProcess().MainModule.ModuleName.Equals("SonicRiders.exe", StringComparison.OrdinalIgnoreCase);

        static Misc()
        {
            try
            {
                // Make rdata and data read/write/execute.
                Memory.CurrentProcess.ChangePermission((IntPtr)0x005AF358, 0x1366CA8, Kernel32.MEM_PROTECTION.PAGE_EXECUTE_READWRITE);
            }
            catch (Exception e)
            {
                // ignored
            }

            DX9Hook = new Lazy<DX9Hook>(() => new DX9Hook(SDK.ReloadedHooks));
        }

        /// <summary>
        /// Relative spawn positions for each player.
        /// </summary>
        public static RefFixedArrayPtr<Vector3> RelativeSpawnPosition = new RefFixedArrayPtr<Vector3>(0x5F8760, Player.MaxNumberOfPlayers);

        /// <summary>
        /// Utility class that allows you to access the DirectX 9 VTable.
        /// </summary>
        public static Lazy<DX9Hook> DX9Hook { get; set; }

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
