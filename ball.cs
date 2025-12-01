using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Breakout_game_2
{
    public class ball
    {

        private Texture2D _texture;
        private Vector2 _speed;
        private Rectangle _location;

        public ball(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
            _speed = Vector2.Zero;
        }

        public void Update()
        {
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;
            if (_location.Right >= 600 || _location.Left <= 0)
            {
                _speed.X = -_speed.X;
            }
            if (_location.Bottom >= 500 || _location.Top <= 0)
            {
                _speed.Y = -_speed.Y;
            }   
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.Black);
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
