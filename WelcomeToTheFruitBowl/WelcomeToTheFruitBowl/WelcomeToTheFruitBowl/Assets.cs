using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Engine;

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
                ElfTexture = new List<AsciiTexture.AsciiCharacter>
                {
                    new AsciiTexture.AsciiCharacter('o', Color.White, Vector2.Zero)
                };
            }
        }

        public static class Fonts
        {
            public static SpriteFont ConsoleFont;

            public static void Initialize()
            {
                ConsoleFont = content.Load<SpriteFont>(@"Fonts\Console");
            }
        }
    }
}