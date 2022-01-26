namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    /// <summary>
    /// Individual entry in the Texture Id section.
    /// </summary>
    public struct TextureEntry
    {
        public short Unknown;

        /// <summary>
        /// Index inside the xvrs texture archive.
        /// </summary>
        public short XvrsTextureId;

        /// <summary>
        /// Top Left Corner. 0-1
        /// </summary>
        public float NormalizedPosX;

        /// <summary>
        /// Top Left Corner. 0-1
        /// </summary>
        public float NormalizedPosY;

        /// <summary>
        /// 0-1 Where 1 represents the whole width of the texture.
        /// </summary>
        public float NormalizedWidth;

        /// <summary>
        /// 0-1 Where 1 represents the whole height of the texture.
        /// </summary>
        public float NormalizedHeight;
    }
}