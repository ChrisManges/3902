using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homerchu.Engine
{
    abstract class SpriteBase : ISprite
    {
        public abstract Rectangle Bounds { get; set; }
        public abstract Color Color { get; set; }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }

}
