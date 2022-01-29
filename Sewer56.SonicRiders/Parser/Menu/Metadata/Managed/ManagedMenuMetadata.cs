using System.Collections.Generic;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class ManagedMenuMetadata
    {
        public short ResolutionX    { get; set; }
        public short ResolutionY    { get; set; }
        public byte FrameRate       { get; set; }
        public byte MaxKeyframeSize { get; set; }
        public short Unknown        { get; set; }

        public List<Object> Objects { get; set; } = new ();

        public List<Texture> Textures { get; set; } = new();

        public static ManagedMenuMetadata FromFile { get; set; }
    }
}
