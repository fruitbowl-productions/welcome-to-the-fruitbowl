using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WelcomeToTheFruitBowl
{
    public class WelcomeToTheFruitBowlGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Engine.Console console;

        public static readonly Queue<Action<SpriteBatch>> DrawActions = new Queue<Action<SpriteBatch>>();

        public WelcomeToTheFruitBowlGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            Engine.Screen.Initialize(graphics.GraphicsDevice);
            Assets.Initialize(Content);
            
            console = new Engine.Console();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void Update(GameTime gameTime)
        {
            Engine.Keyboards.Keyboard.Update();
            Engine.Keyboards.DelayedKeyboard.Update(gameTime);

            if (Engine.Keyboards.Keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            console.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            new Engine.AsciiTexture(Assets.AsciiTextures.ElfTexture, new Vector2(100, 100)).Draw(spriteBatch);
            console.Draw(spriteBatch);

            while (DrawActions.Count != 0)
            {
                DrawActions.Dequeue().Invoke(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
