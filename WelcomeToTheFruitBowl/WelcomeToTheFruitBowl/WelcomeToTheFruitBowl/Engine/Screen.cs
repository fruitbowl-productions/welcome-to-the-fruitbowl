using Microsoft.Xna.Framework.Graphics;

namespace WelcomeToTheFruitBowl.Engine
{
    public static class Screen
    {
        private static GraphicsDevice GraphicsDevice;

        public static int Width => GraphicsDevice.Viewport.Width;
        public static int Height => GraphicsDevice.Viewport.Height;

        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }
    }
}