namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{    
    /// <summary>
    /// Individual entry in the Texture section.
    /// </summary>
    public class Texture
    {
        public short Unknown { get; set; }

        /// <summary>
        /// Index inside the xvrs texture archive.
        /// </summary>
        public short XvrsTextureId { get; set; }

        /// <summary>
        /// Top Left Corner. 0-1
        /// </summary>
        public float NormalizedPosX { get; set; }

        /// <summary>
        /// Top Left Corner. 0-1
        /// </summary>
        public float NormalizedPosY { get; set; }

        /// <summary>
        /// 0-1 Where 1 represents the whole width of the texture.
        /// </summary>
        public float NormalizedWidth { get; set; }

        /// <summary>
        /// 0-1 Where 1 represents the whole height of the texture.
        /// </summary>
        public float NormalizedHeight { get; set; }
    }
}
