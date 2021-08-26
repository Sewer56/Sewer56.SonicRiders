namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    public struct SubEntry
    {
        /// <summary>
        /// Unknown. Might be the layer.
        /// </summary>
        public short MaybeLayer;

        /// <summary>
        /// 0x0 - 0xF Color (Bit 0-4)
        /// 0x10 - 0xF0 Alpha (Bit 4-8)
        /// </summary>
        public short UnknownColorFlags;

        /// <summary>
        /// Setting to 1 skews image; non 0/1 crash.
        /// </summary>
        public short MaybeFormatOrKeyframe;

        /// <summary>
        /// Changed to 0 at runtime
        /// </summary>
        public short MaybeIsLoadedFlag;
        
        /// <summary>
        /// Might be number of vertices.
        /// </summary>
        public short MaybeNumVertices;
        
        /// <summary>
        /// Index of the texture used for this menu item.
        /// </summary>
        public short TextureIndex;

        /// <summary>
        /// ONLY VALID WHEN <see cref="MaybeFormatOrKeyframe"/> is greater than 0.
        /// </summary>
        public SubEntryEx Extra;
    }
}