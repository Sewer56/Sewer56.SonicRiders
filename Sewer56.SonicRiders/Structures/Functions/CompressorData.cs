using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Functions
{
    public unsafe struct CompressorData
    {
        public void*  UncompressedDataPtr;
        public void*  CurrentDataPtr;
        public int    ArchiveSize;
        public byte   ArchiveType;
        public ushort padding_d;
        public byte   DefaultEight;
        public int    dword10;
        public int    dword14;
        public int    dword18;
        public int    BlockSize;
        public byte   field20;
        public byte   field21;
        public byte   field22;
        public byte   field23;
    }
}
