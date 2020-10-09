using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace mygame
{
    public class Sprite : Component
    {

        protected Texture2D texture;
        protected KeyboardState currentKey;
        protected KeyboardState previousKey;
        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(texture, Position, Color.White);
        }

        public Sprite(Texture2D texture, Vector2 position )
        {
            this.texture = texture;
            this.Position = position;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
        }
    }
}
