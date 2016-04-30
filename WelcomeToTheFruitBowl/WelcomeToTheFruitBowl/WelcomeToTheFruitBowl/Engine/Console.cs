using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        private int progress;

        public Console(SpriteFont spritefont)
        {
            font = spritefont;
            outputLines = new List<string>();
            inputLine = "";
            progress = 0;

            timer = new DelayedTimer(() => { }, () =>
            {
                Game1.DrawActions.Enqueue(spriteBatch =>
                {
                    spriteBatch.DrawString(font, "_",
                        new Vector2(font.MeasureString(prompt + inputLine).X,
                            Screen.Height - font.MeasureString(prompt).Y), Color.White);
                });
            }, TimeSpan.FromMilliseconds(500));
            outputLines.Add("Welcome to Defined Destiny!");
            outputLines.Add("A Text Based RPG Classic!");
        }

        public void Update(GameTime gameTime)
        {
            bool typed = false;
            timer.Update(gameTime);
            foreach (var key in Keyboards.DelayedKeyboard.PressedKeys)
            {
                typed = true;
            }
            if (progress == 0 && typed)
            {
               ContinueWrite("Hello", "You are new here? Arn't you?");
            }
            if (progress == 1 && typed)
            {
                ContinueWrite("What?", "What's your name");
            }
            if (progress == 2 && typed)
            {
                ContinueWrite("Dolor", "I love your creativity!", "What Race are you?");
            }
            if (progress == 3 && typed)
            {
                ContinueWrite("Human", "Really, Not even an elf?");
            }
            if (progress == 4 && typed)
            {
                ContinueWrite("Sure", "So you decide to be a human!", "Where will you begin your journey?");
            }
            if (progress == 5 && typed)
            {
                ContinueWrite("A much better place than I was ", "(screen cracks)");
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

        private void ContinueWrite(string message, string responce)
        {
            try
            {
                inputLine += message[inputLine.Length];
            }
            catch
            {
                if (Keyboards.DelayedKeyboard.IsKeyDown(Keys.Enter))
                {
                    progress += 1;
                    outputLines.Add("> " + inputLine);
                    inputLine = "";
                    outputLines.Add(responce);

                }
                
            }
        }
        private void ContinueWrite(string message, string responce, string secondresponce)
        {
            try
            {
                inputLine += message[inputLine.Length];
            }
            catch
            {
                if (Keyboards.Keyboard.IsKeyDown(Keys.Enter))
                {
                    progress += 1;
                    outputLines.Add("> " + inputLine);
                    inputLine = "";
                    outputLines.Add(responce);
                    outputLines.Add(secondresponce);
                }

            }
        }
    }
}
