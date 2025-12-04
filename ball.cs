using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout_game_2
{
    public class Ball
    {
        private Texture2D _texture;
        private Vector2 _speed;
        private Rectangle _location;

        public Rectangle Rect => _location; // auto-updates with _location

        public Ball(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
            _speed = Vector2.Zero;
        }

        public void Update(Paddle paddle, List<Brick> bricks)
        {
            // Move ball
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;


            // Paddle Bounce
            if (_location.Intersects(paddle.Bounds))
            {
                _speed.Y = -_speed.Y;
            }
            
            for (int i = 0; i < bricks.Count; i++)
            {
                if (Bounce(bricks[i]))
                {
                    bricks.RemoveAt(i);
                    i--; // Adjust index after removal
                }
            }

            // Wall bounce
            if (_location.Right >= 600 || _location.Left <= 0)
            {
                _speed.X = -_speed.X;
            }

            if (_location.Top <= 0 || _location.Bottom > 600)
            {
                _speed.Y = -_speed.Y;
            }
        }

        public void BouncePaddle(Paddle paddle1)
        {
            if (Rect.Intersects(paddle1.Bounds))
            {
                _speed.Y = -_speed.Y;
            }
        }

        public bool Bounce(Brick brick)
        {
            if (_location.Intersects(brick.Rect))
            {
                _speed.Y = -_speed.Y;
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int X
        {
            get { return _location.X; }
            set { _location.X = value; }
        }
    }
}