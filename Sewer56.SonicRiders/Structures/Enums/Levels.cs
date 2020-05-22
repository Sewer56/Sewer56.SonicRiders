using System.ComponentModel;

namespace Sewer56.SonicRiders.Structures.Enums
{
    public enum Levels : byte
    {
        /// <summary>
        /// Only exists in GC version, and crashes there.
        /// </summary>
        
        [Description("Test Level")]
        TestLevel = 0,

        [Description("Metal City")]
        MetalCity,

        [Description("Splash Canyon")]
        SplashCanyon,

        [Description("Egg Factory")]
        EggFactory,

        [Description("Green Cave")]
        GreenCave,

        [Description("Sand Ruins")]
        SandRuins,

        [Description("Babylon Garden")]
        BabylonGarden,

        [Description("Digital Dimension")]
        DigitalDimension,

        [Description("SEGA Carnival")]
        SEGACarnival,

        [Description("Night Chase")]
        NightChase,

        [Description("Red Canyon")]
        RedCanyon,

        [Description("Ice Factory")]
        IceFactory,

        [Description("White Cave")]
        WhiteCave,

        [Description("Dark Desert")]
        DarkDesert,

        [Description("Sky Road")]
        SkyRoad,

        [Description("Babylon Guardian")]
        BabylonGuardian,

        [Description("SEGA Illusion")]
        SEGAIllusion,

        [Description("Dual Towers")]
        DualTowers,

        [Description("Snow Valley")]
        SnowValley,

        [Description("Space Theater")]
        SpaceTheater
    }
}
