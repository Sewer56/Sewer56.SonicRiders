using System.Collections.Generic;

namespace Sewer56.SonicRiders.Parser.Menu.Metadata.Managed
{
    public class Object
    {
        public ActionLayer ActionLayer { get; set; } = new();

        public List<Layer> Layers { get; set; } = new();

        public int GetDurationOfLongestAnimation()
        {
            int max = int.MinValue;
            foreach (var layer in Layers)
            {
                if (layer.AnimationDurationFrames > max)
                    max = layer.AnimationDurationFrames;
            }

            return max;
        }
    }
}
