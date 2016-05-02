using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Utilities;

namespace WelcomeToTheFruitBowl.Engine.Textures
{
    public class GameTexture
    {
        public Vector2 Position;

        private Texture2D texture;

        public float Width => texture.Width;
        public float Height => texture.Height;

        public float Left
        {
            get
            {
                return Position.X;
            }
            set
            {
                Position.X = value;
            }
        }

        public float Right
        {
            get
            {
                return Position.X + Width;
            }
            set
            {
                Position.X = value - Width;
            }
        }

        public float Top
        {
            get
            {
                return Position.Y;
            }
            set
            {
                Position.Y = value;
            }
        }

        public float Bottom
        {
            get
            {
                return Position.Y + Height;
            }
            set
            {
                Position.Y = value - Height;
            }
        }

        public GameTexture(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White);
        }

        public AsciiTexture ToAscii(Dictionary<Color, Color> conversionMap, ImageProcessor.AsciiDrawMode asciiDrawMode)
        {
            return new AsciiTexture(ImageProcessor.ConvertTextureToAscii(texture, Color.White, conversionMap, asciiDrawMode), Position);
        }
    }
}
