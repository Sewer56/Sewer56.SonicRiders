namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Structs
{
    public unsafe struct ObjectSectionHeader
    {
        /// <summary>
        /// Total number of objects.
        /// </summary>
        public int NumObjects;

        /// <summary>
        /// Total size of all the whole entry section, including objects and this header.
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
        public Object* GetObjectPointer(ObjectSectionHeader* thisHeader, int index)
        {
            var pointers = (uint*)(thisHeader + 1);
            return (Object*)pointers[index];
        }
    };
}