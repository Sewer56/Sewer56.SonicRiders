using Reloaded.Memory.Streams.Writers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed.Frames
{
    /// <summary>
    /// Abstracts a managed keyframe.
    /// </summary>
    public interface IManagedFrame
    {
        /// <summary>
        /// Writes the action layer to a given stream.
        /// </summary>
        /// <param name="stream">The stream to write the keyframe to.</param>
        /// <returns>Number of bytes written.</returns>
        public int Write(EndianMemoryStream stream);
    }
}