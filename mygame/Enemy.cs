using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace contra
{
    class Enemy : Sprite
    {
        public Bullet Bullet { get; set; }
        private float timeSinceLastShot = 0f;


        public Enemy(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            timeSinceLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Random rnd = new Random();
            var n = rnd.NextDouble();

            if(timeSinceLastShot>=2f && n<=0.1)
            {
                Shoot(sprites);
            }
        }

        private void Shoot(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.Position = new Vector2(this.Position.X, this.Position.Y + 32);
            bullet.DirectionRight = false;
            sprites.Add(bullet);
            timeSinceLastShot = 0f;
        }

    }
}
