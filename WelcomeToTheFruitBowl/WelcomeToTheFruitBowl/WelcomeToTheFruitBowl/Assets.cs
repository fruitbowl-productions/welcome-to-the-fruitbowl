using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Engine;

namespace WelcomeToTheFruitBowl
{
    public static class Assets
    {
        public static ContentManager Content;

        public static void Initialize(ContentManager content)
        {
            Content = content;

            AsciiTextures.Initialize();
            Fonts.Initialize();
        }

        public static class AsciiTextures
        {
            public static List<AsciiTexture.AsciiCharacter> ElfTexture;

            public static void Initialize()
            {
                ElfTexture = new List<AsciiTexture.AsciiCharacter>()
                {
                    new AsciiTexture.AsciiCharacter(Color.White, 'a', new Vector2(0, 0))
                };
            }
        }

        public static class Fonts
        {
            public static SpriteFont ConsoleFont;

            public static void Initialize()
            {
                ConsoleFont = Content.Load<SpriteFont>(@"Fonts\Console");
            }
        }
    }
}
