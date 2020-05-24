using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Sewer56.SonicRiders.Structures.Enums;
using Sewer56.SonicRiders.Structures.Input;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Explicit, Size = 0x1200)]
    public unsafe struct Player
    {
        /// <summary>
        /// Hardcoded number of players in game code.
        /// </summary>
        public const int NumberOfPlayers = 8;

        /// <summary>
        /// Pointer to the player input structure for the current player.
        /// </summary>
        [FieldOffset(0x00)]
        public PlayerInput* PlayerInput;

        /// <summary>
        /// The character currently assigned to the player.
        /// </summary>
        [FieldOffset(0xBA)]
        public Characters Character;

        /// <summary>
        /// The extreme gear that is currently assigned to the player.
        /// </summary>
        [FieldOffset(0xBB)]
        public Enums.ExtremeGear ExtremeGear;

        /// <summary>
        /// Toggles showing of tricks, trail/dirt visuals, enables/disables AI Inputs.
        /// </summary>
        [FieldOffset(0xBC)]
        public PlayerType PlayerController;

        /// <summary>
        /// Toggles 1P/2P etc indicators and map rendering in proximity of character.
        /// </summary>
        [FieldOffset(0xBD)]
        public PlayerType PlayerType;

        /// <summary>
        /// Crashes if changed in race.
        /// </summary>
        [FieldOffset(0xBE)]
        public GearType GearType;

        /// <summary>
        /// Controls the animations used for the current gear type.
        /// </summary>
        [FieldOffset(0xBF)]
        public GearType GearTypeAnimation;

        /// <summary>
        /// Controls the rotation of the character. This is a normalized "up" vector.
        /// Used by DirectX?
        /// </summary>
        [FieldOffset(0xE0)]
        public Vector3 RenderRotation;

        /// <summary>
        /// The position the character is rendered at.
        /// Used by DirectX.
        /// </summary>
        [FieldOffset(0x100)]
        public Vector3 RenderPosition;

        /// <summary>
        /// X,Y,Z Positions of the current player.
        /// </summary>
        [FieldOffset(0x240)]
        public Vector3 Position;

        /// <summary>
        /// X is vertical, Y is horizontal, Z is roll
        /// Measured in Pi. (3.14159265358...)
        /// Full Rotation: 2 Pi
        /// </summary>
        [FieldOffset(0x250)]
        public Vector3 Rotation;

        /// <summary>
        /// The amount of frames remaining until the individual player's boost ends.
        /// </summary>
        [FieldOffset(0x9D8)]
        public int BoostFramesLeft;

        /// <summary>
        /// Acceleration.
        /// Final Product of Character and Board Acceleration
        /// Affects speeds from 0 to 140. (Speed Type, Default Gear)
        /// </summary>
        [FieldOffset(0xA1C)]
        public float AccelerationThreshold1;

        /// <summary>
        /// Acceleration.
        /// Final Product of Character and Board Acceleration
        /// Affects speeds from 140 to Top Speed. (Speed Type, Default Gear)
        /// </summary>
        [FieldOffset(0xA20)]
        public float AccelerationThreshold2;

        /// <summary>
        /// Acceleration.
        /// Final Product of Character and Board Acceleration
        /// Affects speeds from Top Speed to Beyond. (Speed Type, Default Gear)
        /// </summary>
        [FieldOffset(0xA24)]
        public float AccelerationThreshold3;

        /// <summary>
        /// Range 0 - 200,000
        /// </summary>
        [FieldOffset(0xAB8)]
        public int Air;

        /// <summary>
        /// The vertical speed in the upwards direction.
        /// </summary>
        [FieldOffset(0xBD8)]
        public float VSpeed;

        /// <summary>
        /// The current acceleration of the character in the horizontal direction.
        /// Set by jump, rail grinding, flight, running, board movement.
        /// </summary>
        [FieldOffset(0xBDC)]
        public float Acceleration;

        /// <summary>
        /// The speed in the current forward direction determined by X,Y,Z rotation.
        /// </summary>
        [FieldOffset(0xBE0)]
        public float Speed;

        /// <summary>
        /// Indicates player's relative speed to top speed.
        /// </summary>
        [FieldOffset(0xBE4)]
        public float PercentageTopSpeed;

        /// <summary>
        /// General Speed Cap.
        /// Applies on rails, tricks, during flight, auto/rotate sections and general movement.
        /// </summary>
        [FieldOffset(0xBE8)]
        public float SpeedCap;

        [FieldOffset(0xCCC)]
        public int Rings;

        /// <summary>
        /// [Flags]
        /// Seems to be affected by both player actions such as e.g. grinding on a rail but also 
        /// other settings and parameters e.g. whether to use cinematic camera.
        /// </summary>
        [FieldOffset(0xCDC)]
        public PlayerDisplayFlags PlayerDisplayFlags;

        /// <summary>
        /// The player's current lap counter.
        /// </summary>
        [FieldOffset(0x11B2)]
        public byte LapCounter;

        /// <summary>
        /// Contains the current state of the player.
        /// </summary>
        [FieldOffset(0x11BC)]
        public PlayerState PlayerState;

        /// <summary>
        /// Contains the last state of the player.
        /// </summary>
        [FieldOffset(0x11BD)]
        public PlayerState LastPlayerState;

        /// <summary>
        /// Unconfirmed.
        /// Places various restrictions to gameplay on the individual player.
        /// </summary>
        [FieldOffset(0x11BF)]
        public PlayerRestrictions PlayerRestrictions;
    }
}
