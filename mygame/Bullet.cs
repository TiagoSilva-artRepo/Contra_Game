using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace mygame
{
    public class Bullet : Sprite, ICloneable
    {
        public bool DirectionRight { get; set; }
        public Bullet(Texture2D texture, Vector2 position) : base(texture, position)
        {
            this.DirectionRight = true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (DirectionRight==false)
            {
                Position = new Vector2(Position.X - 7f, Position.Y);
                return;
            }
            Position = new Vector2(Position.X + 7f, Position.Y);
        }

    }
}
