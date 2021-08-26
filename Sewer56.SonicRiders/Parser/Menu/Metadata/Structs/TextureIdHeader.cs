namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    /// <summary>
    /// Header for the texture index section.
    /// </summary>
    public unsafe struct TextureIdHeader
    {
        /// <summary>
        /// Number of textures in this section.
        /// </summary>
        public int NumTextures;

        /// <summary>
        /// Unknown.
        /// </summary>
        public int unknown;

        /// <summary>
        /// Gets the pointer to the inline array of entries.
        /// </summary>
        /// <param name="thisItem">The address of this item.</param>
        public TextureIdEntry* GetEntryPointer(TextureIdHeader* thisItem) => (TextureIdEntry*)(thisItem + 1);
    }
}