﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace contra
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch sprite);

        public abstract void Update(GameTime gameTime, List<Sprite> sprites);
    }
}
