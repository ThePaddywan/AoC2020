using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;

namespace AoC2020.Day3
{
    public static class Day3
    {
        private static List<string> input;
        static Day3()
        {
            input = Utilities.Instance.GetInput(nameof(Day3));
        }
        private static Int64 CalculateTreesHit(int right, int down = 1)
        {
            int treeCounter = 0;
            int movedLength = 0;
            int previousRoadNumber = 0;
            int thisRoadNumber = 0;
            bool first = true;
            foreach (string item in input)
            {
                if (!first)
                {
                    string newRoad = item;
                    while (movedLength + right >= newRoad.Length)
                        newRoad += item;
                    if (down == 1 || thisRoadNumber == previousRoadNumber + down)
                    {
                        if (newRoad.Substring(movedLength + right, 1) == "#")
                        {
                            treeCounter++;
                        }
                        movedLength += right;
                        previousRoadNumber = thisRoadNumber;
                    }
                    thisRoadNumber++;
                }
                else
                    first = false;

            }
            return treeCounter;
        }
        public static void SolvePartOne()
        {
            Console.WriteLine("Trees hit: {0}", CalculateTreesHit(3));
        }

        public static void SolvePartTwo()
        {
            Console.WriteLine("Trees hit: {0}", (CalculateTreesHit(1) * CalculateTreesHit(3) * CalculateTreesHit(5) * CalculateTreesHit(7) * CalculateTreesHit(1, 2)).ToString());
        }
    }
}
