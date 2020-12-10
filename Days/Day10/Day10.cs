using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day10
{
    class Day10
    {
        private static List<string> input;

        static Day10() => input = Utilities.Instance.GetInput(nameof(Day10));
        private static List<long> newInput = new List<long>();

        public static void SolvePartOne()
        {
            long threeJoltDiff = 0;
            long oneJoltDiff = 0;
            long jolt = 0;
            newInput = input.Select(long.Parse).ToList();
            newInput.Sort();


            foreach (long item in newInput)
            {
                if (item - jolt == 1)
                {
                    oneJoltDiff++;
                }
                if (item - jolt == 3)
                {
                    threeJoltDiff++;
                }
                jolt = item;
            }
            threeJoltDiff++;
            Console.WriteLine(oneJoltDiff * threeJoltDiff);



        }
        public static void SolvePartTwo()
        {

            newInput.Add(0);
            List<long> ordered = newInput.OrderBy(x => x).ToList();
            long[] ways = new long[newInput.Count];
            ways[0] = 1;

            foreach (int i in Enumerable.Range(1, ordered.Count - 1))
            {
                foreach (int o in Enumerable.Range(0, i))
                {

                    if (ordered[i] - ordered[o] <= 3)
                    {
                        ways[i] += ways[o];
                    }
                }
            }
            Console.WriteLine(ways.Last());

        }
    }
}
