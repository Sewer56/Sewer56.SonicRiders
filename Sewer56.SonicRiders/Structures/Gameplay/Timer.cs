using System;
using System.Runtime.CompilerServices;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    public struct Timer
    {
        public byte Milliseconds;
        public byte Seconds;
        public byte Minutes;
        public byte Unused;

        public Timer(byte milliseconds, byte seconds, byte minutes)
        {
            Milliseconds = milliseconds;
            Seconds = seconds;
            Minutes = minutes;
            Unused = 0;
        }

        public TimeSpan ToTimeSpan() => new TimeSpan(0, 0, Minutes, Seconds, Milliseconds);
        public static Timer FromTimeSpan(TimeSpan span) => new Timer((byte)(span.Milliseconds / 10), (byte)span.Seconds, (byte)span.Minutes);

        public static implicit operator Timer(int integer) => Unsafe.As<int, Timer>(ref integer);
        public static implicit operator int(Timer timer) => Unsafe.As<Timer, int>(ref timer);
    }
}
