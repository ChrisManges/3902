using Homerchu.Mario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homerchu.Mario
{ 

    class Avatar
    {

        public const int AVATAR_WIDTH = 18;
        public const int AVATAR_HEIGHT = 34;
        public const int SCALE_FACTOR = 4;

        /// <summary>
        /// Construct an avatar (mario) from a spritesheet
        /// </summary>
        /// <param name="spritesheet">Sprites of Mario (15 x 6)</param>
        public Avatar(Texture2D spritesheet)
        {
            sprite = new EntitySprite(new Rectangle(240, 240, AVATAR_WIDTH * SCALE_FACTOR, AVATAR_HEIGHT * SCALE_FACTOR), spritesheet, new Vector2(15, 6));
            ChangeActionState();
            _sheet = spritesheet;
        }

        public void Draw(SpriteBatch batch)
        {
            sprite.Draw(batch);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        /// <summary>
        /// Changes Action States
        /// </summary>
        protected void ChangeActionState()
        {
            //_actionState = new AvatarState(); //TODO: USE A FACTORY TO CREATE A NEW STATE
            _actionState = new Actions.WalkState();
            _actionState.Handle(this);
        }

        /// <summary>
        /// Changes Player States
        /// </summary>
        protected void ChangePlayerState()
        {
            //_playerState = new AvatarState(); //TODO: USE A FACTORY TO CREATE A NEW STATE
            _actionState.Handle(this);
        }

        Texture2D _sheet;
        AvatarState _playerState;
        AvatarState _actionState;

        public uint rowSel = 0;
        public EntitySprite sprite;
    }
}
