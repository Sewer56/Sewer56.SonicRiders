using System.Numerics;
using Reloaded.Memory;
using Sewer56.SonicRiders.Parser.Layout.Enums;
using Sewer56.SonicRiders.Utility;

namespace Sewer56.SonicRiders.Parser.Layout.Structs
{
    /// <summary>
    /// Represents an individual placeable object.
    /// </summary>
    public struct SetObject : IEndianReversible
    {
        public ObjectId Type;

        /// <summary>
        /// The maximum player count until the object is no longer included.
        /// e.g. 1 = 1 Player Only
        /// 2 = 1 & 2 Player Only
        /// </summary>
        public byte MaxPlayerCount;
        
        /// <summary>
        /// The ASCII character used to denote the "portal" the object belongs to.
        /// Portals are bounding box regions. If the object is outside the portal, it is not rendered.
        /// </summary>
        public byte PortalChar; 
    
        /// <summary>
        /// Flags determining when to display the object.
        /// </summary>
        public SetObjectVisibility Visibility;

        /// <summary>
        /// Typically 0. Effect of this attribute depends on the object.
        /// For item boxes, it changes the containing item.
        /// </summary>
        public int Attribute;

        /// <summary>
        /// Absolute position of the object.
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// Rotation of the object in degrees.
        /// </summary>
        public Vector3 Rotation;

        /// <summary>
        /// Multiplier, so 1,1,1 is normal scale.
        /// In some cases, these fields are used to store additional object properties.
        /// </summary>
        public Vector3 Scale;

        /// <summary>
        /// Swaps the endian of this structure.
        /// </summary>
        public void SwapEndian()
        {
            Type = (ObjectId)Endian.Reverse((ushort)Type);
            Visibility = (SetObjectVisibility)Endian.Reverse((int)Visibility);
            Attribute = Endian.Reverse(Attribute);
            Position.EndianSwap();
            Rotation.EndianSwap();
            Scale.EndianSwap();
        }
    }
}