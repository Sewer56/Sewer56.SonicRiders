using System.Collections.Generic;
using System.Runtime.InteropServices;
using Reloaded.Memory.Pointers;
using Sewer56.SonicRiders.Parser.Menu.Metadata.Structs;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata
{
    /// <summary>
    /// In memory parser of menu metadata.
    /// Intended to make memory edits a possibility.
    /// </summary>
    public unsafe class InMemoryMenuMetadata
    {
        public MetadataHeader* Header;
        public EntryHeader* EntryHeader;

        public List<BlittablePointer<Entry>> Entries;
        public List<List<BlittablePointer<SubEntry>>> SubEntries;

        public TextureIdHeader* TextureIdHeader;
        public TextureIdEntry* TextureIdEntries => TextureIdHeader->GetEntryPointer(TextureIdHeader);

        /// <summary>
        /// Determines the file size from the other properties.
        /// </summary>
        public uint FileSize => (uint)&TextureIdEntries[TextureIdHeader->NumTextures + 1] - (uint)Header;

        /// <summary>
        /// Creates a dummy object.
        /// Before use, object must be initialised with <see cref="Initialize"/> method.
        /// </summary>
        public InMemoryMenuMetadata() { }

        /// <summary/>
        /// <param name="headerAddress">The address of the menu metadata header.</param>
        /// <param name="isLoaded">True if the metadata is already loaded into the game, else false.</param>
        public InMemoryMenuMetadata(MetadataHeader* headerAddress, bool isLoaded)
        {
            Initialize(headerAddress, isLoaded);
        }

        /// <summary>
        /// Initializes this.
        /// Use this if you want to re-initialize the class without creating a new instance.
        /// </summary>
        /// <param name="headerAddress">The address of the menu metadata header.</param>
        /// <param name="isLoaded">True if the metadata is already loaded into the game, else false.</param>
        public void Initialize(MetadataHeader* headerAddress, bool isLoaded)
        {
            Header = headerAddress;

            var entryHeaderPtr = (byte*)(headerAddress + 1);
            EntryHeader = (EntryHeader*)entryHeaderPtr;

            InitializeOrClear(ref Entries, EntryHeader->NumEntries);
            InitializeOrClear(ref SubEntries, EntryHeader->NumEntries);

            // Add entry
            for (int x = 0; x < EntryHeader->NumEntries; x++)
            {
                var entryPtr = isLoaded ? EntryHeader->GetEntryPointer(EntryHeader, x) : (Entry*)(entryHeaderPtr + (uint)EntryHeader->GetEntryPointer(EntryHeader, x));
                Entries.Add(entryPtr);

                // Add subentries
                var subEntries = GetItemOrDefault(SubEntries, x);
                InitializeOrClear(ref subEntries, entryPtr->SubEntryCount);

                for (int y = 0; y < entryPtr->SubEntryCount; y++)
                {
                    var subEntryPtr = isLoaded ? entryPtr->GetSubEntryPointer(entryPtr, y) : (SubEntry*)((byte*)entryPtr + (uint)entryPtr->GetSubEntryPointer(entryPtr, y));
                    subEntries.Add(subEntryPtr);
                }

                SubEntries.Add(subEntries);
            }

            // Add final section.
            TextureIdHeader = isLoaded ? Header->TextureIndicesPtr : (TextureIdHeader*)((byte*)headerAddress + (uint)Header->TextureIndicesPtr);
        }
        
        private void InitializeOrClear<T>(ref List<T> list, int count)
        {
            if (list == null)
                list = new List<T>(count);
            else
                list.Clear();
        }

        private T GetItemOrDefault<T>(List<T> list, int index) => index < list.Count ? list[index] : default;
    }
}
