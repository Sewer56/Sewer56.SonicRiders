using Reloaded.Memory.Streams.Readers;
using Reloaded.Memory.Streams.Writers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames
{
    public class Unknown : IManagedFrame
    {
        public short DataType;
        public byte[] Data { get; set; }

        public int Size => Data.Length;

        public int Write(EndianMemoryStream stream)
        {
            stream.Write(Data);
            return Data.Length;
        }

        public object Read(EndianStreamReader stream) => throw new System.NotImplementedException();
    }
}
