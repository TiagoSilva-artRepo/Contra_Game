using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace contra
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Sprite target)
        {
            if (target.Position.X < (ContraGame.ScreenWidth + target.Rectangle.Width) && 
                (target.Position.X + target.Rectangle.Width / 2) > (ContraGame.ScreenWidth / 2))
            {
                 Transform = Matrix.CreateTranslation(
                    -target.Position.X - (target.Rectangle.Width / 2),
                    0,          
                    0) * Matrix.CreateTranslation(
                        ContraGame.ScreenWidth / 2,
                        0,
                        0);
            }
        }
    }
}
