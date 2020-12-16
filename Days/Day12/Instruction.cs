using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days.Day12
{
    class Instruction
    {
        public Operation Operation { get; set; }
        public int Value { get; set; }
    }

    enum Operation
    {
        North = 'N',
        South = 'S',
        East = 'E',
        West = 'W',
        Left = 'L',
        Right = 'R',
        Forward = 'F'
    }
}
