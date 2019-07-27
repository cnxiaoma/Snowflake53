using System;

namespace Snowflake53
{
     public interface ITimeSource
     {
        DateTimeOffset Epoch { get; }

        TimeSpan TickDuration { get; }

        long GetTicks();
    }
}