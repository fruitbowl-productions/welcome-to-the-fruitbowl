using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WelcomeToTheFruitBowl.Engine;
using Console = WelcomeToTheFruitBowl.Engine.Console;

namespace WelcomeToTheFruitBowl
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Console console;

        public static readonly Queue<Action<SpriteBatch>> DrawActions = new Queue<Action<SpriteBatch>>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            Screen.Initialize(graphics.GraphicsDevice);
            Assets.Initialize(Content);
            
            console = new Console(Assets.Fonts.ConsoleFont);

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

            new AsciiTexture(Assets.AsciiTextures.ElfTexture, new Vector2(100, 100), Assets.Fonts.ConsoleFont).Draw(spriteBatch);
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
