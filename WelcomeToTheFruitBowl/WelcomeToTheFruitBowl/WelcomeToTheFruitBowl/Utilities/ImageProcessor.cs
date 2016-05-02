using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WelcomeToTheFruitBowl.Engine.Textures;

namespace WelcomeToTheFruitBowl.Utilities
{
    public static class ImageProcessor
    {
        public static List<AsciiTexture.AsciiCharacter> ConvertTextureToAscii(Texture2D texture, 
            Dictionary<Color, Color> conversionMap)
        {
            var result = new List<AsciiTexture.AsciiCharacter>();
            var pixelizedTexture = PixelizeTexture(texture);

            for (var x = 0; x < pixelizedTexture.Length; ++x)
            {
                for (var y = 0; y < pixelizedTexture[x].Length; ++y)
                {
                    if (pixelizedTexture[x][y].A == 0) continue;
                    result.Add(new AsciiTexture.AsciiCharacter(pixelizedTexture[x][y], new Vector2(x, y)));
                }
            }

            return result.Select(asciiCharacter =>
            {
                var color = asciiCharacter.Color;
                var position = asciiCharacter.Position;

                if (conversionMap.ContainsKey(asciiCharacter.Color))
                {
                    color = conversionMap[asciiCharacter.Color];
                }

                return new AsciiTexture.AsciiCharacter(color, position);
            }).ToList();
        }

        private static Color[][] PixelizeTexture(Texture2D texture)
        {
            var pixels = new Color[texture.Width][];

            for (var i = 0; i < texture.Width; ++i)
            {
                pixels[i] = new Color[texture.Height];
            }

            for (var x = 0; x < texture.Width; ++x)
            {
                for (var y = 0; y < texture.Height; ++y)
                {
                    var retrievedColor = new Color[1];
                    texture.GetData(0, new Rectangle(x, y, 1, 1), retrievedColor, 0, 1);
                    pixels[x][y] = retrievedColor[0];
                }
            }
            
            return pixels;
        }
    }
}