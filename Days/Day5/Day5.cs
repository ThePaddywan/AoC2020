using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day5
{
    class Day5
    {
        private static List<string> input;

        static Day5() => input = Utilities.Instance.GetInput(nameof(Day5));
        public static List<Seat> seats = new List<Seat>();

        public static void SolvePartOne()
        {


            foreach (string item in input)
            {
                Seat seat = new Seat();
                seat.Row = Convert.ToInt32(item.Substring(0, 7).Replace('F', '0').Replace('B', '1'), 2);
                seat.Column = Convert.ToInt32(item.Substring(7).Replace('L', '0').Replace('R', '1'), 2);
                seat.SeatId = seat.Row * 8 + seat.Column;
                seats.Add(seat);
            }

            Console.WriteLine(seats.Max(z => z.SeatId));


        }

        public static void SolvePartTwo()
        {
            List<Seat> sortedSeats = seats.OrderBy(z => z.SeatId).ToList();

            for (int i = 1; i < sortedSeats.Count; i++)
            {
                if (i != sortedSeats.Count-1)
                {


                    if (sortedSeats[i].SeatId + 1 != sortedSeats[i + 1].SeatId)
                    {
                        Console.WriteLine(sortedSeats[i].SeatId + 1);
                    }
                }


            }
        }

    }
}
