﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace mygame
{
    public class Game1 : Game
    {

        private List<Sprite> components;
        private Sprite background;
        private Camera _camera;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int ScreenHeight;
        public static int ScreenWidth;
        
        private Player player;
        private Enemy enemy;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Window.Title = "My game";
            //Window.AllowUserResizing = true;
                
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            _camera = new Camera();
            background = new Sprite(Content.Load<Texture2D>("background"), new Vector2(0, -285));
            player = new Player(Content.Load<Texture2D>("ct"), new Vector2(375,10));
            player.Bullet = new Bullet(Content.Load<Texture2D>("bullet"), new Vector2(-10, -10));
            enemy = new Enemy(Content.Load<Texture2D>("swat"), new Vector2(700,240));
            enemy.Bullet = new Bullet(Content.Load<Texture2D>("bullet"), new Vector2(-10, -10));

            components = new List<Sprite>()
            {
                background,
                player,
                player.Bullet,
                enemy,
            };

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach(var component in components.ToArray())
            {
                component.Update(gameTime, components);
                _camera.Follow(player);
                base.Update(gameTime);
            }

          
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: _camera.Transform);
            foreach(var component in components)
            {
                component.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
