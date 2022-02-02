using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homerchu.Engine
{
    class AnimatedSprite : Sprite
    {
        /// <summary>
        /// This property defines the number of ticks per second in order for the animation to update.
        /// </summary>
        public uint Ticks
        {
            get => _ticks;
            set => _ticks = value;
        }

        /// <summary>
        /// This property defines a getter and setter for the individual current animation frame.
        /// </summary>
        public uint AnimationFrame
        {
            get => _animationIndex;
            set
            {
                if (value < 0) return;
                if (value > _atlasDimensions.X * _atlasDimensions.Y) return;

                _animationIndex = value;
            }
        }

        /// <summary>
        /// This method invokes the base constructor in Sprite - refer to this for the parameters.
        /// </summary>
        public AnimatedSprite(Rectangle bounds, Texture2D tex, Vector2 atlasDimensions) : base(bounds, tex)
        {
            _atlasDimensions = atlasDimensions;
            RecalculateSelection();
        }

        /// <summary>
        /// Updates animations every tick.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            IncrementTimer(gameTime);

            if (_internalTimer >= 1.0f / (float)_ticks)
            {
                _internalTimer = 0;
                Animate();
            }
        }

        protected void IncrementTimer(GameTime gameTime)
        {
            if (_ticks > 0)
                _internalTimer += gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// This method draws the selected animation frame to the canvas
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch) => spriteBatch.Draw(_texture, _bounds, _selection, _color);

        /// <summary>
        /// Animate is an internal method that can be called by Update
        /// This method is responsible for updating the animation index,
        /// and it will update a given sprite sheet.
        /// </summary>
        protected void Animate()
        {
            CalculateNewIndex();
            RecalculateSelection();
        }

        protected void CalculateNewIndex() => _animationIndex = (uint)(_animationIndex + 1) % (uint)(_atlasDimensions.X * _atlasDimensions.Y);

        protected Rectangle _selection;
        protected Vector2 _atlasDimensions;
        protected uint _animationIndex = 0;
        protected double _internalTimer = 0;
        protected uint _ticks = 4;

        /// <summary>
        /// Recalculate Selection selects the proper box for the sprite texture atlas based on the current index.
        /// </summary>
        protected void RecalculateSelection() => SetSelection(
            _texture.Width / (int)_atlasDimensions.X,
            _texture.Height / (int)_atlasDimensions.Y);

        protected void SetSelection(int w, int h) => _selection = new Rectangle(
            w * ((int)_animationIndex % (int)_atlasDimensions.X),
            h * ((int)_animationIndex / (int)_atlasDimensions.X),
            w,
            h);

    }
}
