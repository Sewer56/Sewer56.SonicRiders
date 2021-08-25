namespace Sewer56.SonicRiders.Parser.Texture.Structs
{
    /// <summary>
    /// The header used by individual texture files.
    /// </summary>
    public struct TextureHeader
    {
        /// <summary>
        /// The 'GBIX' header.
        /// </summary>
        public GbixHeader Gbix;

        /// <summary>
        /// The 'PVRT' header.
        /// </summary>
        public PvrtHeader Pvrt;
    }
}
