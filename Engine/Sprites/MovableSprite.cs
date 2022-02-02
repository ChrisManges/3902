using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homerchu.Engine
{
    class MovableSprite : Sprite
    {
        /// <summary>
        /// This implementation of the property allows movement and resizing.
        /// </summary>
        public override Rectangle Bounds
        {
            get => _bounds;
            set => _bounds = value;
        }

        /// <summary>
        /// This method invokes the base constructor in Sprite - refer to this for the parameters.
        /// </summary>
        public MovableSprite(Rectangle bounds, Texture2D tex) : base(bounds, tex) { }
    }
}
