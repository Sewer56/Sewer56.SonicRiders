using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sewer56.SonicRiders.Parser.TextureArchive.Structs
{
    public struct TextureArchiveWriterSettings
    {
        public static TextureArchiveWriterSettings GameCube = new TextureArchiveWriterSettings()
        {
            Alignment = 0x20,
            BigEndian = true,
            WriteFlagsSection = true
        };

        public static TextureArchiveWriterSettings PC = new TextureArchiveWriterSettings()
        {
            Alignment = 0x40,
            BigEndian = false,
            WriteFlagsSection = true
        };

        /// <summary>
        /// True if big endian, else false.
        /// </summary>
        public bool BigEndian;

        /// <summary>
        /// Writes the flags section (usually filled with 0x11)
        /// </summary>
        public bool WriteFlagsSection;

        /// <summary>
        /// Alignment of each texture.
        /// </summary>
        public int Alignment;
    }
}
