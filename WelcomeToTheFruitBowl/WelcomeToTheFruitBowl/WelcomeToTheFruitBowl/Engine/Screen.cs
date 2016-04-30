using Microsoft.Xna.Framework.Graphics;

namespace WelcomeToTheFruitBowl.Engine
{
    public static class Screen
    {
        private static GraphicsDevice graphicsDevice;

        public static int Width => graphicsDevice.Viewport.Width;
        public static int Height => graphicsDevice.Viewport.Height;

        public static void Initialize(GraphicsDevice graphicsDeviceInput)
        {
            graphicsDevice = graphicsDeviceInput;
        }
    }
}