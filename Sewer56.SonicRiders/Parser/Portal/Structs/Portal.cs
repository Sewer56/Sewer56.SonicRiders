using Sewer56.SonicRiders.Parser.Layout.Structs;
using Sewer56.SonicRiders.Utility.Math;

namespace Sewer56.SonicRiders.Parser.Portal.Structs
{
    /// <summary>
    /// Defines an individual "Object Portal"; which is a bounding box used to determine whether an object should be loaded.
    /// If an object is in no Portal with the same ASCII character as assigned to the object (see <see cref="PortalChar"/> and <see cref="SetObject.PortalChar"/>)
    /// </summary>
    public struct Portal
    {
        /// <summary>
        /// Minimum X,Y,Z
        /// </summary>
        public Vector3Short Minimum;

        /// <summary>
        /// Maximum X,Y,Z
        /// </summary>
        public Vector3Short Maximum;

        /// <summary>
        /// An ASCII character uniquely identifying this group of portals.
        /// If a layout object is in no portal with the same character, it is not rendered.
        /// </summary>
        public byte PortalChar;
        
        /// <summary>
        /// True if the object is rotated, else false.
        /// </summary>
        public byte IsRotated;

        private short _padding;
        
        /// <summary>
        /// Range 0 - 65535
        /// i.e. 13684 = 90 degrees
        /// </summary>
        public Vector3Int RotationBams;
    };
}