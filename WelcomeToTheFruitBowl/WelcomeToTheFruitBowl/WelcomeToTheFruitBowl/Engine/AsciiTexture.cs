using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WelcomeToTheFruitBowl.Engine
{
    public class AsciiTexture
    {
        private readonly SpriteFont font;

        private readonly List<AsciiCharacter> texture;

        private Vector2 position;

        public AsciiTexture(IEnumerable<AsciiCharacter> rawTexture, Vector2 position)
        {
            font = Assets.Fonts.ConsoleFont;

            texture = rawTexture.Select(character =>
            {
                character.Position = character.Position*new Vector2(LetterWidth, LetterHeight) + position;
                return character;
            }).ToList();
        }

        private float Width
        {
            get { throw new NotImplementedException(); }
        }

        private float Height
        {
            get { throw new NotImplementedException(); }
        }

        // We can use any character, since Courier New is monospace.
        private float LetterWidth => font.MeasureString(" ").X;
        private float LetterHeight => font.MeasureString(" ").Y;

        public float Left
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Right
        {
            get { return position.X + Width; }
            set { position.X = value - Width; }
        }

        public float Top
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public float Bottom
        {
            get { return position.Y + Height; }
            set { position.Y = value - Height; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var character in texture)
            {
                spriteBatch.DrawString(font, character.Character.ToString(), character.Position, character.Color);
            }
        }

        public class AsciiCharacter
        {
            public readonly char Character;
            public readonly Color Color;
            public Vector2 Position;

            public AsciiCharacter(char character, Color color, Vector2 position)
            {
                Character = character;
                Color = color;
                Position = position;
            }
        }
    }
}