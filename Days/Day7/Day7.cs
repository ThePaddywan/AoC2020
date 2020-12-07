using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day7
{
    class Day7
    {
        private static List<string> input;

        static Day7() => input = Utilities.Instance.GetInput(nameof(Day7));

        public static void SolvePartOne()
        {
            Dictionary<string, Bag> allBags = new Dictionary<string, Bag>();

            foreach (string bagRule in input)
            {
                string[] splittedRule = bagRule.Split(new[] { "bags contain" }, StringSplitOptions.None);
                string color = splittedRule[0].Trim();


                List<string> thisBagContains = splittedRule[1].Split(',').Select(x => x.Trim()).ToList();
                allBags.TryGetValue(color, out Bag bag);
                if (bag == null)
                {
                    bag = new Bag(color);
                }

                if (!allBags.ContainsKey(color))
                {
                    allBags[color] = bag;
                }

                foreach (var containedBag in thisBagContains)
                {
                    if (containedBag != "no other bags.")
                    {
                        string containedColor = containedBag.Replace(containedBag.Split()[0], "").Split(new[] { "bag" }, StringSplitOptions.None)[0].Trim();


                        allBags.TryGetValue(containedColor, out Bag containedContainedBag);
                        if (containedContainedBag == null)
                        {
                            containedContainedBag = new Bag(containedColor);
                        }

                        if (!allBags.ContainsKey(containedColor))
                        {
                            allBags[containedColor] = containedContainedBag;
                        }

                        containedContainedBag.Parents.Add(bag);
                        bag.Children.Add((containedContainedBag, int.Parse(containedBag.Split()[0])));
                    }
                }
            }

            Console.WriteLine(allBags["shiny gold"].ParentsColor().Select(z => z).Distinct().Count());

            Console.WriteLine(allBags["shiny gold"].CountBags());


        }



        public static void SolvePartTwo()
        {

        }
    }
}
