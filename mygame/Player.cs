using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace mygame
{
    class Player : Sprite
    {

        private Vector2 speed;
        private bool hasJumped;
        public Bullet Bullet { get; set; }

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            this.hasJumped = true;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Position += speed;

            previousKey = currentKey;
            bool right;

            currentKey = Keyboard.GetState();

            if (currentKey.IsKeyDown(Keys.Left))
                Position = new Vector2(Position.X - 3f, Position.Y);

            if (currentKey.IsKeyDown(Keys.Right))
                Position = new Vector2(Position.X + 3f, Position.Y);

            if (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))

                Shoot(sprites, right);

            if (currentKey.IsKeyDown(Keys.Up) && hasJumped == false)
            {
                Position = new Vector2(Position.X, Position.Y - 10f);
                speed.Y = -5f;
                hasJumped = true;
            }

            
            if (hasJumped == false)
            {
                speed.Y = 0f;
            }

            if(Position.Y + texture.Height >= 330)
            {
                hasJumped = false;
            }

            if (hasJumped == true)
            {
                float i = 1;
                speed.Y += 0.15f * i;
            }

        }

        private void Shoot(List<Sprite> sprites, bool directionRight)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Position = new Vector2(this.Position.X + 90, this.Position.Y + 32);
            if(!directionRight)
            {
                bullet.DirectionRight = false;
            }
            sprites.Add(bullet);
        }
            
    }
}
