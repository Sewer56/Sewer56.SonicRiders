namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    public unsafe struct EntryHeader
    {
        /// <summary>
        /// Total number of entries.
        /// </summary>
        public int NumEntries;

        /// <summary>
        /// Total size of all the whole entry section, including entries and this header.
        /// </summary>
        public int TotalSectionSize;

        /*
            After this struct in memory follow pointers to individual entries.
            If the file is not loaded, it is an offset from the start of this header.
            If the file is loaded, it they are pointers to the actual entries.
        */

        /// <summary>
        /// Gets a pointer to a given subentry.
        /// </summary>
        public Entry* GetEntryPointer(EntryHeader* thisHeader, int index)
        {
            var pointers = (uint*)(thisHeader + 1);
            return (Entry*)pointers[index];
        }
    };
}