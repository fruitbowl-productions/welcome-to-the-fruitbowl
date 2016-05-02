using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WelcomeToTheFruitBowl
{
    public static class Assets
    {
        private static ContentManager content;

        public static void Initialize(ContentManager contentInput)
        {
            content = contentInput;

            Textures.Initialize();
            Fonts.Initialize();
        }

        public static class Textures
        {
            public static Texture2D ElfTexture;

            public static void Initialize()
            {
                ElfTexture = LoadTexture("Elf");
            }

            private static Texture2D LoadTexture(string textureName)
                => content.Load<Texture2D>($"Textures\\{textureName}");
        }

        public static class Fonts
        {
            public static SpriteFont ConsoleFont;
            public static SpriteFont PixelFont;

            public static void Initialize()
            {
                ConsoleFont = LoadFont("Console");
                PixelFont = LoadFont("Pixel");
            }

            private static SpriteFont LoadFont(string fontName) => content.Load<SpriteFont>($"Fonts\\{fontName}");
        }
    }
}