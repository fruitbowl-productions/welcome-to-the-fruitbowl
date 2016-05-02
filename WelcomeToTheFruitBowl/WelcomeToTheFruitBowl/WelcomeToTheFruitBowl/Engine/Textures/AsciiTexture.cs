using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WelcomeToTheFruitBowl.Engine.Textures
{
    public class AsciiTexture
    {
        private readonly SpriteFont font;

        private readonly List<AsciiCharacter> relativeTexture;

        public Vector2 Position;

        public AsciiTexture(List<AsciiCharacter> relativeTexture, Vector2 position, float scale)
        {
            Position = position;
            font = Assets.Fonts.PixelFont;
            this.relativeTexture = relativeTexture;
            Scale = scale;
        }

        private IEnumerable<AsciiCharacter> Texture
        {
            get
            {
                return relativeTexture.Select(character =>
                {
                    var newPosition = character.Position*Scale*font.MeasureString(character.Character) + Position;
                    return new AsciiCharacter(character.Character, character.Color, newPosition);
                });
            }
        }

        public Vector2 MoveUnit => font.MeasureString("  ");

        public float Scale { get; set; }

        private float Width
        {
            get { throw new NotImplementedException(); }
        }

        private float Height
        {
            get { throw new NotImplementedException(); }
        }

        public float Left
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        public float Right
        {
            get { return Position.X + Width; }
            set { Position.X = value - Width; }
        }

        public float Top
        {
            get { return Position.Y; }
            set { Position.Y = value; }
        }

        public float Bottom
        {
            get { return Position.Y + Height; }
            set { Position.Y = value - Height; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var character in Texture)
            {
                spriteBatch.DrawString(font, character.Character, character.Position, character.Color, 0f, Vector2.Zero,
                    Scale, SpriteEffects.None, 0f);
            }
        }

        public class AsciiCharacter
        {
            public readonly string Character;
            public readonly Color Color;
            public Vector2 Position;

            public AsciiCharacter(string character, Color color, Vector2 position)
            {
                Character = character;
                Color = color;
                Position = position;
            }
        }
    }
}