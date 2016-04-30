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

        public Console(SpriteFont spritefont)
        {
            font = spritefont;
            height = Screen.Height;
            width = Screen.Width;
            position = new Vector2(0, 0);
            outputLines = new List<string>();
            inputLine = "> ";
        }

        public void Update()
        {
            
            // Update Orientation
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Previous Type 
            // Draw Console Type 
            spriteBatch.DrawString(font, inputLine, position, Color.White);
        }


    }
}
