using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days.Day11
{
    class Seat
    {
        public bool ToChange { get; set; }
        public string Value { get; set; }
        public int LastChange { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
