using System.Numerics;
using System.Runtime.InteropServices;
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
        public PlayerType IsAiLogic;

        /// <summary>
        /// Toggles 1P/2P etc indicators and map rendering in proximity of character.
        /// </summary>
        [FieldOffset(0xBD)]
        public PlayerType IsAiVisual;

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
        /// Controls the rotation of the character. This is sometimes used instead of the other one?
        /// </summary>
        [FieldOffset(0xD0)]
        public Vector3 RenderRotationAlt;

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
        /// Position difference between the current player and another player when the player becomes attacked.
        /// </summary>
        [FieldOffset(0x3C0)]
        public Vector3 AttackedByPosOffset;

        /// <summary>
        /// Unknown state. Set after attacking. Can disable attacks.
        /// </summary>
        [FieldOffset(0x7B8)]
        public PlayerState MaybeAttackLastState;

        [FieldOffset(0x860)]
        public CharacterAnimation LastAnimation;

        [FieldOffset(0x864)]
        public CharacterAnimation Animation;

        /// <summary>
        /// Frame counter for the current animation.
        /// Generally counts up to 60.
        /// </summary>
        [FieldOffset(0x870)]
        public float AnimationFramecounter;

        /// <summary>
        /// Frame counter for the last animation.
        /// Generally counts up to 60.
        /// </summary>
        [FieldOffset(0x874)]
        public float LastAnimationFramecounter;

        /// <summary>
        /// Scale 0.0 to 1.0
        /// </summary>
        [FieldOffset(0x878)]
        public float AnimationInterpolationProgress;

        /// <summary>
        /// How fast animation interpolates up to 1.0.
        /// See <see cref="AnimationInterpolationProgress"/>
        /// </summary>
        [FieldOffset(0x880)]
        public float AnimationInterpolationIncreaseRate;

        /// <summary>
        /// The ratio between the old and the new animation.
        /// See <see cref="AnimationInterpolationProgress"/>
        /// </summary>
        [FieldOffset(0x884)]
        public float AnimationInterpolationRatio;

        /// <summary>
        /// Speed set to the player after they are attacked.
        /// </summary>
        [FieldOffset(0x9D4)]
        public float AttackEndSpeed;

        [FieldOffset(0x96C)]
        public float float_96C;

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
        /// Range 0 - 200,000
        /// </summary>
        [FieldOffset(0xABC)]
        public int AirGainedThisFrame;

        /// <summary>
        /// Movement flags for the current frame.
        /// </summary>
        [FieldOffset(0xB5C)]
        public MovementFlags MovementFlags;

        /// <summary>
        /// Movement flags for the last frame.
        /// </summary>
        [FieldOffset(0xB60)]
        public MovementFlags LastMovementFlags;

        /// <summary>
        /// Movement of analog on X axis.
        /// Range -100 to 100
        /// </summary>
        [FieldOffset(0xB6C)]
        public sbyte AnalogX;

        /// <summary>
        /// Movement of analog on Y axis.
        /// Range -100 to 100
        /// </summary>
        [FieldOffset(0xB6D)]
        public sbyte AnalogY;

        /// <summary>
        /// Pressure on the trigger button(s).
        /// </summary>
        [FieldOffset(0xB6E)]
        public byte TriggerPressure;

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

        /// <summary>
        /// Copy of <see cref="DriftAngle"/>, purpose unknown.
        /// </summary>
        [FieldOffset(0xC54)]
        public float DriftAngleCopy;

        /// <summary>
        /// The current angle at which the character is drifting.
        /// </summary>
        [FieldOffset(0xC58)]
        public float DriftAngle;

        /// <summary>
        /// The current amount by which the player is turning.
        /// </summary>
        [FieldOffset(0xC60)]
        public float TurningAmount;

        [FieldOffset(0xCCC)]
        public int Rings;

        /// <summary>
        /// Current player checkpoint progression where 10000 represents every stage checkpoint.
        /// </summary>
        [FieldOffset(0xCF8)]
        public float CheckpointProgression;

        /// <summary>
        /// Current player checkpoint progression where 10000 represents every stage checkpoint.
        /// </summary>
        [FieldOffset(0xCFC)]
        public float CheckpointProgressionCopy;

        /// <summary>
        /// Various seemingly unrelated flags which control current player state.
        /// Affects things such as if speedometer is shown or what the camera is doing.
        /// </summary>
        [FieldOffset(0xCDC)]
        public PlayerControlFlags PlayerControlFlags;

        /// <summary>
        /// Pointer to the player which the player is currently being attacked by.
        /// </summary>
        [FieldOffset(0x10C0)]
        public Player* PtrAttackedBy;

        /// <summary>
        /// Pointer to the player the player is currently attacking.
        /// </summary>
        [FieldOffset(0x10C4)]
        public Player* PtrAttacking;

        /// <summary>
        /// The player's time in which they finished the race.
        /// </summary>
        [FieldOffset(0x117C)]
        public Timer FinishTime;

        /// <summary>
        /// The player's current lap counter.
        /// </summary>
        [FieldOffset(0x11B2)]
        public byte LapCounter;

        /// <summary>
        /// The player's current placement in the race.
        /// </summary>
        [FieldOffset(0x11B4)]
        public byte RacePosition;

        /// <summary>
        /// Current player level. Auto-set by game depending on player's ring counter.
        /// </summary>
        [FieldOffset(0x11B6)]
        public byte Level;

        /// <summary>
        /// Current mode of falling from the air.
        /// </summary>
        [FieldOffset(0x11B7)]
        public FallingMode FallingMode;

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
