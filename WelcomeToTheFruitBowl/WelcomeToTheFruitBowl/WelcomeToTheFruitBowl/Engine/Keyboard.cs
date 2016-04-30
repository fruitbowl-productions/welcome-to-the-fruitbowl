using Microsoft.Xna.Framework.Input;

namespace WelcomeToTheFruitBowl.Engine
{
    public static class Keyboard
    {
        private static KeyboardState currentState;
        private static KeyboardState previousState;

        static Keyboard()
        {
            currentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            previousState = currentState;
        }

        public static bool IsKeyDown(Keys key) => currentState.IsKeyDown(key);
        public static bool IsKeyUp(Keys key) => currentState.IsKeyUp(key);

        public static bool IsAnyKeyDown()
        {
            // http://xboxforums.create.msdn.com/forums/p/49933/667071.aspx
            return currentState.GetPressedKeys().Length == 0 ||
                   (currentState.GetPressedKeys().Length == 1 && currentState.GetPressedKeys()[0] == Keys.None);
        }

        public static void Update()
        {
            previousState = currentState;
            currentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }
    }
}
