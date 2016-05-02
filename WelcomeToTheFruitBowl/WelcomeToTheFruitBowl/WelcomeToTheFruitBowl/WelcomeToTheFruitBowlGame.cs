using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WelcomeToTheFruitBowl.Engine;
using WelcomeToTheFruitBowl.Engine.Keyboards;
using WelcomeToTheFruitBowl.Engine.Textures;
using Console = WelcomeToTheFruitBowl.Engine.Console;
using Keyboard = WelcomeToTheFruitBowl.Engine.Keyboards.Keyboard;

namespace WelcomeToTheFruitBowl
{
    public class WelcomeToTheFruitBowlGame : Game
    {
        public static readonly Queue<Action<SpriteBatch>> DrawActions = new Queue<Action<SpriteBatch>>();
        private readonly GraphicsDeviceManager graphics;
        private Console console;
        private DualTexture elf;
        private SpriteBatch spriteBatch;

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

            elf = new DualTexture(new GameTexture(Assets.Textures.ElfTexture, Vector2.Zero, 10f),
                new Dictionary<Color, Color>(), AsciiTexture.BinaryDrawMode);
        }

        protected override void Update(GameTime gameTime)
        {
            Keyboard.Update();
            DelayedKeyboard.Update(gameTime);

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.IsKeyNowDown(Keys.Space))
            {
                switch (elf.TextureType)
                {
                    case DualTexture.DrawType.Ascii:
                        elf.TextureType = DualTexture.DrawType.Normal;
                        break;
                    case DualTexture.DrawType.Normal:
                        elf.TextureType = DualTexture.DrawType.Ascii;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            console.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White); // TODO Change back to Color.Black.

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);

            console.Draw(spriteBatch);

            elf.Position += elf.MoveUnit*(float) gameTime.ElapsedGameTime.TotalSeconds;
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