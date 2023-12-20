using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Core.Helpers
{
    public static class DateTimeHelper
    {
        static readonly Random rnd = new();
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }
    }
}
