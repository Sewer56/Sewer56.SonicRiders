using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Sewer56.SonicRiders.Structures.Input.Enums;

namespace Sewer56.SonicRiders.Structures.Input
{
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct PlayerInput
    {
        /// <summary>
        /// Continually counts up in frames, overflows and does it again.
        /// Resets when a button is pressed or released.
        /// </summary>
        [FieldOffset(0x0)]
        public int FrameCounter;

        /// <summary>
        /// Changes a lot between 0 and 3.
        /// </summary>
        [FieldOffset(0x4)]
        public int Field_04;

        [FieldOffset(0x8)]
        public short Field_08;

        [FieldOffset(0xA)]
        public Buttons Buttons;

        /// <summary>
        /// Sets new pressed button value at 0x08 for 1 frame on 
        /// input then flickers with inputs.
        /// </summary>
        [FieldOffset(0x14)]
        public Buttons Field_14;

        /// <summary>
        /// Range = 0 - 255
        /// </summary>
        [FieldOffset(0x18)]
        public byte LeftBumperPressure;

        /// <summary>
        /// Range = 0 - 255
        /// </summary>
        [FieldOffset(0x19)]
        public byte RightBumperPressure;

        /// <summary>
        /// Range = -100 to 100
        /// </summary>
        [FieldOffset(0x1A)]
        public sbyte AnalogStickX;

        /// <summary>
        /// Range = -100 to 100
        /// </summary>
        [FieldOffset(0x1B)]
        public sbyte AnalogStickY;
    }
}
