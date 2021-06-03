using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.API;
using Sewer56.SonicRiders.Parser.Layout.Structs;

namespace Sewer56.SonicRiders.Parser.Layout
{
    public unsafe struct InMemoryLayoutFile
    {
        /// <summary>
        /// Gets the current in memory layout.
        /// </summary>
        public static InMemoryLayoutFile Current => new InMemoryLayoutFile(*State.CurrentStageObjectLayout);

        /// <summary>
        /// The header of the file.
        /// </summary>
        public LayoutHeader* Header;

        /// <summary>
        /// Array of all objects.
        /// </summary>
        public RefFixedArrayPtr<SetObject> Objects;

        /// <summary>
        /// Array of unknown values between 1 and 4.
        /// Might be render distance.
        /// </summary>
        public RefFixedArrayPtr<ushort> UnknownArray;

        public InMemoryLayoutFile(void* ptr)
        {
            Header = (LayoutHeader*) ptr;
            Objects = new RefFixedArrayPtr<SetObject>((ulong) (Header + 1), Header->ObjectCount);
            UnknownArray = new RefFixedArrayPtr<ushort>((ulong) (Header + 1) + (ulong)(Objects.Count * sizeof(SetObject)), Header->ObjectCount);
        }

        /// <summary>
        /// Provides an estimation of the file size of a potential file based on the number of items requested.
        /// </summary>
        /// <param name="numItems">The number of items.</param>
        /// <returns>The file size.</returns>
        public static int CalcFileSize(int numItems)
        {
            int size = sizeof(LayoutHeader);
            size += sizeof(SetObject) * numItems;
            size += sizeof(ushort) * numItems;
            return size;
        }
    }
}