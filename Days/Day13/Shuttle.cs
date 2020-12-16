using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days.Day13
{
    class Shuttle
    {
        public long Interval;
        public long DepartTime;
        public long TimeStampOffset;

        public Shuttle(long interval, long timeStampOffset)
        {
            Interval = interval;
            TimeStampOffset = timeStampOffset;
            while (DepartTime < Day13.earliestTimeYouDepart)
                DepartTime += interval;
        }
    }
}
