using Sewer56.SonicRiders.Utility;

namespace Sewer56.SonicRiders.Structures.Gameplay
{
    /// <summary>
    /// Represents the current race settings.
    /// </summary>
    public struct RaceSettings
    {
        // Bitfield definitions.
        public static readonly BitField LapBitfield         = new BitField(0, 7);
        public static readonly BitField AnnouncerBitfield   = new BitField(8, 1);
        public static readonly BitField ItemBitfield        = new BitField(9, 1);
        public static readonly BitField AirPitBitfield      = new BitField(10, 1);
        public static readonly BitField GhostBitfield       = new BitField(11, 1);
        public static readonly BitField TimeLimitBitfield   = new BitField(12, 7);
        public static readonly BitField UnknownBitfield     = new BitField(19, 4);
        public static readonly BitField NumberOfPointsBitfield = new BitField(23, 8);

        /// <summary>
        /// The underlying value.
        /// </summary>
        public int Value;

        /// <summary>
        /// Sets the number of laps for this race, between 0 and 127.
        /// </summary>
        public byte Laps
        {
            get => (byte) LapBitfield.GetValue(Value);
            set => LapBitfield.SetValue(ref Value, value);
        }

        /// <summary>
        /// Disables/enables the announcer.
        /// </summary>
        public byte Announcer
        {
            get => (byte) AnnouncerBitfield.GetValue(Value);
            set => AnnouncerBitfield.SetValue(ref Value, value);
        }

        /// <summary>
        /// Disables/enables items.
        /// </summary>
        public byte Item
        {
            get => (byte) ItemBitfield.GetValue(Value);
            set => ItemBitfield.SetValue(ref Value, value);
        }

        /// <summary>
        /// Disables/enables pits.
        /// </summary>
        public byte AirPit
        {
            get => (byte) AirPitBitfield.GetValue(Value);
            set => AirPitBitfield.SetValue(ref Value, value);
        }

        /// <summary>
        /// Disables/enables ghosts.
        /// </summary>
        public byte Ghost
        {
            get => (byte) GhostBitfield.GetValue(Value);
            set => GhostBitfield.SetValue(ref Value, value);
        }

        /// <summary>
        /// Disables/enables ghosts.
        /// </summary>
        public byte TimeLimit
        {
            get => (byte) TimeLimitBitfield.GetValue(Value);
            set => TimeLimitBitfield.SetValue(ref Value, value);
        }

        /// <summary>
        /// Disables/enables unknown.
        /// </summary>
        public byte Unknown
        {
            get => (byte) UnknownBitfield.GetValue(Value);
            set => UnknownBitfield.SetValue(ref Value, value);
        }

        /// <summary>
        /// Disables/enables ghosts.
        /// </summary>
        public byte NumberOfPoints
        {
            get => (byte) NumberOfPointsBitfield.GetValue(Value);
            set => NumberOfPointsBitfield.SetValue(ref Value, value);
        }
    }
}