using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Reloaded.Memory;

namespace Sewer56.SonicRiders.Parser.Layout.Structs
{
    public unsafe struct LayoutHeader : IEndianReversible
    {
        /// <summary>
        /// A header which is the combination of a constant 0x8000 (2 bytes) and the number of objects (2 bytes).
        /// The magic constant 0x8000 is set to 0 after loaded in in game.
        /// </summary>
        public int CountMagicTuple;

        /// <summary>
        /// Total number of objects in this file.
        /// </summary>
        public ref ushort ObjectCount => ref Unsafe.AsRef<ushort>(Unsafe.AsPointer(ref CountMagicTuple));

        /// <summary>
        /// Unknown use.
        /// Always 0x8000, until it is loaded in by game.
        /// </summary>
        public ref ushort Magic => ref Unsafe.AsRef<ushort>((byte*)Unsafe.AsPointer(ref CountMagicTuple) + 2);

        /// <summary>
        /// This is actually the size of the object
        /// array minus the size of the header and the
        /// unknown section after the object array.
        /// </summary>
        public int ObjectCountMultiplyBy46Add8;

        public LayoutHeader(int objectCount, bool useFileMagic = false)
        {
            CountMagicTuple = default;
            ObjectCountMultiplyBy46Add8 = default;
            Initialise(objectCount, useFileMagic);
        }

        public void Initialise(int objectCount, bool useFileMagic = false)
        {
            ObjectCount = (ushort) objectCount;
            Magic = useFileMagic ? (ushort) 0x8000 : (ushort) 0;
            ObjectCountMultiplyBy46Add8 = (objectCount * 46) + 8;
        }

        /// <inheritdoc/>
        public void SwapEndian()
        {
            var objSwapped = Endian.Reverse(ObjectCount);
            var magicSwapped = Endian.Reverse(Magic);

            // Not a bug, just how it differs between platforms
            ObjectCount = magicSwapped;
            Magic = objSwapped;
            ObjectCountMultiplyBy46Add8 = Endian.Reverse(ObjectCountMultiplyBy46Add8);
        }
    }
}