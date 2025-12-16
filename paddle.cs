using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout_game_2
{
    public class Paddle
    {
        private Texture2D _texture;
        private Rectangle _location;
        private Vector2 _speed;

        public Paddle(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _texture = texture;
            _location = location;
            _speed = speed;
        }

        public Rectangle Bounds => _location;

        public Vector2 Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public void Update(MouseState mouseState)
        {
            _location.X = mouseState.X - _location.Width / 2;
            if (_location.X < 0)
                _location.X = 0;

            if (_location.Right > 600)
                _location.X = 600 - _location.Width;
        }


        public int X
        {
            get => _location.X;
            set => _location.X = value;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }
    }
}
