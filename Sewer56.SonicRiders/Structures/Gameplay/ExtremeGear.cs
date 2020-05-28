using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Sewer56.SonicRiders.Structures.Enums;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
    public struct ExtremeGear
    {
        /// <summary>
        /// Determines who can select this specific extreme gear in question.
        /// </summary>
        [FieldOffset(0x0)]
        public CharactersFlags WhoCanSelect;

        /// <summary>
        /// Controls animations.
        /// Tends to crash if changed.
        /// </summary>
        [FieldOffset(0x4)]
        public GearType GearType;

        /// <summary>
        /// The model used for the current extreme gear.
        /// </summary>
        [FieldOffset(0x5)]
        public Enums.ExtremeGearModel GearModel;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The acceleration of the current extreme gear.
        /// </summary>
        [FieldOffset(0xC)]
        public float Acceleration;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The speed multiplier for this board with which handling is adjusted proportionally.
        /// </summary>
        [FieldOffset(0x10)]
        public float SpeedHandlingMultiplier;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// Affects acceleration/speed when the character goes off-road.
        /// </summary>
        [FieldOffset(0x14)]
        public float Field_14;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The same as the speed and handling multiplier, does not affect handling, thus making it harder to steer at high speeds.
        /// This value however multiplies the final speed after it's been processed by the character and <see cref="SpeedHandlingMultiplier"/>.
        /// </summary>
        [FieldOffset(0x18)]
        public float SpeedMultiplier;

        /// <summary>
        /// Allows the board wielder to grind/fly/punch.
        /// </summary>
        [FieldOffset(0x20)]
        public FormationTypesFlags ExtraTypes;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The same as the speed and handling multiplier, does not
        /// affect handling, thus making it harder to steer at high speeds.
        /// </summary>
        [FieldOffset(0x28)]
        public float TurnLowSpeedMultiplier;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The acceleration used on turning, determines how fast the maximum turn radius is reached.
        /// </summary>
        [FieldOffset(0x2C)]
        public float TurnAcceleration;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The maximum the character can turn.
        /// </summary>
        [FieldOffset(0x30)]
        public float TurnMaxRadius;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The maximum the character can turn while drifting.
        /// </summary>
        [FieldOffset(0x34)]
        public float DriftMaximumTurnRadius;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// How much your momentum follows you during a drift.
        /// (Basically how much your current angle and velocity affects the drift by decreasing
        /// how much you can turn. Higher = turn less).
        /// </summary>
        [FieldOffset(0x38)]
        public float DriftMomentum;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// The minimum radius/angle that the character can drift at.
        /// Low values allow player to transfer drift to other side, or drift straight.
        /// </summary>
        [FieldOffset(0x3C)]
        public float DriftMinimumRadius;

        /// <summary>
        /// [Offset, Base Gear = 0]
        /// How fast the player can transfer between the minimum and maximum turning radius.
        /// Values too low can lead to the arrow keys/analog being reversed.
        /// </summary>
        [FieldOffset(0x40)]
        public float DriftAcceleration;

        /// <summary>
        /// [Offset] How many frames to add to the default drift dash time (60 frames).
        /// e.g. A value of 0 means it takes 60 frames of drift to boost.
        /// A value of -60 allows you to boost instantly by starting and letting off drift.
        /// </summary>
        [FieldOffset(0x50)]
        public int DriftBoostFramesOffset;

        /// <summary>
        /// Air gain multiplier (tricks).
        /// This value is an offset from 1.00 (100%), thus setting -0.05 would cause tricks
        /// to give 95% air.
        /// </summary>
        [FieldOffset(0x54)]
        public float AirGainTrickMultiplier;

        /// <summary>
        /// Air gain multiplier (shortcuts)
        /// This value is an offset from 1.00 (100%), thus setting -0.05 would cause shortcuts to give 95% air.
        /// </summary>
        [FieldOffset(0x58)]
        public float AirGainShortcutMultiplier;

        /// <summary>
        /// Air gain multiplier (control stick event)
        /// This value is an offset from 1.00 (100%), thus setting -0.05 would cause control stick events to give 95% air.
        /// </summary>
        [FieldOffset(0x5C)]
        public float AirGainAutorotateMultiplier;

        /// <summary>
        /// Default Value = 2 (200% Passive Drain)
        /// Air cost multiplier when charging jump.
        /// Multiplies the air cost of passive air drain when the jump button is held.
        /// </summary>
        [FieldOffset(0x60)]
        public ExtremeGearSpecialFlags SpecialFlags;

        /// <summary>
        /// Default Value = 2 (200% Passive Drain)
        /// Air cost multiplier when charging jump.
        /// Multiplies the air cost of passive air drain when the jump button is held.
        /// </summary>
        [FieldOffset(0x64)]
        public float JumpAirMultiplier;

        /// <summary>
        /// Gear Stats for Level 1.
        /// </summary>
        [FieldOffset(0x68)]
        public ExtremeGearLevelStats GearStatsLevel1;

        /// <summary>
        /// Gear Stats for Level 2.
        /// </summary>
        [FieldOffset(0x84)]
        public ExtremeGearLevelStats GearStatsLevel2;

        /// <summary>
        /// Gear Stats for Level 3.
        /// </summary>
        [FieldOffset(0xA0)]
        public ExtremeGearLevelStats GearStatsLevel3;

        /// <summary>
        /// Offset for the default, shown in menu dash stat.
        /// </summary>
        [FieldOffset(0xBC)]
        public sbyte StatDashOffset;

        /// <summary>
        /// Offset for the default, shown in menu limit stat..
        /// </summary>
        [FieldOffset(0xBD)]
        public sbyte StatLimitOffset;

        /// <summary>
        /// Offset for the default, shown in menu power stat..
        /// </summary>
        [FieldOffset(0xBE)]
        public sbyte StatPowerOffset;

        /// <summary>
        /// Offset for the default, shown in menu cornering stat..
        /// </summary>
        [FieldOffset(0xBF)]
        public sbyte StatCorneringOffset;

        [FieldOffset(0xC8)]
        public float ExhaustTrail1Width;

        [FieldOffset(0xCC)]
        public float ExhaustTrail2Width;

        [FieldOffset(0x108)]
        public Vector3 ExhaustTrail1PositionOffset;

        [FieldOffset(0x114)]
        public Vector3 ExhaustTrail2PositionOffset;

        [FieldOffset(0x14C)]
        public float ExhaustTrail1TrickWidth;

        [FieldOffset(0x150)]
        public float ExhaustTrail2TrickWidth;

        [FieldOffset(0x18C)]
        public Vector3 ExhaustTrail1TrickOffset;

        [FieldOffset(0x198)]
        public Vector3 ExhaustTrail2TrickOffset;
    }
}
