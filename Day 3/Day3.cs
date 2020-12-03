using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2020.Day3
{
    public static class Day3
    {
        public static void SolvePartOne()
        {
            List<string> stringValues = File.ReadAllLines(@"C:\Work\AoC\2020\AoC2020\Day 3\Day3Input.txt").ToList<string>();
            int treeCounter = 0;
            bool firstRoad = true;
            int movedLength = 0;
            foreach (string item in stringValues)
            {
                if (!firstRoad)
                {
                    string newRoad = item;
                    while (movedLength + 3 >= newRoad.Length)
                    {
                        newRoad += item;
                    }
                    if (newRoad.Substring(movedLength + 3, 1) == "#")
                    {
                        treeCounter++;
                    }
                    movedLength += 3;
                }
                else
                {
                    firstRoad = false;
                }

            }

            Console.WriteLine("Trees hit: {0}", treeCounter);
        }

        public static void SolvePartTwo()
        {

            Int64 slope1 = Slope11();
            Int64 slope2 = Slope31();
            Int64 slope3 = Slope51();
            Int64 slope4 = Slope71();
            Int64 slope5 = Slope12();
            Console.WriteLine(Slope11());
            Console.WriteLine(Slope31());
            Console.WriteLine(Slope51());
            Console.WriteLine(Slope71());
            Console.WriteLine(Slope12());
            Console.WriteLine("Trees hit: {0}", (slope1 * slope2 * slope3 * slope4 * slope5).ToString());
        }

        private static int Slope11()
        {
            List<string> stringValues = File.ReadAllLines(@"C:\Work\AoC\2020\AoC2020\Day 3\Day3Input.txt").ToList<string>();
            int treeCounter = 0;
            bool firstRoad = true;
            int movedLength = 0;
            foreach (string item in stringValues)
            {
                if (!firstRoad)
                {
                    string newRoad = item;
                    while (movedLength + 1 >= newRoad.Length)
                    {
                        newRoad += item;
                    }
                    if (newRoad.Substring(movedLength + 1, 1) == "#")
                    {
                        treeCounter++;
                    }
                    movedLength += 1;
                }
                else
                {
                    firstRoad = false;
                }

            }

            return treeCounter;
        }

        private static int Slope31()
        {
            List<string> stringValues = File.ReadAllLines(@"C:\Work\AoC\2020\AoC2020\Day 3\Day3Input.txt").ToList<string>();
            int treeCounter = 0;
            bool firstRoad = true;
            int movedLength = 0;
            foreach (string item in stringValues)
            {
                if (!firstRoad)
                {
                    string newRoad = item;
                    while (movedLength + 3 >= newRoad.Length)
                    {
                        newRoad += item;
                    }
                    if (newRoad.Substring(movedLength + 3, 1) == "#")
                    {
                        treeCounter++;
                    }
                    movedLength += 3;
                }
                else
                {
                    firstRoad = false;
                }

            }

            return treeCounter;
        }

        private static int Slope51()
        {
            List<string> stringValues = File.ReadAllLines(@"C:\Work\AoC\2020\AoC2020\Day 3\Day3Input.txt").ToList<string>();
            int treeCounter = 0;
            bool firstRoad = true;
            int movedLength = 0;
            foreach (string item in stringValues)
            {
                if (!firstRoad)
                {
                    string newRoad = item;
                    while (movedLength + 5 >= newRoad.Length)
                    {
                        newRoad += item;
                    }
                    if (newRoad.Substring(movedLength + 5, 1) == "#")
                    {
                        treeCounter++;
                    }
                    movedLength += 5;
                }
                else
                {
                    firstRoad = false;
                }

            }

            return treeCounter;
        }

        private static int Slope71()
        {
            List<string> stringValues = File.ReadAllLines(@"C:\Work\AoC\2020\AoC2020\Day 3\Day3Input.txt").ToList<string>();
            int treeCounter = 0;
            bool firstRoad = true;
            int movedLength = 0;
            foreach (string item in stringValues)
            {
                if (!firstRoad)
                {
                    string newRoad = item;
                    while (movedLength + 7 >= newRoad.Length)
                    {
                        newRoad += item;
                    }
                    if (newRoad.Substring(movedLength + 7, 1) == "#")
                    {
                        treeCounter++;
                    }
                    movedLength += 7;
                }
                else
                {
                    firstRoad = false;
                }

            }

            return treeCounter;
        }

        private static int Slope12()
        {
            List<string> stringValues = File.ReadAllLines(@"C:\Work\AoC\2020\AoC2020\Day 3\Day3Input.txt").ToList<string>();
            int treeCounter = 0;
            int previousRoadNumber = 0;
            int thisRoadNumber = 0;

            int movedLength = 0;
            foreach (string item in stringValues)
            {
                //Console.WriteLine(movedLength);
                string newRoad = item;
                while (movedLength + 1 >= newRoad.Length)
                {
                    newRoad += item;
                }
                if (thisRoadNumber == previousRoadNumber + 2)
                {

                    if (newRoad.Substring(movedLength+1, 1) == "#")
                    {
                        treeCounter++;
                    }
                    movedLength++;
                    previousRoadNumber = thisRoadNumber;
                }
                //else if (thisRoadNumber > 2)
                //{
                //    if (newRoad.Substring(movedLength, 1) == "#")
                //    {
                //        //treeCounter++;
                //    }
                //}

                thisRoadNumber++;
            }

            return treeCounter;
        }
    }
}
