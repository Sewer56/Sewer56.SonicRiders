﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    public struct RunningPhysics2
    {
        /// <summary>
        /// The maximum speed until a switch to gear 2 is performed.
        /// </summary>
        public float GearOneMaxSpeed;

        /// <summary>
        /// The maximum speed of gear 2.
        /// </summary>
        public float GearTwoMaxSpeed;

        /// <summary>
        /// Defines the speed limit for gear 2.
        /// </summary>
        public float MaxSpeed;

        /// <summary>
        /// Defines the acceleration of gear 1.
        /// </summary>
        public float GearOneAcceleration;

        /// <summary>
        /// Defines the acceleration of gear 2.
        /// </summary>
        public float GearTwoAcceleration;

        /// <summary>
        /// Defines the acceleration of gear 3. (When exceeding gearTwoMaxSpeed)
        /// </summary>
        public float GearThreeAcceleration;

        /// <summary>
        /// Unknown
        /// </summary>
        public float Field_18;
    }
}
