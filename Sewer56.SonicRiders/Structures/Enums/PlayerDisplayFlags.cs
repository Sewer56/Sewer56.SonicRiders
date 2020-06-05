using System;

namespace Sewer56.SonicRiders.Structures.Enums
{
    [Flags]
    public enum PlayerDisplayFlags : int
    {
        /// <summary>
        /// If set to true, hides the player speed number on the bottom right.
        /// </summary>
        HideSpeed = 0x80,

        /// <summary>
        /// Notably disables the board trail.
        /// Enables the animations used for running before crossing the start line.
        /// </summary>
        RunningAnimationMode = 0x100,

        /// <summary>
        /// Shows the Hairpin Turn Symbol/HUD element near hairpin turns.
        /// </summary>
        HairpinTurnSymbol = 0x800,

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
        CinematicCamera = 0x80000
    }
}
