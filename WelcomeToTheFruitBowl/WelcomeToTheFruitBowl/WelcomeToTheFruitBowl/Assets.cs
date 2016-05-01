using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Engine;
using WelcomeToTheFruitBowl.Utilities;

namespace WelcomeToTheFruitBowl
{
    public static class Assets
    {
        private static ContentManager content;

        public static void Initialize(ContentManager contentInput)
        {
            content = contentInput;

            AsciiTextures.Initialize();
            Fonts.Initialize();
        }

        public static class AsciiTextures
        {
            public static List<AsciiTexture.AsciiCharacter> ElfTexture;

            public static void Initialize()
            {
                ElfTexture = ImageProcessor.ConvertTextureToAscii(LoadTexture("Elf"), Color.White, new Dictionary<Color, Color>()
                {
                    // { Color.Black, Color.Gray }
                }, ImageProcessor.DrawMode.Fill);
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