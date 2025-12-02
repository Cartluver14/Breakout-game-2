using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Breakout_game_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

       
        Texture2D ballTexture;
        MouseState MouseState, previousmousestate;
        bool clicked = false;
        Texture2D brickTexture;
        List<Brick> brickrectangle = new List<Brick>();
        Rectangle window;
        Texture2D paddleTexture;
        Ball ball1;
        Paddle paddle1;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
          
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            base.Initialize();
          
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ballTexture = Content.Load<Texture2D>("Images/ball");
            brickTexture = Content.Load<Texture2D>("Images/brick");
            paddleTexture = Content.Load<Texture2D>("Images/paddle");

           
            brickrectangle.Clear();
            for (int x = 0; x < 600; x += 25)
            {
                for (int y = 0; y < 200; y += 10)
                {
                    Brick brickrec = new Brick(brickTexture, new Rectangle(x, y, 22, 22));
                    brickrectangle.Add(brickrec);
                }
            }

            ball1 = new Ball(ballTexture, new Rectangle(400, 250, 40, 40));
            paddle1 = new Paddle(paddleTexture, new Rectangle(275, 450, 100, 20), Vector2.Zero);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState = Mouse.GetState();
            if (MouseState.LeftButton == ButtonState.Pressed && !clicked)
            {
                ball1.Speed = new Vector2(2, 2);
                clicked = true;

            }




            // TODO: Add your update logic here

            ball1.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            ball1.Draw(_spriteBatch);

            paddle1 = new Paddle(paddleTexture, new Rectangle(MouseState.X - 50, 450, 100, 20), new Vector2(0, 0));
            paddle1.Draw(_spriteBatch);


            for (int i = 0; i < brickrectangle.Count; i++)
            {
                brickrectangle[i].Draw(_spriteBatch);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
