using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace XinCraftSharp.Core
{
    public class RequestBucket
    {
        public int Max { get; protected set; }

        public int Remaining { get; protected set; }

        public TimeSpan ResetInterval { get; protected set; }

        public DateTime ResetTime { get; protected set; }

        public RequestBucket(int max, int remaining, TimeSpan resetInterval, DateTime resetTime)
        {
            Max = max;
            Remaining = remaining;
            ResetInterval = resetInterval;
            ResetTime = resetTime;
        }

        public async Task Acquire()
        {
            if (DateTime.UtcNow > ResetTime)
                await Refill();

            if (Remaining > 0)
            {
                Remaining--;
                return;
            }

            Console.WriteLine("[bucket] rate-limited. awaiting rate-limit refresh...");

            while (ResetTime > DateTime.UtcNow)
            {
            }

            await Refill();
            Remaining--;
        }

        public Task Refill()
        {
            Remaining = Max;
            ResetTime = DateTime.UtcNow.Add(ResetInterval);
            return Task.CompletedTask;
        }

        public Task ParseHeaders(HttpResponseHeaders headers)
        {
            IEnumerable<string>? remaining;
            IEnumerable<string>? reset;

            try
            {
                remaining = headers.GetValues("xx-ratelimit-remaining");
                reset = headers.GetValues("xx-ratelimit-reset");
            }
            catch
            {
                // Return if we cannot retrieve header values.
                return Task.CompletedTask;
            }

            if (!int.TryParse(remaining.First(), out int remainingInt))
                return Task.CompletedTask;

            if (!long.TryParse(reset.First(), out long resetLong))
                return Task.CompletedTask;

            Remaining = remainingInt;
            ResetTime = DateTime.UnixEpoch.AddMilliseconds(resetLong);

            return Task.CompletedTask;
        }
    }
}