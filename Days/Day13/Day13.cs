using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days.Day13
{
    class Day13
    {
        private static List<string> input;

        static Day13() => input = Utilities.Instance.GetInput(nameof(Day13));


        public static int earliestTimeYouDepart = 0;


        public static void SolvePartOne()
        {
            List<string> shuttles = input[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            earliestTimeYouDepart = int.Parse(input[0]);
            List<Shuttle> shuttleList = new List<Shuttle>();
            long earliestAvailableShuttle = int.MaxValue;
            long earliestShuttleNumber = 0, timeStampOffset = 0;
            foreach (string s in shuttles)
            {
                if (s != "x")
                {
                    shuttleList.Add(new Shuttle(int.Parse(s), timeStampOffset));
                }
                timeStampOffset++;
            }
            foreach (Shuttle shuttle in shuttleList)
            {
                if (shuttle.DepartTime < earliestAvailableShuttle && shuttle.DepartTime >= earliestTimeYouDepart)
                {
                    earliestAvailableShuttle = shuttle.DepartTime;
                    earliestShuttleNumber = shuttle.Interval;
                }
            }
            Console.WriteLine((ulong)((earliestAvailableShuttle - earliestTimeYouDepart) * earliestShuttleNumber));



        }

        public static void SolvePartTwo()
        {
            List<Shuttle> shuttleList = new List<Shuttle>();
            List<string> shuttles = input[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int timeStampOffset = 0;
            foreach (string shuttle in shuttles)
            {
                if (shuttle != "x")
                {
                    shuttleList.Add(new Shuttle(int.Parse(shuttle), timeStampOffset));
                }
                timeStampOffset++;
            }
            bool notFound = true, secondTime = false;
            long t = shuttleList[0].Interval;
            long increment = shuttleList[0].Interval;
            long numberOfshuttlesInPosition = 0;
            long syncedShuttleCount = 0;
            long previousTimeSynced = 0;
            long numberOfshuttlesToSync = 2;

            while (notFound)
            {
                foreach (Shuttle bus in shuttleList)
                {
                    if ((t + bus.TimeStampOffset) % bus.Interval == 0)
                    {
                        numberOfshuttlesInPosition++;
                    }
                }

                for (int i = 0; i < shuttleList.Count; i++)
                {
                    if ((t + shuttleList[i].TimeStampOffset) % shuttleList[i].Interval == 0)
                    {
                        syncedShuttleCount++;
                        if (syncedShuttleCount == numberOfshuttlesToSync && !secondTime)
                        {
                            previousTimeSynced = t;
                            syncedShuttleCount = 0;
                            secondTime = true;
                        }
                        else if (syncedShuttleCount == numberOfshuttlesToSync && secondTime)
                        {
                            numberOfshuttlesToSync += 1;
                            secondTime = false;
                            syncedShuttleCount = 0;
                            increment = t - previousTimeSynced;
                        }
                    }
                    else
                    {
                        syncedShuttleCount = 0;
                        break;
                    }
                }
                if (numberOfshuttlesInPosition == shuttleList.Count)
                {
                    notFound = false;
                    Console.WriteLine(t);
                }
                else
                {
                    numberOfshuttlesInPosition = 0;
                }
                t += increment;
            }

        }
    }
}
