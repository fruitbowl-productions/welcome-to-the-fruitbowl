using System;
using Microsoft.Xna.Framework;

namespace WelcomeToTheFruitBowl.Utilities.Timers
{
    public class Timer
    {
        protected readonly Action Action;

        protected TimeSpan Delay;
        protected TimeSpan Current;

        public Timer(Action action, TimeSpan delay)
        {
            Action = action;
            Delay = delay;
            Current = TimeSpan.Zero;
        }

        public virtual void Update(GameTime gameTime)
        {
            Current += gameTime.ElapsedGameTime;
            if (Current < Delay) return;
            Action.Invoke();
            Current = TimeSpan.Zero;
        }
    }
}
