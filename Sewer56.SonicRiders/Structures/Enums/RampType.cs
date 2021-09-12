namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum RampType : byte
    {
        /// <summary>
        /// E.g. First Ramp in Metal City
        /// </summary>
        HorizontalRamp = 0,

        /// <summary>
        /// E.g. Last Ramp in Metal City
        /// </summary>
        VerticalRamp = 1,

        /// <summary>
        /// E.g. Middle of Metal City
        /// </summary>
        QuarterPipe = 3,

        /// <summary>
        /// Ramps which require the user to jump manually
        /// </summary>
        ManualRamp = 4,

        /// <summary>
        /// Trick on big turbulence (Babylon Garden)
        /// </summary>
        TurbulenceTrick = 5,
    }
}