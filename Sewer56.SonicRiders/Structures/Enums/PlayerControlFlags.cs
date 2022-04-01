using System;

namespace Sewer56.SonicRiders.Structures.Enums
{
    [Flags]
    public enum PlayerControlFlags : int
    {
        /// <summary>
        /// Set while the player is touching the ground.
        /// </summary>
        IsFloored = 0x01,

        /// <summary>
        /// Player is currently falling.
        /// </summary>
        Falling = 0x10,

        /// <summary>
        /// Player is currently on a grassy surface.
        /// </summary>
        Grass = 0x40,

        /// <summary>
        /// If set to true, hides the player speed number on the bottom right.
        /// </summary>
        HideSpeed = 0x80,

        /// <summary>
        /// Disables the board trail and hover effect.
        /// </summary>
        NoHoverAndTrail = 0x100,

        /// <summary>
        /// Shows the Hairpin Turn Symbol/HUD element near hairpin turns when the player enters turbulence.
        /// </summary>
        TurbulenceHairpinTurnSymbol = 0x800,

        /// <summary>
        /// Enabled while performing tricks, disables the boost indicator
        /// </summary>
        TrickMode = 0x8000,

        /// <summary>
        /// Triggers a camera backward to forward motion.
        /// (Gives a sense of speed landing a trick)
        /// </summary>
        CameraZoomMotion = 0x20000,

        /// <summary>
        /// Fixes the camera around a certain point.
        /// Seems to only work when in Cinematic Camera Mode?
        /// </summary>
        FixedCamera = 0x40000,

        /// <summary>
        /// The Camera Mode used once you finish a race.
        /// </summary>
        CinematicCamera = 0x80000,

        /// <summary>
        /// Toggled when an attack is landed.
        /// </summary>
        AttackCamera = 0x100000,

        /// <summary>
        /// Toggled while an item box pickup is being rendered to the screen
        /// </summary>
        ItemBoxPickup = 0x200000,

        /// <summary>
        /// Active when the player is in a pit. Removing the flag detaches the player from the pit.
        /// </summary>
        IsInPit = 0x02000000
    }
}
