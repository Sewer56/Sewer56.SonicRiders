using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using Reloaded.Memory.Kernel32;
using Reloaded.Memory.Pointers;
using Reloaded.Memory.Sources;
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
            if (IsSonicRiders)
            {
                Memory.CurrentProcess.ChangePermission((IntPtr)RelativeSpawnPosition.Pointer, sizeof(Vector3) * Player.MaxNumberOfPlayers, Kernel32.MEM_PROTECTION.PAGE_EXECUTE_READWRITE);
            }
        }

        /// <summary>
        /// Relative spawn positions for each player.
        /// </summary>
        public static RefFixedArrayPtr<Vector3> RelativeSpawnPosition = new RefFixedArrayPtr<Vector3>(0x5F8760, Player.MaxNumberOfPlayers);

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
