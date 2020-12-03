using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2020.HelperClasses
{
    public sealed class Utilities
    {
        private static readonly Utilities instance = new Utilities();
        static Utilities()
        {
        }
        private Utilities()
        {
        }
        public static Utilities Instance => instance;

        public List<string> GetInput(object callingClass)
        {
            Console.WriteLine(callingClass);
            return File.ReadAllLines(@"..\..\Days\" + callingClass + @"\" + callingClass + @"input.txt").ToList<string>();
        }
    }
}
