using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WelcomeToTheFruitBowl.Engine.Textures
{
    public class AsciiTexture
    {
        public const string FillDrawMode = "██";
        public const string DarkDrawMode = "▓▓";
        public const string MediumDrawMode = "▒▒";
        public const string LightDrawMode = "░░";
        public const string BinaryDrawMode = "01";
        private readonly SpriteFont font;

        private readonly List<AsciiCharacter> relativeTexture;

        public Vector2 Position;

        private Vector2 scale;

        public AsciiTexture(GameTexture originalTexture, List<AsciiCharacter> relativeTexture, Vector2 position,
            string drawMode)
        {
            Position = position;
            font = Assets.Fonts.PixelFont;
            this.relativeTexture = relativeTexture;
            DrawMode = drawMode;
            SetScale(originalTexture);
        }

        private IEnumerable<AsciiCharacter> Texture
        {
            get
            {
                return relativeTexture.Select(character =>
                {
                    var newPosition = character.Position*scale*font.MeasureString(DrawMode) + Position;
                    return new AsciiCharacter(character.Color, newPosition);
                });
            }
        }

        private Vector2 UnscaledUnitDimensions => font.MeasureString(DrawMode);

        public Vector2 MoveUnit => UnscaledUnitDimensions*scale;

        private Vector2 UnscaledCharacterSize => UnscaledUnitDimensions;
        private Vector2 CharacterSize => UnscaledCharacterSize*scale;

        private float CharacterWidth
        {
            get
            {
                var widths = relativeTexture.Select(asciiCharacter => asciiCharacter.Position.X).ToList();
                return widths.Max() - widths.Min() + 1;
            }
        }

        private float CharacterHeight
        {
            get
            {
                var heights = relativeTexture.Select(asciiCharacter => asciiCharacter.Position.Y).ToList();
                return heights.Max() - heights.Min() + 1;
            }
        }

        private float Width => CharacterSize.X*CharacterWidth;
        private float Height => CharacterSize.Y*CharacterHeight;

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

        public string DrawMode { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var character in Texture)
            {
                spriteBatch.DrawString(font, DrawMode, character.Position, character.Color, 0f, Vector2.Zero,
                    scale, SpriteEffects.None, 0f);
            }
        }

        public void SetScale(GameTexture texture)
        {
            scale.X = texture.Width/(UnscaledCharacterSize.X*CharacterWidth);
            scale.Y = texture.Height/(UnscaledCharacterSize.Y*CharacterHeight);
        }

        public class AsciiCharacter
        {
            public readonly Color Color;
            public Vector2 Position;

            public AsciiCharacter(Color color, Vector2 position)
            {
                Color = color;
                Position = position;
            }
        }
    }
}