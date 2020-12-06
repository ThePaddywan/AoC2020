using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day1
{
    class Day1
    {
        private static List<string> input;
        static Day1()
        {
            input = Utilities.Instance.GetInput(nameof(Day1));
        }


        public static void SolvePartOne()
        {
            List<int> intValues = input.Select(s => Convert.ToInt32(s)).ToList();
            foreach (int line in intValues)
            {
                if (intValues.Find(z => z == 2020 - line) > 0)
                {
                    Console.WriteLine("So {0} and {1} gives 2020", 2020 - line, line);
                    Console.WriteLine("Multiplied they give: {0}", (2020 - line) * line);
                    return;
                }
            }
        }

        public static void SolvePartTwo()
        {
            List<int> intValues = input.Select(s => Convert.ToInt32(s)).ToList();
            foreach (int line in intValues)
            {
                foreach (int newLine in intValues)
                {
                    if (line + newLine < 2020 && line + newLine > 0)
                    {
                        if (intValues.Find(z => z == 2020 - line - newLine) > 0)
                        {
                            Console.WriteLine("So {0}, {1} and {2} gives 2020", 2020 - line - newLine, line, newLine);
                            Console.WriteLine("Multiplied they give: {0}", (2020 - line - newLine) * line * newLine);
                            return;
                        }
                    }
                }
            }
        }
    }
}
