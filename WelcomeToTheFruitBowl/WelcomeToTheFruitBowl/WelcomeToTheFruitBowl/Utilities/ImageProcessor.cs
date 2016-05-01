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
        public enum DrawMode
        {
            Fill,
            Dark,
            Medium,
            Light,
            Binary
        }

        public static List<AsciiTexture.AsciiCharacter> ConvertTextureToAscii(Texture2D texture, Color alpha,
            Dictionary<Color, Color> conversionMap, DrawMode drawMode)
        {
            var result = new List<AsciiTexture.AsciiCharacter>();
            var pixelizedTexture = PixelizeTexture(texture, drawMode);

            for (var x = 0; x < pixelizedTexture.Length; ++x)
            {
                for (var y = 0; y < pixelizedTexture[x].Length; ++y)
                {
                    if (pixelizedTexture[x][y].Item2 == alpha) continue;
                    result.Add(new AsciiTexture.AsciiCharacter(pixelizedTexture[x][y].Item1,
                        pixelizedTexture[x][y].Item2, new Vector2(x, y)));
                }
            }

            return result.Select(asciiCharacter =>
            {
                var character = asciiCharacter.Character;
                var color = asciiCharacter.Color;
                var position = asciiCharacter.Position;

                if (conversionMap.ContainsKey(asciiCharacter.Color))
                {
                    color = conversionMap[asciiCharacter.Color];
                }

                return new AsciiTexture.AsciiCharacter(character, color, position);
            }).ToList();
        }

        private static Tuple<string, Color>[][] PixelizeTexture(Texture2D texture, DrawMode drawMode)
        {
            var pixels = new Tuple<string, Color>[texture.Width][];

            for (var i = 0; i < texture.Width; ++i)
            {
                pixels[i] = new Tuple<string, Color>[texture.Height];
            }

            for (var x = 0; x < texture.Width; ++x)
            {
                for (var y = 0; y < texture.Height; ++y)
                {
                    var retrievedColor = new Color[1];
                    texture.GetData(0, new Rectangle(x, y, 1, 1), retrievedColor, 0, 1);

                    var drawUnit = "";
                    switch (drawMode)
                    {
                        case DrawMode.Fill:
                            // Use unprintable characters so that we can use the default character (defined in Pixel.spritefont).
                            drawUnit = "██";
                            break;
                        case DrawMode.Dark:
                            drawUnit = "▓▓";
                            break;
                        case DrawMode.Medium:
                            drawUnit = "▒▒";
                            break;
                        case DrawMode.Light:
                            drawUnit = "░░";
                            break;
                        case DrawMode.Binary:
                            drawUnit = "ZZ";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    pixels[x][y] = new Tuple<string, Color>(drawUnit, retrievedColor[0]);
                }
            }

            return pixels;
        }
    }
}
