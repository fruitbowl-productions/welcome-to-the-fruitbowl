using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace WelcomeToTheFruitBowl.Engine.Keyboards
{
    public static class DelayedKeyboard
    {
        private static Dictionary<Keys, TimeSpan> delays;
        private static List<Keys> currentlyPressed;
        private static TimeSpan defaultDelay = TimeSpan.FromMilliseconds(250);

        static DelayedKeyboard()
        {
            delays = new Dictionary<Keys, TimeSpan>();
            currentlyPressed = new List<Keys>();

            foreach (var key in Enum.GetValues(typeof(Keys)))
            {
                delays[(Keys)key] = defaultDelay;
            }
        }

        public static bool IsKeyDown(Keys key) => currentlyPressed.Contains(key);
        public static bool IsKeyUp(Keys key) => !IsKeyDown(key);

        public static bool IsAnyKeyDown() => currentlyPressed.Count > 0;

        private static IEnumerable<Keys> GetPressedKeys(KeyboardState keyboard) => keyboard.GetPressedKeys().Where(key => key != Keys.None);

        public static IEnumerable<Keys> PressedKeys => currentlyPressed;

        public static void Update(GameTime gameTime)
        {
            currentlyPressed.Clear();
            
            foreach (var key in GetPressedKeys(Microsoft.Xna.Framework.Input.Keyboard.GetState()))
            {
                if (delays[key] > TimeSpan.Zero) continue;
                delays[key] = defaultDelay;
                currentlyPressed.Add(key);
            }

            var tempDelays = new Dictionary<Keys, TimeSpan>(delays);
            foreach (var key in tempDelays.Keys)
            {
                delays[key] -= gameTime.ElapsedGameTime;
            }
        }
    }
}
