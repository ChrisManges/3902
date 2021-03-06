using Homerchu.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario
{
    class EntitySprite : DynamicSprite
    {

        /// <summary>
        /// Orientation is a boolean for left / right.
        /// By default, (false) orientation = right.
        /// If true, orientation = left.
        /// </summary>
        public bool Orientation
        {
            get => _orientation;
            set
            {
                if (value != _orientation)
                    Flip();
            }
        }

        /// <summary>
        /// Constructor is the same as DynamicSprite - reference this instead.
        /// </summary>
        public EntitySprite(Rectangle bounds, Texture2D tex, Vector2 atlasDimensions) : base(bounds, tex, atlasDimensions) {
            _orientation = false;
            _animationStart = 0;
            _animationEnd = (uint)(atlasDimensions.X * atlasDimensions.Y);
        }

        /// <summary>
        /// Sets the texture to a different texture (sprite sheet).
        /// </summary>
        /// <param name="tex">New texture to use.</param>
        public void SetTexture(Texture2D tex) => _texture = tex;

        /// <summary>
        /// Flips a given orientation to the opposite side
        /// </summary>
        public void Flip()
        {
            _bounds.X += _bounds.Width;
            _bounds.Y += _bounds.Height;

            _bounds.Width = -_bounds.Width;
            _bounds.Height = -_bounds.Height;

            _orientation = !_orientation;
        }

        /// <summary>
        /// Sets an animation to play within a specific range of a spritesheet.
        /// This range is [idxStart, idxEnd)
        /// If the current index is outside of the range, it is set to the start.
        /// </summary>
        /// <param name="idxStart">Start of Range (inclusive).</param>
        /// <param name="idxEnd">End of Range (exclusive).</param>
        public void SetAnimationRange(uint idxStart, uint idxEnd)
        {
            _animationStart = idxStart;
            _animationEnd = idxEnd;

            if (_animationIndex >= _animationEnd || _animationIndex < _animationStart)
                _animationIndex = _animationStart;
        }

        protected bool _orientation;
        protected uint _animationStart;
        protected uint _animationEnd;

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

        protected new void IncrementTimer(GameTime gameTime)
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
        protected new void Animate()
        {
            CalculateNewIndex();
            RecalculateSelection();
        }

        /// <summary>
        /// Calculate new index with respect to animation boundaries
        /// </summary>
        protected new void CalculateNewIndex()
        {
            _animationIndex++;

            if (_animationIndex >= _animationEnd)
                _animationIndex = _animationStart;
        }

    }
}
