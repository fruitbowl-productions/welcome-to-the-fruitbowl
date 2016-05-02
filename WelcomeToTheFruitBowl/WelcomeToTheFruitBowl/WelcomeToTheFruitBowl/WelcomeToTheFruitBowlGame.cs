using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WelcomeToTheFruitBowl.Engine;
using WelcomeToTheFruitBowl.Engine.Keyboards;
using Console = WelcomeToTheFruitBowl.Engine.Console;
using Keyboard = WelcomeToTheFruitBowl.Engine.Keyboards.Keyboard;

namespace WelcomeToTheFruitBowl
{
    public class WelcomeToTheFruitBowlGame : Game
    {
        public static readonly Queue<Action<SpriteBatch>> DrawActions = new Queue<Action<SpriteBatch>>();
        private readonly GraphicsDeviceManager graphics;
        private Console console;
        private SpriteBatch spriteBatch;
        private AsciiTexture elf;

        public WelcomeToTheFruitBowlGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Screen.Initialize(graphics.GraphicsDevice);
            Assets.Initialize(Content);

            console = new Console();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            elf = new AsciiTexture(Assets.AsciiTextures.ElfTexture, new Vector2(0, 0));
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();
            DelayedKeyboard.Update(gameTime);

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            console.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White); // TODO Change back to Color.Black.
            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);

            console.Draw(spriteBatch);
            elf.Position += elf.MoveUnit * (float)gameTime.ElapsedGameTime.TotalSeconds;
            elf.Draw(spriteBatch);

            // Asynchronous drawing
            while (DrawActions.Count != 0)
            {
                DrawActions.Dequeue().Invoke(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}