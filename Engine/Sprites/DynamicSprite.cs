using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homerchu.Engine
{
    class DynamicSprite : AnimatedSprite
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
        /// This method invokes the base constructor in AnimatedSprite - refer to this for the parameters.
        /// </summary>
        public DynamicSprite(Rectangle bounds, Texture2D tex, Vector2 atlasDimensions) : base(bounds, tex, atlasDimensions) { }
    }
}
