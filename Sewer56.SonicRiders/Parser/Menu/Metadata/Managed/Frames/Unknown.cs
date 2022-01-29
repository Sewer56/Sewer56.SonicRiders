using Reloaded.Memory.Streams.Writers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames
{
    public class Unknown : IManagedFrame
    {
        public byte[] Data;

        public int Write(EndianMemoryStream stream)
        {
            stream.Write(Data);
            return Data.Length;
        }
    }
}
