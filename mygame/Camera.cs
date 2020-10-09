using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace mygame
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Sprite target)
        {
            if (target.Position.X < (Game1.ScreenWidth + target.Rectangle.Width) && 
                (target.Position.X + target.Rectangle.Width / 2) > (Game1.ScreenWidth / 2))
            {
                 Transform = Matrix.CreateTranslation(
                    -target.Position.X - (target.Rectangle.Width / 2),
                    0,          
                    0) * Matrix.CreateTranslation(
                        Game1.ScreenWidth / 2,
                        0,
                        0);
            }
        }
    }
}
