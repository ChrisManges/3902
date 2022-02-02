using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homerchu.Engine
{
    /// <summary>
    /// A completely null sprite that does absolutely nothing.
    /// </summary>
    class NullSprite : Sprite
    {
        public NullSprite() : base(new Rectangle(0, 0, 0, 0), null) { }

        public override Rectangle Bounds { get; set; }
        public override Color Color { get; set; }
        public override void Draw(SpriteBatch spriteBatch) { }
        public override void Update(GameTime gameTime) { }
    }
}
