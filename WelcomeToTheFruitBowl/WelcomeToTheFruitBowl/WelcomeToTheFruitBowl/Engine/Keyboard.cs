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

        public static void Update()
        {
            previousState = currentState;
            currentState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }
    }
}
