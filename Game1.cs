using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        Ball korokball;
        Paddle paddle1;
        SoundEffect popSound;
        Song koroksound;
        Texture2D korokbg;
        int score = 0;
        SpriteFont scorefont;
        float timer = 0f;
       



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = false;
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
            ballTexture = Content.Load<Texture2D>("Images/korokball");
            brickTexture = Content.Load<Texture2D>("Images/brick");
            paddleTexture = Content.Load<Texture2D>("Images/korok paddle");
            popSound = Content.Load<SoundEffect>("soundeffect/pop");
            korokbg = Content.Load<Texture2D>("Images/korokbg");
            koroksound = Content.Load<Song>("soundeffect/koroksound");
            scorefont = Content.Load<SpriteFont>("Fonts/scorefont");


            bricks.Clear();
            for (int x = 30; x < 550; x += 30)
            {
                for (int y = 0; y < 180; y += 30)
                {
                    Brick brickrec = new Brick(brickTexture, new Rectangle(x, y, 22, 22));
                    bricks.Add(brickrec);
                }
            }

            korokball = new Ball(ballTexture, new Rectangle(400, 250, 35, 35));
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
                korokball.Speed = new Vector2(5, 5);
                clicked = true;
                MediaPlayer.Play(koroksound);



            }


            for (int i = 0; i < bricks.Count; i++)
            {
                if (korokball.Bounce(bricks[i]))
                {
                    popSound.Play();
                    bricks.RemoveAt(i);    
                    score += 1;
                    if (score == 10)
                    {
                        korokball.Speed = new Vector2(
                            korokball.Speed.X * 1.2f,
                            korokball.Speed.Y * 1.2f
                        );
                    }
                     else if (score == 20)
                    {
                        korokball.Speed = new Vector2(
                            korokball.Speed.X * 1.2f,
                            korokball.Speed.Y * 1.2f
                        );
                        }
                     else if (score == 30)
                    {
                        korokball.Speed = new Vector2(
                            korokball.Speed.X * 1.2f,
                            korokball.Speed.Y * 1.2f
                        );
                        }
                     
                    
                        

                        i--;    
                    break;
                }
                
            }
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;





            // TODO: Add your update logic here

            korokball.Update(paddle1,  bricks, mouseState, clicked);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            korokball.Draw(_spriteBatch);


            paddle1.Draw(_spriteBatch);




            for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].Draw(_spriteBatch);
            }
            _spriteBatch.Draw(korokbg, new Rectangle(0, 0, 600, 500), Color.White * 0.2f);
            _spriteBatch.DrawString(scorefont, "Score: " + score, new Vector2(30, 400), Color.White);
            _spriteBatch.DrawString(scorefont, "Time: " + (int)timer, new Vector2(30, 430), Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }

   
}

   
