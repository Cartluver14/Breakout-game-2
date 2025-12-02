using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout_game_2
{
    public class Brick
    {
        private Texture2D _texture;
        private Rectangle _location;


        public Brick(Texture2D texture, Rectangle location)
        {
            _texture = texture; _location = location;


        } public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.Red);
        }
    }
}


