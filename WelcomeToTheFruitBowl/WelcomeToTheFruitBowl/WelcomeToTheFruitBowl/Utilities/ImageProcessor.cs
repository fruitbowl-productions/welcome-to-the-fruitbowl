using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Engine;

namespace WelcomeToTheFruitBowl.Utilities
{
    public static class ImageProcessor
    {
        public static IEnumerable<AsciiTexture.AsciiCharacter> ConvertTextureToAscii(Texture2D texture, Color alpha)
        {
            var pixelizedTexture = PixelizeTexture(texture).ToList();

            for (var y = 0; y < pixelizedTexture.Count; ++y)
            {
                for (var x = 0; x < pixelizedTexture.Count; ++x)
                {
                    
                }
            }

            throw new NotImplementedException();
        }

        private static IEnumerable<IEnumerable<Tuple<char, Color>>> PixelizeTexture(Texture2D texture)
        {
            var pixels = new Tuple<char, Color>[texture.Height][];

            for (var y = 0; y < texture.Height; ++y)
            {
                for (var x = 0; x < texture.Width; ++x)
                {
                    var retrievedColor = new Color[1];
                    texture.GetData(0, new Rectangle(x, y, 1, 1), retrievedColor, 0, 1);
                    pixels[y][x] = new Tuple<char, Color>('o', retrievedColor[0]);
                }
            }

            throw new NotImplementedException();
        }
    }
}
