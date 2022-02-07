using Homerchu.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Homerchu.Mario
{
    public class MarioGame : Game
    {
        private SpriteBatch _spriteBatch;
        private IController _controller;
        private IController _controller2;
        public Texture2D marioSprites;
        private SpriteFont _font;
        internal ISprite Sprite { get; set; }
        private Avatar avatar;
        private GraphicsDeviceManager device;


        public MarioGame()
        {
            device = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            MapKeyboard();
            MapGamepad();

            base.Initialize();

        }

        protected void MapKeyboard()
        {
            _controller = new KeyboardController();
        }

        protected void MapGamepad()
        {
            _controller2 = new GamepadController();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Font/arial");
            marioSprites = Content.Load<Texture2D>("Images/marioSprites");

            avatar = new Avatar(marioSprites);
        }

        protected void UpdateControllers()
        {
            _controller.Update();
            _controller2.Update();
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateControllers();

            avatar.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            avatar.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
