using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using WelcomeToTheFruitBowl.Utilities;

namespace WelcomeToTheFruitBowl.Engine
{
    public class Console
    {
        private SpriteFont font;
        private int height;
        private int width;
        private Vector2 position;
        private List<string> outputLines;
        private string inputLine;
        private const string prompt = "> ";
        private int timer;

        public Console(SpriteFont spritefont)
        {
            font = spritefont;
            height = Screen.Height;
            width = Screen.Width;
            position = new Vector2(0, 0);
            outputLines = new List<string>();
            inputLine = prompt;
            timer = 0;
            outputLines.Add("Welcome To Defined Destiny!");
            outputLines.Add("A Text Based RPG Classic!");

        }

        public void Update()
        {
            timer += 1;
            if (timer > 50)
            {
                timer = 0;
            }
            // Update Orientation
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int counter = 0;
            foreach (string line in outputLines.ReverseInPlace())
            {
                spriteBatch.DrawString(font, line, new Vector2(0,position.Y + height - ((2 + counter) * font.MeasureString(prompt).Y)), Color.White);
                counter += 1;
            }        
            if (timer <= 25)
            {

                spriteBatch.DrawString(font, inputLine, new Vector2(0, position.Y + height - font.MeasureString(prompt).Y), Color.White);
            }
            else if (timer <= 50)
            {
                spriteBatch.DrawString(font,inputLine + "_", new Vector2(0, position.Y + height - font.MeasureString(prompt).Y), Color.White);
            }
        }


    }
}
