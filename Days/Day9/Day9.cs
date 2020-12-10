using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day9
{
    class Day9
    {
        private static List<string> input;
        private static long numberFromPartOne;

        static Day9() => input = Utilities.Instance.GetInput(nameof(Day9));
        private static List<long> newInput = new List<long>();
        public static void SolvePartOne()
        {
            newInput = input.Select(long.Parse).ToList();
            List<long> preamble = input.Take(25).Select(long.Parse).ToList();

            for (int i = 25; i < newInput.Count; i++)
            {
                bool isValid = false;
                for (int o = i - 25; o < newInput.Count - 1; o++)
                {
                    for (int p = i - 25; p < newInput.Count - 1; p++)
                    {
                        if (newInput[i] == newInput[o] + newInput[p])
                        {
                            isValid = true;
                        }
                    }
                }

                if (isValid == false)
                {
                    Console.WriteLine(newInput[i]);
                    numberFromPartOne = newInput[i];
                }
            }
        }

        public static void SolvePartTwo()
        {
            for (int i = 0; i < newInput.Count; i++)
            {
                long min = newInput[i];
                long max = newInput[i];
                long number = newInput[i];

                for (var o = i + 1; o < newInput.Count; o++)
                {
                    number += newInput[o];

                    if (min > newInput[o])
                    {
                        min = newInput[o];
                    }
                    if (max < newInput[o])
                    {
                        max = newInput[o];
                    }

                    if (number == numberFromPartOne)
                    {
                        Console.WriteLine("Min: {0}, Max: {1}, Sum: {2}",min,max,min+max);
                    }
                }
            }
        }

    }
}
