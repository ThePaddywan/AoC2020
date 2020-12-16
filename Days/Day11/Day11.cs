using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days.Day11
{
    class Day11
    {
        private static List<string> input;

        static Day11() => input = Utilities.Instance.GetInput(nameof(Day11));
        private static List<long> newInput = new List<long>();
        static int counter = 1;
        public static void SolvePartOne()
        {
            List<Seat> seats = new List<Seat>();

            for (int row = 0; row < input.Count; row++)
            {
                for (int column = 0; column < input[0].Length; column++)
                {
                    if (input[row][column].ToString() != ".")
                    {
                        seats.Add(new Seat() { X = column, Y = row, Value = "#", ToChange = false, LastChange = counter });
                    }
                }
            }

            Console.WriteLine(DoPartOne(seats, 4));
            counter = 0;

        }

        public static void SolvePartTwo()
        {
            List<Seat> seats = new List<Seat>();
            for (int row = 0; row < input.Count; row++)
            {
                for (int column = 0; column < input[0].Length; column++)
                {
                    if (input[row][column].ToString() != ".")
                    {
                        seats.Add(new Seat() { X = column, Y = row, Value = "#", ToChange = false, LastChange = counter });
                    }
                }
            }

            Console.WriteLine(DoPartOne(seats, 5));

            counter = 0;
        }

        private static int DoPartOne(List<Seat> seats, int tolerance)
        {
            counter++;
            foreach (Seat seat in seats)
            {
                
                if (counter - seat.LastChange < 2)
                {
                    bool ChageState = AdjacentSeats(seat, seats, tolerance);
                seat.ToChange = ChageState;
                }
            }

            if (seats.Any(x => x.ToChange == true))
            {
                seats.Where(x => x.ToChange == true).ToList().ForEach(x => { x.Value = (x.Value == "#" ? "L" : "#"); x.ToChange = false; x.LastChange = counter; });
                return DoPartOne(seats, tolerance);
            }
            else
            {
                return seats.Where(x => x.Value == "#").Count();
            }
        }

        private static bool AdjacentSeats(Seat seat, List<Seat> seats, int tolerance)
        {
            int result = 0;
            //left
            result += FoundOccupied(seat.X, seat.Y, -1, 0, seats, (tolerance == 4));
            //right
            result += FoundOccupied(seat.X, seat.Y, 1, 0, seats, (tolerance == 4));
            //down
            result += FoundOccupied(seat.X, seat.Y, 0, 1, seats, (tolerance == 4));
            //up
            result += FoundOccupied(seat.X, seat.Y, 0, -1, seats, (tolerance == 4));
            // upleft
            result += FoundOccupied(seat.X, seat.Y, -1, -1, seats, (tolerance == 4));

            if (result <= tolerance)
            {
                // up-right
                result += FoundOccupied(seat.X, seat.Y, 1, -1, seats, (tolerance == 4));

                // down-letf
                if (result <= tolerance)
                {
                    result += FoundOccupied(seat.X, seat.Y, -1, 1, seats, (tolerance == 4));
                }

                // down-right
                if (result <= tolerance)
                {
                    result += FoundOccupied(seat.X, seat.Y, 1, 1, seats, (tolerance == 4));
                }
            }

            if (seat.Value == "L" && result == 0)
            {
                return true;
            }
            else if (seat.Value == "#" && result >= tolerance)
            {
                return true;
            }

            return false;
        }

        private static int FoundOccupied(int x, int y, int newX, int newY, List<Seat> seats, bool isFirstPart)
        {
            long maxX = seats.Select(z => z.X).Max();
            long maxY = seats.Select(c => c.Y).Max();
            long xToCheck = x + newX;
            long yToCheck = y + newY;

            if (xToCheck < 0 || yToCheck < 0 || xToCheck > maxX || yToCheck > maxY)
            {
                return 0;
            }

            if (isFirstPart)
            {
                if (seats.Where(seat => seat.X == xToCheck && seat.Y == yToCheck && seat.Value == "#").FirstOrDefault() == null)
                {
                    return 0;
                }

                return 1;
            }
            else
            {
                while (true)
                {
                    Seat tempSeat = seats.Where(seat => seat.X == xToCheck && seat.Y == yToCheck).FirstOrDefault();
                    if (tempSeat != null)
                    {
                        if (tempSeat.Value == "#")
                        {
                            return 1;
                        }

                        break;
                    }

                    xToCheck += newX;
                    yToCheck += newY;

                    if (xToCheck < 0 || yToCheck < 0 || xToCheck > maxX || yToCheck > maxY)
                    {
                        return 0;
                    }
                }
                return 0;
            }
        }
    }
}


