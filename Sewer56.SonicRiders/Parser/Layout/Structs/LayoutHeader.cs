namespace Sewer56.SonicRiders.Parser.Layout.Structs
{
    public struct LayoutHeader
    {
        /// <summary>
        /// Total number of objects in this file.
        /// </summary>
        public ushort ObjectCount;

        /// <summary>
        /// Unknown use.
        /// Always 0x8000, until it is loaded in by game.
        /// </summary>
        public ushort Magic;

        /// <summary>
        /// This is actually the size of the object
        /// array minus the size of the header and the
        /// unknown section after the object array.
        /// </summary>
        public int ObjectCountMultiplyBy46Add8;

        public LayoutHeader(int objectCount, bool useFileMagic = false)
        {
            ObjectCount = default;
            Magic = default;
            ObjectCountMultiplyBy46Add8 = default;
            Initialise(objectCount, useFileMagic);
        }

        public void Initialise(int objectCount, bool useFileMagic = false)
        {
            ObjectCount = (ushort) objectCount;
            Magic = useFileMagic ? (ushort) 0x8000 : (ushort) 0;
            ObjectCountMultiplyBy46Add8 = (objectCount * 46) + 8;
        }
    }
}