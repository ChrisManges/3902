using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homerchu.Engine
{
    class Sprite : SpriteBase
    {

        /// <summary>
        /// This implementation of the property does not allow the boundaries to be changed, but to be read.
        /// </summary>
        public override Rectangle Bounds
        {
            get => _bounds;
            set { }
        }

        /// <summary>
        /// Implements the color property as a default getter setter
        /// </summary>
        public override Color Color { get => _color; set => _color = value; }

        /// <summary>
        /// This is the base constructor for a sprite. It loads a given texture and sets
        /// an initial boundary for the sprite to be drawn at.
        /// </summary>
        /// <param name="bounds"> Initial bounds to be set. </param>
        /// <param name="tex"> Texture object to be used. </param>
        public Sprite(Rectangle bounds, Texture2D tex)
        {
            _bounds = bounds;
            _color = Color.White;
            _texture = tex;
        }

        /// <summary>
        /// Renders the sprite to a given canvas.
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_texture == null) return;

            spriteBatch.Draw(_texture, _bounds, _color);
        }

        /// <summary>
        /// Updates the sprite based upon the game time
        /// </summary>
        public override void Update(GameTime gameTime) { }


        protected Rectangle _bounds;
        protected Color _color;
        protected Texture2D _texture;
    }
}
