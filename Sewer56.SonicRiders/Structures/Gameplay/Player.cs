using System;
using System.Collections.Generic;
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
        public GearType GearTypeAnimation_BF;

        /// <summary>
        /// Owned by DirectX?. Written to and accessed every frame.
        /// Increasing this stretches the Characters in an forward direction (X).
        /// </summary>
        [FieldOffset(0xE0)]
        public float RenderThing_StretchForward;

        /// <summary>
        /// Owned by DirectX?. Written to and accessed every frame.
        /// Increasing this stretches the Characters in an upward direction (Y).
        /// </summary>
        [FieldOffset(0xE4)]
        public float RenderThing_StretchUpward;

        /// <summary>
        /// Owned by DirectX?. Written to and accessed every frame.
        /// Increasing this stretches the Characters in a sideways direction (Z).
        /// </summary>
        [FieldOffset(0xE8)]
        public float RenderThing_StretchSideways;

        /// <summary>
        /// Owned by DirectX?. Written to and accessed every frame.
        /// </summary>
        [FieldOffset(0x100)]
        public float RenderPositionX;

        /// <summary>
        /// Owned by DirectX?. Written to and accessed every frame.
        /// </summary>
        [FieldOffset(0x104)]
        public float RenderPositionY;

        /// <summary>
        /// Owned by DirectX?. Written to and accessed every frame.
        /// </summary>
        [FieldOffset(0x108)]
        public float RenderPositionZ;

        [FieldOffset(0x240)]
        public float PositionX;

        [FieldOffset(0x244)]
        public float PositionY;

        [FieldOffset(0x248)]
        public float PositionZ;

        /// <summary>
        /// Measured in Pi. (3.14159265358...)
        /// Full Rotation: 2 Pi
        /// </summary>
        [FieldOffset(0x250)]
        public float RotationVertical;

        /// <summary>
        /// Measured in Pi. (3.14159265358...)
        /// Full Rotation: 2 Pi
        /// </summary>
        [FieldOffset(0x254)]
        public float RotationHorizontal;

        /// <summary>
        /// Measured in Pi. (3.14159265358...)
        /// Full Rotation: 2 Pi
        /// </summary>
        [FieldOffset(0x258)]
        public float PositionRoll;

        /// <summary>
        /// The amount of frames remaining until the individual player's boost ends.
        /// </summary>
        [FieldOffset(0x9D8)]
        public int BoostCountdown;

        /// <summary>
        /// Acceleration, Final Product of Character and Board Acceleration
        /// </summary>
        [FieldOffset(0xA1C)]
        public float Acceleration;

        /// <summary>
        /// Range 0 - 200,000
        /// </summary>
        [FieldOffset(0xAB8)]
        public int Air;

        /// <summary>
        /// Affects initial jump acceleration, rail grinding acceleration, Flight flying acceleration,
        /// start running acceleration, general board movement acceleration.
        /// </summary>
        [FieldOffset(0xBDC)]
        public float GeneralAcceleration;

        /// <summary>
        /// Speed, what is there to say.
        /// </summary>
        [FieldOffset(0xBE0)]
        public float SpeedHorizontal;

        /// <summary>
        /// Goes up if you go down slopes, and down up slopes.
        /// Affected by holding the jump button.
        /// Hard to judge in-game effect.
        /// </summary>
        [FieldOffset(0xBE4)]
        public float Momentum;

        /// <summary>
        /// General Speed Cap
        /// Applies on rails, tricks, during flight, auto/rotate sections and general movement.
        /// </summary>
        [FieldOffset(0xBE8)]
        public float GeneralSpeedCap;

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
