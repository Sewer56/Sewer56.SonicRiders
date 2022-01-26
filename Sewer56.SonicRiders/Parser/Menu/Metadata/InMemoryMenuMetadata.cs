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
        public ObjectSectionHeader* ObjectSectionHeader;

        public List<BlittablePointer<Object>> Objects;

        public List<List<BlittablePointer<ActionLayer>>> ActionLayers;
        public List<List<BlittablePointer<Layer>>> Layers;

        public TextureSectionHeader* TextureIdHeader;
        public TextureEntry* TextureIdEntries => TextureIdHeader->GetEntryPointer(TextureIdHeader);

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
            ObjectSectionHeader = (ObjectSectionHeader*)entryHeaderPtr;

            InitializeOrClear(ref Objects, ObjectSectionHeader->NumObjects);
            InitializeOrClear(ref Layers, ObjectSectionHeader->NumObjects);
            InitializeOrClear(ref ActionLayers, ObjectSectionHeader->NumObjects);

            // Add entry
            for (int x = 0; x < ObjectSectionHeader->NumObjects; x++)
            {
                var entryPtr = isLoaded ? ObjectSectionHeader->GetObjectPointer(ObjectSectionHeader, x) : (Object*)(entryHeaderPtr + (uint)ObjectSectionHeader->GetObjectPointer(ObjectSectionHeader, x));
                Objects.Add(entryPtr);

                // Add action layers.
                var actionLayers = GetItemOrDefault(ActionLayers, x);
                InitializeOrClear(ref actionLayers, 1);

                // Add layers
                var layers = GetItemOrDefault(Layers, x);
                InitializeOrClear(ref layers, entryPtr->LayerCount);

                for (int y = 0; y < entryPtr->LayerCount; y++)
                {
                    var subEntryPtr = isLoaded ? entryPtr->GetLayerPointer(entryPtr, y) : (Layer*)((byte*)entryPtr + (uint)entryPtr->GetLayerPointer(entryPtr, y));
                    if (y == 0)
                        actionLayers.Add((ActionLayer*) subEntryPtr);
                    else
                        layers.Add(subEntryPtr);
                }

                ActionLayers.Add(actionLayers);
                Layers.Add(layers);
            }

            // Add final section.
            TextureIdHeader = isLoaded ? Header->TextureIndicesPtr : (TextureSectionHeader*)((byte*)headerAddress + (uint)Header->TextureIndicesPtr);
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
