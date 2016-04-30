using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WelcomeToTheFruitBowl.Engine
{
    public class Console
    {
        private SpriteFont font;
        private int height;
        private int width;
        private Vector2 position;
        private List<string> linesList;
        private string usertype;

        public Console(SpriteFont spritefont)
        {
            font = spritefont;
            height = Screen.Height;
            width = Screen.Width;
            position = new Vector2(0, 0);
            linesList = new List<string>();
        }

        public void Update()
        {
            foreach (var item in linesList.Reverse())
            {
                
            }
            // Update User Type
            // Update Orientation
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Previous Type 
            // Draw Console Type 
            // Draw User Type
        }


    }
}
