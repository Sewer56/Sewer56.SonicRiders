using System.Runtime.InteropServices;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CharacterTypeLevelStats
    {
        /// <summary>
        /// Speed cap #1.
        /// </summary>
        public float SpeedCap1;

        /// <summary>
        /// Speed cap #2.
        /// </summary>
        public float SpeedCap2;

        /// <summary>
        /// Speed cap #3.
        /// Also boost speed cap.
        /// </summary>
        public float SpeedCap3;

        /// <summary>
        /// Acceleration between 0 and <see cref="SpeedCap1"/>.
        /// </summary>
        public float AccelToSpeedCap1;

        /// <summary>
        /// Acceleration between <see cref="SpeedCap1"/> and <see cref="SpeedCap2"/>.
        /// </summary>
        public float AccelToSpeedCap2;

        /// <summary>
        /// Acceleration between <see cref="SpeedCap2"/> and infinity.
        /// </summary>
        public float AccelToSpeedCap3;

        public float Offroad;
    }
}