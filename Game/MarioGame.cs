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
        public Texture2D texGeneric;
        public Texture2D texAnimated;
        private SpriteFont _font;
        internal ISprite Sprite { get; set; }
        public bool moveLogic = false;

        public MarioGame()
        {
            new GraphicsDeviceManager(this);
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
            _controller.AddCommand((int)Keys.Q, new QuitCommand(this));
            _controller.AddCommand((int)Keys.W, new StaticCommand(this));
            _controller.AddCommand((int)Keys.E, new AnimatedCommand(this));
            _controller.AddCommand((int)Keys.R, new MoveCommand(this));
            _controller.AddCommand((int)Keys.T, new DynamicCommand(this));
        }

        protected void MapGamepad()
        {
            _controller2 = new GamepadController();
            _controller2.AddCommand((int)Buttons.Start, new QuitCommand(this));
            _controller2.AddCommand((int)Buttons.A, new StaticCommand(this));
            _controller2.AddCommand((int)Buttons.B, new AnimatedCommand(this));
            _controller2.AddCommand((int)Buttons.X, new MoveCommand(this));
            _controller2.AddCommand((int)Buttons.Y, new DynamicCommand(this));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Font/arial");
            texGeneric = Content.Load<Texture2D>("Images/wall");
            texAnimated = Content.Load<Texture2D>("Images/victini");
            Sprite = new NullSprite();
        }

        public void SetStatic()
        {
            Sprite = new Sprite(new Rectangle(346, 186, 108, 108), texGeneric);
        }

        public void SetMove()
        {
            Sprite = new MovableSprite(new Rectangle(346, 186, 108, 108), texGeneric);
            moveLogic = false;
        }

        public void SetAnimated()
        {
            Sprite = new AnimatedSprite(new Rectangle(346, 186, 108, 108), texAnimated, new Vector2(2, 2));
        }

        public void SetDynamic()
        {
            Sprite = new DynamicSprite(new Rectangle(346, 186, 108, 108), texAnimated, new Vector2(2, 2));
            moveLogic = true;
        }

        protected void MoveSprite(GameTime gameTime)
        {
            var r = Sprite.Bounds;

            if (moveLogic)
                r.X += (int)(Math.Sin(gameTime.TotalGameTime.TotalSeconds) * 3);
            else
                r.Y += (int)(Math.Sin(gameTime.TotalGameTime.TotalSeconds) * 3);

            Sprite.Bounds = r;
        }

        protected void UpdateControllers()
        {
            _controller.Update();
            _controller2.Update();
        }

        protected override void Update(GameTime gameTime)
        {
            UpdateControllers();   
            MoveSprite(gameTime);

            Sprite.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);
            _spriteBatch.Begin();

            Sprite.Draw(_spriteBatch);

            _spriteBatch.DrawString(_font, "Q/Start - Quit\nW/A - Static Sprite\nE/B - Animated Sprite\nR/X - Movable Sprite\nT/Y - Dynamic Sprite", new Vector2(0, 0), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
