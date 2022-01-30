using Reloaded.Memory.Streams.Readers;
using Reloaded.Memory.Streams.Writers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{    
    /// <summary>
    /// Individual entry in the Texture section.
    /// </summary>
    public class Texture
    {
        public short Unknown { get; set; }

        /// <summary>
        /// Index inside the xvrs texture archive.
        /// </summary>
        public short XvrsTextureId { get; set; }

        /// <summary>
        /// Top Left Corner. 0-1
        /// </summary>
        public float NormalizedPosX { get; set; }

        /// <summary>
        /// Top Left Corner. 0-1
        /// </summary>
        public float NormalizedPosY { get; set; }

        /// <summary>
        /// 0-1 Where 1 represents the whole width of the texture.
        /// </summary>
        public float NormalizedWidth { get; set; }

        /// <summary>
        /// 0-1 Where 1 represents the whole height of the texture.
        /// </summary>
        public float NormalizedHeight { get; set; }
        
        /// <summary>
        /// Reads a texture from the provided stream.
        /// </summary>
        /// <param name="streamReader">The reader reading the stream.</param>
        public static Texture Read(EndianStreamReader streamReader)
        {
            return new Texture()
            {
                Unknown           = streamReader.Read<short>(),
                XvrsTextureId     = streamReader.Read<short>(),
                NormalizedPosX    = streamReader.Read<float>(),
                NormalizedPosY    = streamReader.Read<float>(),
                NormalizedWidth   = streamReader.Read<float>(),
                NormalizedHeight  = streamReader.Read<float>(),
            };
        }

        public void Write(EndianMemoryStream stream)
        {
            stream.Write(Unknown);
            stream.Write(XvrsTextureId);
            stream.Write(NormalizedPosX);
            stream.Write(NormalizedPosY);
            stream.Write(NormalizedWidth);
            stream.Write(NormalizedHeight);
        }
    }
}
