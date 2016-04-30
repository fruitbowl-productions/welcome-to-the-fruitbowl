using System;

namespace WelcomeToTheFruitBowl
{
#if WINDOWS || XBOX
    internal static class Program
    {
        public static void Main()
        {
            using (var game = new WelcomeToTheFruitBowlGame())
            {
                game.Run();
            }
        }
    }
#endif
}

