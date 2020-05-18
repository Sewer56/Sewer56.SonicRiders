using System.Runtime.InteropServices;
using Sewer56.SonicRiders.Structures.Input.Enums;

namespace Sewer56.SonicRiders.Structures.Input
{
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct PlayerInput
    {
        /// <summary>
        /// <see cref="CountFromThreePerSecond"/> ticks every this number of frames.
        /// </summary>
        public const int TickPeriodFrames = 15;

        /// <summary>
        /// Continually counts up in frames, overflows and does it again.
        /// Resets when a button is pressed or released.
        /// </summary>
        [FieldOffset(0x0)]
        public int FrameCounter;

        /// <summary>
        /// Decrements from 3 to 0 within around a second.
        /// </summary>
        [FieldOffset(0x4)]
        public int CountFromThreePerSecond;

        /// <summary>
        /// The currently pressed buttons.
        /// </summary>
        [FieldOffset(0x8)]
        public Buttons Buttons;

        /// <summary>
        /// Buttons that were newly pressed this frame.
        /// </summary>
        [FieldOffset(0xC)]
        public Buttons ButtonsPressed;

        /// <summary>
        /// Buttons that were released this frame.
        /// </summary>
        [FieldOffset(0x10)]
        public Buttons ButtonsReleased;

        /// <summary>
        /// When <see cref="CountFromThreePerSecond"/> is 0, is equal to <see cref="Buttons"/>
        /// Probably used for menu navigation.
        /// </summary>
        [FieldOffset(0x14)]
        public Buttons Flicker;

        /// <summary>
        /// Range = -100 to 100
        /// </summary>
        [FieldOffset(0x18)]
        public sbyte AnalogStickX;

        /// <summary>
        /// Range = -100 to 100
        /// </summary>
        [FieldOffset(0x19)]
        public sbyte AnalogStickY;

        /// <summary>
        /// Range = 0 - 255
        /// </summary>
        [FieldOffset(0x1A)]
        public byte LeftBumperPressure;

        /// <summary>
        /// Range = 0 - 255
        /// </summary>
        [FieldOffset(0x1B)]
        public byte RightBumperPressure;

        /// <summary>
        /// Always 1. Can be set to 0 if wrong controller type.
        /// </summary>
        [FieldOffset(0x28)]
        public int ProbablyIsEnabled;


        /*
            ------------------
            Functions (Public)
            ------------------
        */

        /// <summary>
        /// Before submitting back to game, completes the remaining members of the struct
        /// that are dependent on knowing the inputs from the previous frame.
        /// </summary>
        /// <param name="last">The inputs from the last frame.</param>
        /// <param name="frameCounter">
        ///     (Optional) A frame counter which should be reset every 15 frames.
        ///     Controller code does a "tick" every ~15 frames.
        /// </param>
        public void Finalize(ref PlayerInput last, int frameCounter)
        {
            // In order to allow for QTE and to mimic game's own behaviour.
            // Set up/down/left/right if analog stick is tilted enough.
            if (AnalogStickX > 50)
                Buttons |= Buttons.Right;

            if (AnalogStickX < -50)
                Buttons |= Buttons.Left;

            if (AnalogStickY > 50)
                Buttons |= Buttons.Up;

            if (AnalogStickY < -50)
                Buttons |= Buttons.Down;

            if (Buttons.HasFlag(Buttons.LeftDrift))
                LeftBumperPressure = 255;

            if (Buttons.HasFlag(Buttons.RightDrift))
                RightBumperPressure = 255;

            CountFromThreePerSecond = last.CountFromThreePerSecond;
            ButtonsReleased = GetReleasedButtons(last.Buttons, Buttons);
            ButtonsPressed  = GetPressedButtons(last.Buttons, Buttons);

            // Reset no state change frame counter.
            if (ButtonsPressed != Buttons.Null || ButtonsReleased != Buttons.Null)
            {
                FrameCounter = 0;
                CountFromThreePerSecond = 3;
            }
            else
            {
                FrameCounter = last.FrameCounter + 1;
            }

            // This is the best replica I can make of the game's own variable.
            Flicker |= ButtonsPressed;
            if (FrameCounter > 45 && frameCounter % 5 == 0)
            {
                Flicker = Buttons;
            }

            // Wonder if this will work.
            // What this part does in game code is a bit of a mystery.
            if (frameCounter >= TickPeriodFrames)
            {
                CountFromThreePerSecond -= 1;
                if (CountFromThreePerSecond < 0)
                {
                    CountFromThreePerSecond = 3;
                }
            }


            // To the best of my knowledge.
            ProbablyIsEnabled = 1;
        }

        /*
            -------------------
            Functions (Private)
            -------------------
        */

        /// <summary>
        /// Returns the buttons that have been pressed <see cref="before"/> but not pressed <see cref="after"/>.
        /// </summary>
        public Buttons GetReleasedButtons(Buttons before, Buttons after)
        {
            // Return B and NOT A
            // "Return those before without the ones after"
            return before & (~after);
        }

        /// <summary>
        /// Returns the buttons that have been pressed in <see cref="after"/> but not pressed <see cref="before"/>.
        /// </summary>
        public Buttons GetPressedButtons(Buttons before, Buttons after)
        {
            // Return A and NOT B
            // "Return those after without the ones before"
            return after & (~before);
        }
    }
}
