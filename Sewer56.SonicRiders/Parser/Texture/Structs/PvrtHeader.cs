namespace Sewer56.SonicRiders.Parser.Texture.Structs
{
    public unsafe struct PvrtHeader
    {
        /// <summary>
        /// 'PVRT'
        /// </summary>
        public fixed byte Magic[4];

        /// <summary>
        /// Remaining texture size past this value.
        /// </summary>
        public int TextureSize;

        /// <summary>
        /// 1st byte = Pixel Format,
        /// 2nd byte = Data Format.
        /// </summary>
        public short DataFormat;

        public short unknown;

        /// <summary>
        /// The width of the texture.
        /// </summary>
        public short Width;

        /// <summary>
        /// The height of the texture.
        /// </summary>
        public short Height;
    }
}
