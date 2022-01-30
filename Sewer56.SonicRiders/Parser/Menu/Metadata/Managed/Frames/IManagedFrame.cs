using Reloaded.Memory.Streams.Readers;
using Reloaded.Memory.Streams.Writers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames
{
    /// <summary>
    /// Abstracts a managed keyframe.
    /// </summary>
    public interface IManagedFrame
    {
        public int Size { get; }

        /// <summary>
        /// Writes the frame to a given stream.
        /// </summary>
        /// <param name="stream">The stream to write the frame to.</param>
        /// <returns>Number of bytes written.</returns>
        public int Write(EndianMemoryStream stream);

        /// <summary>
        /// Reads the frame from a given stream.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <returns>Number of bytes written.</returns>
        public object Read(EndianStreamReader stream);
    }
}