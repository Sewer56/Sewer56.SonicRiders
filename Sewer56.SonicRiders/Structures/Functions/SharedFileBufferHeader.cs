using System;
using System.Collections.Generic;
using System.Text;

namespace Sewer56.SonicRiders.Structures.Functions
{
    public unsafe struct SharedFileBufferHeader
    {
        public SharedFileBufferHeader* LastItem;
        public SharedFileBufferHeader* NextItem;
        public int FileSize;
    }
}
