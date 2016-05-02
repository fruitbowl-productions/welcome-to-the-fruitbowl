using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Utilities;

namespace WelcomeToTheFruitBowl.Engine.Textures
{
    public class DualTexture
    {
        public enum DrawType
        {
            Normal,
            Ascii
        }

        private GameTexture normalTexture;
        private AsciiTexture asciiTexture;

        public DrawType TextureType { get; set; }

        public Vector2 Position
        {
            get { return normalTexture.Position; }
            set
            {
                normalTexture.Position = value;
                asciiTexture.Position = value;
            }
        }

        public float Width => normalTexture.Width;
        public float Height => normalTexture.Height;

        public float Top
        {
            get { return normalTexture.Top; }
            set
            {
                normalTexture.Top = value;
                asciiTexture.Top = value;
            }
        }

        public float Left
        {
            get { return normalTexture.Left; }
            set
            {
                normalTexture.Left = value;
                asciiTexture.Left = value;
            }
        }

        public float Right
        {
            get { return normalTexture.Right; }
            set
            {
                normalTexture.Right = value;
                asciiTexture.Right = value;
            }
        }

        public float Bottom
        {
            get { return normalTexture.Bottom; }
            set
            {
                normalTexture.Bottom = value;
                asciiTexture.Bottom = value;
            }
        }

        public Vector2 MoveUnit => asciiTexture.MoveUnit;

        public DualTexture(GameTexture texture, Dictionary<Color, Color> conversionMap, ImageProcessor.AsciiDrawMode asciiDrawMode)
        {
            normalTexture = texture;
            asciiTexture = normalTexture.ToAscii(conversionMap, asciiDrawMode);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (TextureType)
            {
                case DrawType.Ascii:
                    asciiTexture.Draw(spriteBatch);
                    break;
                case DrawType.Normal:
                    normalTexture.Draw(spriteBatch);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
