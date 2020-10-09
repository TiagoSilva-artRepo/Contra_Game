using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace contra
{
    class Player : Sprite
    {

        private Vector2 speed;
        private bool hasJumped;
        public Bullet Bullet { get; set; }
        public int Health { get; set; }

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            this.hasJumped = true;
            this.Health = 100;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Position += speed;

            previousKey = currentKey;
            bool goingRight = true;

            currentKey = Keyboard.GetState();

            if (currentKey.IsKeyDown(Keys.Left) && this.Position.X > 0)
                Position = new Vector2(Position.X - 3f, Position.Y);

            if (currentKey.IsKeyDown(Keys.Right) && this.Position.X < ContraGame.ScreenWidth + ContraGame.ScreenWidth/2 - texture.Width/2)
                Position = new Vector2(Position.X + 3f, Position.Y);

            if (currentKey.IsKeyDown(Keys.Space) && previousKey.IsKeyUp(Keys.Space))

                Shoot(sprites, goingRight);

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

        private void Shoot(List<Sprite> sprites, bool goingRight)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Position = new Vector2(this.Position.X + 90, this.Position.Y + 32);
            if(!goingRight)
            {
                bullet.GoingRight = false;
            }
            sprites.Add(bullet);
        }

        public void decreaseHealth()
        {
            Health -= 10;
        }
            
    }
}
