using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Engine;

namespace WelcomeToTheFruitBowl.Utilities
{
    public static class ImageProcessor
    {
        public static List<AsciiTexture.AsciiCharacter> ConvertTextureToAscii(Texture2D texture, Color alpha)
        {
            var result = new List<AsciiTexture.AsciiCharacter>();
            var pixelizedTexture = PixelizeTexture(texture);

            for (var x = 0; x < pixelizedTexture.Length; ++x)
            {
                for (var y = 0; y < pixelizedTexture[x].Length; ++y)
                {
                    if (pixelizedTexture[x][y].Item2 == alpha) continue;
                    result.Add(new AsciiTexture.AsciiCharacter(pixelizedTexture[x][y].Item1, pixelizedTexture[x][y].Item2, new Vector2(x, y)));
                }
            }

            return result;
        }

        private static Tuple<char, Color>[][] PixelizeTexture(Texture2D texture)
        {
            var pixels = new Tuple<char, Color>[texture.Height][];

            for (var x = 0; x < texture.Width; ++x)
            {
                for (var y = 0; y < texture.Width; ++y)
                {
                    var retrievedColor = new Color[1];
                    texture.GetData(0, new Rectangle(x, y, 1, 1), retrievedColor, 0, 1);
                    pixels[x][y] = new Tuple<char, Color>('o', retrievedColor[0]);
                }
            }

            return pixels;
        }
    }
}
