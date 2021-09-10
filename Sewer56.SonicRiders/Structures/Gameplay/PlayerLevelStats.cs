namespace Sewer56.SonicRiders.Structures.Gameplay
{
    public struct PlayerLevelStats
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

        public int Unknown;

        /// <summary>
        /// Stats inherited from the <see cref="ExtremeGear"/>.
        /// Modified to account for character stats.
        /// </summary>
        public ExtremeGearLevelStats GearStats;
    }
}