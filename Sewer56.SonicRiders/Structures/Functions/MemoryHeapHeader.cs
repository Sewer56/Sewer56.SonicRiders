namespace Sewer56.SonicRiders.Structures.Functions
{
    public unsafe struct MemoryHeapHeader
    {
        public MemoryHeapHeader* LastItem;
        public MemoryHeapHeader* NextItem;
        public int FileSize;
    }
}
