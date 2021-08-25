namespace Sewer56.SonicRiders.Parser.Texture.Structs
{
    public unsafe struct GbixHeader
    {
        /// <summary>
        /// 'GBIX'
        /// </summary>
        public fixed byte Magic[4];

        /// <summary>
        /// Always set to '8'
        /// </summary>
        public int Eight;

        /// <summary>
        /// [Optional] Global shared texture index.
        /// </summary>
        public int GlobalIndex;
        public int Padding;
    }
}
