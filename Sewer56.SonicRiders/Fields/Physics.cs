using System;
using System.Collections.Generic;
using System.Text;
using Sewer56.SonicRiders.Structures.Gameplay;

namespace Sewer56.SonicRiders.Fields
{
    /// <summary>
    /// Grants you control over various physics aspects of the game, such as running, jumping
    /// mechanics.
    /// </summary>
    public static unsafe class Physics
    {
        /// <summary>
        /// The first set of Running Physics values.
        /// See <see cref="RunningPhysics2"/> for the rest.
        /// </summary>
        public static readonly RunningPhysics* RunningPhysics1 = (RunningPhysics*) 0x005C30F8;

        /// <summary>
        /// The second set of Running Physics values.
        /// See <see cref="RunningPhysics1"/> for the rest.
        /// </summary>
        public static readonly RunningPhysics2* RunningPhysics2 = (RunningPhysics2*) 0x0065C534;
    }
}
