using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using WelcomeToTheFruitBowl.Utilities;
using WelcomeToTheFruitBowl.Utilities.Timers;

namespace WelcomeToTheFruitBowl.Engine
{
    public class Console
    {
        private SpriteFont font;
        private List<string> outputLines;
        private string inputLine;
        private const string prompt = "> ";
        private DelayedTimer timer;

        private SpriteBatch spriteBatch;

        public Console(SpriteFont spritefont)
        {
            font = spritefont;
            outputLines = new List<string>();
            inputLine = "";

            timer = new DelayedTimer(() => { }, () =>
            {
                Game1.DrawActions.Enqueue(spriteBatch =>
                {
                    spriteBatch.DrawString(font, "_",
                        new Vector2(font.MeasureString(prompt + inputLine).X,
                            Screen.Height - font.MeasureString(prompt).Y), Color.White);
                });
            }, TimeSpan.FromMilliseconds(500));
        }

        public void Update(GameTime gameTime)
        {
            timer.Update(gameTime);

            foreach (var key in Keyboards.DelayedKeyboard.PressedKeys)
            {
                inputLine += key.ToString();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.spriteBatch == null)
            {
                this.spriteBatch = spriteBatch;
            }

            var counter = 0;
            foreach (var line in outputLines.ReverseInPlace())
            {
                spriteBatch.DrawString(font, line,
                    new Vector2(0, Screen.Height - ((2 + counter)*font.MeasureString(prompt).Y)), Color.White);
                counter += 1;
            }

            spriteBatch.DrawString(font, prompt, new Vector2(0, Screen.Height - font.MeasureString(prompt).Y), Color.White);
            spriteBatch.DrawString(font, inputLine, new Vector2(font.MeasureString(prompt).X, Screen.Height - font.MeasureString(prompt).Y),
                Color.White);
        }
    }
}
