using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame_Topic_2___Lists_And_Loops
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator;
        Random generator2;
        Rectangle window;
        Texture2D spaceBackgroundTecture;

        List<Rectangle> planetRects;
        List<Texture2D> planetTextures;

        List<Texture2D> textures;

        float seconds;
        float respawnTime;
       


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            generator = new Random();
            generator2 = new Random();
            textures = new List<Texture2D>();
            planetTextures = new List<Texture2D>();
            planetRects = new List<Rectangle>();

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            seconds = 0f;
            respawnTime = 3f;

            base.Initialize();

            //Creates Planets:
            for (int i = 0; i < 30; i++) 
            {
                int size = generator.Next(20, 51); //Sizes anywhere from 20-50

                planetRects.Add(new Rectangle(generator.Next(window.Width - size), generator.Next(window.Height - size), size, size));
                planetTextures.Add(textures[generator.Next(textures.Count)]);
            }


            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            spaceBackgroundTecture = Content.Load<Texture2D>("Images/space_background");
            for (int i = 1; i <= 13; i++) 
            {
               textures.Add(Content.Load<Texture2D>("Images/16-bit-planet" + i));
            }


        }

        protected override void Update(GameTime gameTime)
        {
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (seconds > respawnTime) 
            {
                int size = generator.Next(20, 51); //Sizes anywhere from 20-50

                planetRects.Add(new Rectangle(generator.Next(window.Width - size), generator.Next(window.Height - size), size, size));
                planetTextures.Add(textures[generator.Next(textures.Count)]);
                seconds = 0; //Without this, a new planet would spawn every single frame!
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(spaceBackgroundTecture, window, Color.White);

            for (int i = 0; i < planetRects.Count; i++) 
            {
                _spriteBatch.Draw(planetTextures[i], planetRects[i], Color.White);
            }



            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
