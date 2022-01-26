namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    /// <summary>
    /// Represents an individual entry of the Menu Metadata format.
    /// </summary>
    public unsafe struct Object
    {
        /// <summary>
        /// The amount of layers in this entry.
        /// </summary>
        public int LayerCount;
        
        /// <summary>
        /// Total size of this object, including this header.
        /// </summary>
        public int ObjectSize;
        
        /*
            After this struct in memory follow pointers to individual entries.
            If the file is not loaded, it is an offset from the start of this header.
            If the file is loaded, it they are pointers to the actual entries.
        */

        /// <summary>
        /// Gets a pointer to a given layer.
        /// </summary>
        /// <returns>A pointer to a layer, which can be a regular or an action layer.</returns>
        public Layer* GetLayerPointer(Object* thisHeader, int index)
        {
            var pointers = (uint*)(thisHeader + 1);
            return (Layer*)pointers[index];
        }
    }
}