using System;

namespace Sewer56.SonicRiders.Structures.Enums
{
    [Flags]
    public enum ExtremeGearSpecialFlags : int
    {
        /// <summary>
        /// Ignore Turbulence (Heavy Bike)
        /// </summary>
        IgnoreTurbulence = 0x1,

        /// <summary>
        /// Always Perfect Jump (Legend)
        /// </summary>
        AlwaysPerfectJump = 0x2,

        /// <summary>
        /// Massive Oversteering! (Hovercraft)
        /// </summary>
        Oversteering = 0x4,

        /// <summary>
        /// Cannot Boost (Trap Gear, Slide Booster)
        /// </summary>
        CannotBoost = 0x10,

        /// <summary>
        /// Auto Slider (Auto Slider)
        /// </summary>
        AutoSlider = 0x20,

        /// <summary>
        /// No Speed Loss Uphill (Powerful Gear)
        /// </summary>
        NoUphillSpeedLoss = 0x40,

        /// <summary>
        /// Tornadoes Act as Boost (Trap Gear)
        /// </summary>
        TornadoBoostsPlayer = 0x80,

        /// <summary>
        /// No Speed Loss Holding Jump (Hovercraft, Heavy Bike)
        /// </summary>
        NoJumpHoldSpeedLoss = 0x100,

        /// <summary>
        /// Double Ring Winnings at End of Race (Gambler)
        /// </summary>
        DoubleRingWinnings = 0x200,

        /// <summary>
        /// Gear Runs on Rings @ Level 1 (Chaos Emerald/SS, The Crazy)
        /// </summary>
        GearOnRings = 0x400,

        /// <summary>
        /// Boosts do not Perform Attacks (Cannonball)
        /// </summary>
        NerfedBoosts = 0x800,

        /// <summary>
        /// Always Attacking (Berserker)
        /// </summary>
        AlwaysAttacking = 0x1000,

        /// <summary>
        /// Type skills disabled. (Gambler)
        /// </summary>
        SkillsDisabled = 0x2000,

        /// <summary>
        /// Unknown (Chaos Emerald/SS)
        /// </summary>
        Unknown1 = 0x4000,

        /// <summary>
        /// Start with 30% Air (Chaos Emerald/SS)
        /// </summary>
        StartThirtyPercentAir = 0x8000,

        /// <summary>
        /// Start with 50% Air (The Crazy)
        /// </summary>
        StartFiftyPercentAir = 0x10000,

        /// <summary>
        /// Unknown (Powerful Gear)
        /// </summary>
        Unknown2 = 0x20000,

        /// <summary>
        /// Light Board Flag (Light Board)
        /// &gt; Hitting a wall cancels current boost.
        /// &gt; At the end of the current boost, speed is reset to your boosting speed.
        /// &gt; Speed reset to boosting speed is maintained until the player collides with a wall.
        /// </summary>
        LightBoard = 0x40000,

        /// <summary>
        /// Unknown (The Crazy)
        /// </summary>
        Unknown3 = 0x80000
    }
}
