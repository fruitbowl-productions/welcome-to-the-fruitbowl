using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WelcomeToTheFruitBowl.Engine;

namespace WelcomeToTheFruitBowl
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Console console;

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
            Engine.Keyboard.Update();

            if (Engine.Keyboard.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            console.Update();

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            new AsciiTexture(Assets.AsciiTextures.ElfTexture, new Vector2(100, 100), Assets.Fonts.ConsoleFont).Draw(spriteBatch);
            console.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
