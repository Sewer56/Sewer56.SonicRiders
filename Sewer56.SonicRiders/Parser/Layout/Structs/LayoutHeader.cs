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
        /// Always 0x8000
        /// </summary>
        public ushort Magic;

        /// <summary>
        /// This is actually the size of the object
        /// array minus the size of the header and the
        /// unknown section after the object array.
        /// </summary>
        public int ObjectCountMultiplyBy46Add8;

        public void Initialise(int objectCount)
        {
            ObjectCount = (ushort) objectCount;
            Magic = 0x8000;
            ObjectCountMultiplyBy46Add8 = (objectCount * 46) + 8;
        }
    }
}