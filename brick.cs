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
        private Color _color;

        public Brick(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
            _color = Color.White;
            if (location.Height > 20)
            {
                _color = Color.Pink;
            }
            

        }
       
        
        // Expose the rectangle so other classes (Ball) can perform collision checks.
        public Rectangle Rect => _location;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, _color);
            

        }
        
        
    }
}


