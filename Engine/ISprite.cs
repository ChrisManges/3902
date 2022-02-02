using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homerchu.Engine
{
    /// <summary>
    /// This is the basic interface for all sprites. Sprites are a 2D drawable object with
    /// a defined boundary in the form of a rectangle, alongside of a color. This object may
    /// or may not be animated.
    /// </summary>
    interface ISprite
    {
        /// <summary>
        /// This property defines the position and size of the 2D Sprite.
        /// x and y positions are the offset from the origin, and the w and h
        /// are the width and height of the boundaries.
        /// </summary>
        Rectangle Bounds
        {
            get;
            set;
        }

        /// <summary>
        /// This property defines the color of the 2D Sprite. If the sprite uses
        /// a texture, the texture values are multiplied by this given color.
        /// </summary>
        Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// This method updates a sprite. If the sprite is animated, this will
        /// trigger the animation based on time passed.
        /// </summary>
        /// <param name="gameTime"> The game time used for updating. </param>
        void Update(GameTime gameTime);

        /// <summary>
        /// This method draws the current sprite to a provided canvas.
        /// </summary>
        /// <param name="spriteBatch"> The sprite batch canvas to draw upon. </param>
        void Draw(SpriteBatch spriteBatch);

    }
}
