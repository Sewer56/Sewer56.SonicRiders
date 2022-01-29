using Reloaded.Memory.Streams.Writers;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class ActionLayer
    {
        /// <summary>
        /// If this is less than 1, struct ends at <see cref="DurationOfLongestAnimation"/>.
        /// </summary>
        public short IsEnabled { get; set; }

        public short Unk_1 { get; set; }

        // Struct may potentially end here.
        // TODO: Calculate duration of longest animation.

        public short UnknownFlag { get; set; }

        public short Unk_4 { get; set; }

        public short Unk_5 { get; set; }

        /// <summary>
        /// Writes the action layer to a given stream.
        /// </summary>
        /// <param name="stream">The stream to write the action layer to.</param>
        /// <param name="parent">The object owning this action layer.</param>
        /// <returns>Number of bytes written.</returns>
        public int Write(EndianMemoryStream stream, Object parent)
        {
            var originalPos = stream.Stream.Position;

            stream.Write(IsEnabled);
            stream.Write(Unk_1);

            if (IsEnabled < 0)
                return (int)(stream.Stream.Position - originalPos);

            stream.Write(parent.GetDurationOfLongestAnimation());
            stream.Write(UnknownFlag);
            stream.Write(Unk_4);
            stream.Write(Unk_5);

            return (int)(stream.Stream.Position - originalPos);
        }
    }
}
