using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day7
{
    class Bag
    {
        public Bag(string color)
        {
            this.Color = color;
            this.Children = new List<(Bag, int)>();
            this.Parents = new List<Bag>();
        }

        public Bag()
        {
            this.Children = new List<(Bag, int)>();
            this.Parents = new List<Bag>();
        }
        public string Color { get; set; }

        public List<(Bag, int)> Children { get; set; }
        public List<Bag> Parents { get; set; }

        public List<string> ParentsColor()
        {
            return this.Parents.SelectMany(z => z.ParentsColor().Concat(new[] { z.Color })).ToList();
        }

        public long CountBags() => Children.Sum(z => z.Item2) + Children.Sum(z => z.Item1.CountBags() * z.Item2);
    }
}
