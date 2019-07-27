using System;
using System.Runtime.CompilerServices;

namespace Snowflake53
{
    public class IdGenerator
    {
        public static readonly DateTime DefaultEpoch = new DateTime(2019, 7, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly ITimeSource timesource = new DefaultTimeSource(DefaultEpoch);

        private int _sequence;
        private long _lastgen = -1;

        private readonly int _generatorId;
        private readonly object _genlock = new object();

        public IdGenerator() : this(0) { }

        public IdGenerator(int generatorId)
        {
            _generatorId = generatorId & 3;
        }

        public long CreateId()
        {
            lock (_genlock)
            {
                var ticks = GetTicks();
                var timestamp = ticks & GetMask(41);
                
                if (timestamp == _lastgen)
                {
                    _sequence++;
                }
                else 
                {
                    _sequence = 0;
                    _lastgen = timestamp;
                }

                unchecked
                {
                    return (timestamp << 12)
                        + (_generatorId << 10)
                        + _sequence;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private long GetTicks()
        {
            return timesource.GetTicks();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long GetMask(byte bits)
        {
            return (1L << bits) - 1;
        }

    }
}