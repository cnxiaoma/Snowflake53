using System;
using System.Diagnostics;

namespace Snowflake53
{
    public abstract class StopwatchTimeSource : ITimeSource
    {
        private static readonly Stopwatch _sw = Stopwatch.StartNew();

        public DateTimeOffset Epoch { get; private set; }

        protected TimeSpan Elapsed { get { return _sw.Elapsed; } }

        protected TimeSpan Offset { get; private set; }

        public StopwatchTimeSource(DateTimeOffset epoch, TimeSpan tickDuration)
        {
            Epoch = epoch;
            Offset = (DateTimeOffset.UtcNow - Epoch);
            TickDuration = tickDuration;
        }

        public TimeSpan TickDuration { get; private set; }

        public abstract long GetTicks();
    }
}
