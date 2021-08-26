namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    /// <summary>
    /// Represents an individual entry of the Menu Metadata format.
    /// </summary>
    public unsafe struct Entry
    {
        /// <summary>
        /// The amount of sub entries in this entry.
        /// </summary>
        public int SubEntryCount;
        
        /// <summary>
        /// Total size of the entry, including this header.
        /// </summary>
        public int TotalEntrySize;
        
        /*
            After this struct in memory follow pointers to individual entries.
            If the file is not loaded, it is an offset from the start of this header.
            If the file is loaded, it they are pointers to the actual entries.
        */

        /// <summary>
        /// Gets a pointer to a given subentry.
        /// </summary>
        public SubEntry* GetSubEntryPointer(Entry* thisHeader, int index)
        {
            var pointers = (uint*)(thisHeader + 1);
            return (SubEntry*)pointers[index];
        }
    }
}