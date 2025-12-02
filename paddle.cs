using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Breakout_game_2
{
    public class Paddle
    {

        public Texture2D _texture;
        public Rectangle _location;
        public Vector2 _speed;
    
    public Paddle(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _texture = texture; _location = location;
            _speed = speed;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.Blue);
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
