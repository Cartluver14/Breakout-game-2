using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Breakout_game_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D ballTexture;
        MouseState mouseState, previousmousestate;
        bool clicked = false;
        Texture2D brickTexture;
        List<Brick> bricks = new List<Brick>();
        Rectangle window;
        Texture2D paddleTexture;
        Ball ball1;
        Paddle paddle1;
        SoundEffect popSound;



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
            popSound = Content.Load<SoundEffect>("soundeffect/pop");


            bricks.Clear();
            for (int x = 30; x < 550; x += 30)
            {
                for (int y = 0; y < 180; y += 30)
                {
                    Brick brickrec = new Brick(brickTexture, new Rectangle(x, y, 22, 22));
                    bricks.Add(brickrec);
                }
            }

            ball1 = new Ball(ballTexture, new Rectangle(400, 250, 20, 20));
            paddle1 = new Paddle(paddleTexture, new Rectangle(275, 450, 100, 20), Vector2.Zero);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            paddle1.Update(mouseState);
            if (mouseState.LeftButton == ButtonState.Pressed && !clicked)
            {
                ball1.Speed = new Vector2(5, 5);
                clicked = true;

            }

            for (int i = 0; i < bricks.Count; i++)
            {
                if (ball1.Bounce(bricks[i]))
                {
                    popSound.Play();
                    bricks.RemoveAt(i);     
                    i--;    
                    break;
                }
            }





            // TODO: Add your update logic here

            ball1.Update(paddle1,  bricks);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            ball1.Draw(_spriteBatch);

            paddle1.Draw(_spriteBatch);


            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(_spriteBatch);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }

   
}

   
