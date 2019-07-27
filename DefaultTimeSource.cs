using System;

namespace Snowflake53
{
    public class DefaultTimeSource : StopwatchTimeSource
    {
        public DefaultTimeSource(DateTimeOffset epoch)
            : this(epoch, TimeSpan.FromMilliseconds(1)) { }

        public DefaultTimeSource(DateTimeOffset epoch, TimeSpan tickDuration)
            : base(epoch, tickDuration) { }

        public override long GetTicks()
        {
            return (Offset.Ticks + Elapsed.Ticks) / TickDuration.Ticks;
        }
    }
}
