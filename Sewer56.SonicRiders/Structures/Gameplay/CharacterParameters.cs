using Sewer56.SonicRiders.Structures.Enums;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    public struct CharacterParameters
    {
        /// <summary>
        /// The character stats used for determining what shortcut the character can take.
        /// </summary>
        public CharacterType ShortcutType;

        /// <summary>
        /// The character stats used for determining what stats the character should use.
        /// </summary>
        public CharacterType StatsType;

        private byte pad_0;

        /// <summary>
        /// Letter used in the file name for this character's models.
        /// This is a single ascii letter.
        /// </summary>
        public byte FileNameLetter;

        /// <summary>
        /// The character's gender.
        /// </summary>
        public Gender Gender;

        /// <summary>
        /// The character's height (affects camera).
        /// </summary>
        public float Height;

        /// <summary>
        /// The character's speed multiplier (inversely affects accel).
        /// This value is relative to 0, so for 98% use -0.02.
        /// </summary>
        public float SpeedMultiplier;

        public byte StatDashLv1;
        public byte StatDashLv2;
        public byte StatDashLv3;

        public byte StatLimitLv1;
        public byte StatLimitLv2;
        public byte StatLimitLv3;

        public byte StatPowerLv1;
        public byte StatPowerLv2;
        public byte StatPowerLv3;

        public byte StatCorneringLv1;
        public byte StatCorneringLv2;
        public byte StatCorneringLv3;

        private byte pad_1;
    }
}