using System;
using Microsoft.Xna.Framework;

namespace WelcomeToTheFruitBowl.Utilities.Timers
{
    public class DelayedTimer : Timer
    {
        private readonly Action offAction;
        private TimeSpan actionTime;

        public DelayedTimer(Action action, TimeSpan delay, Action offAction) : base(action, delay)
        {
            this.offAction = offAction;
            actionTime = TimeSpan.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            Current += gameTime.ElapsedGameTime;

            if (Current >= Delay)
            {
                actionTime += gameTime.ElapsedGameTime;

                if (Current < Delay + actionTime) return;
                Action.Invoke();
                Current = TimeSpan.Zero;
                actionTime = TimeSpan.Zero;
            }
            else
            {
                offAction.Invoke();
            }
        }
    }
}
