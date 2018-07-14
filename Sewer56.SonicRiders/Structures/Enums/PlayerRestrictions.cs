using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum PlayerRestrictions : byte
    {
        /// <summary>
        /// Apply restrictions normally given when the player is in the air.
        /// </summary>
        Airborne = 0x01,

        /// <summary>
        /// Disallow Drifting, Jumping (Pre-Start Line Restrictions)
        /// </summary>
        Running = 0x02
    }
}
