using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day6
{

    class Day6
    {
        private static List<string> input;

        static Day6() => input = Utilities.Instance.GetInput(nameof(Day6));

        public static void SolvePartOne()
        {
            List<string> newInput = File.ReadAllText(@"C:\Work\AoC\2020\AoC2020\Days\Day6\Day6Input.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>();

            List<string> groupAnswers = new List<string>();




            StringBuilder newString = new StringBuilder();
            foreach (string item in newInput)
            {
                if (item == "")
                {
                    groupAnswers.Add(newString.ToString());
                    newString = new StringBuilder();
                }

                newString.Append(" " + item);
            }
            groupAnswers.Add(newString.ToString());
            int countAnswers = 0;
            foreach (string answer in groupAnswers)
            {
                countAnswers += String.Join("", answer.Distinct()).Trim().Length;
            }
            Console.WriteLine(countAnswers);
        }

        public static void SolvePartTwo()
        {
            List<string> newInput = File.ReadAllText(@"C:\Work\AoC\2020\AoC2020\Days\Day6\Day6Input.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>();
            

            List<string> groupAnswers = new List<string>();



            int CountAnswer = 0;
            //StringBuilder newString = new StringBuilder();
            Group group = new Group();
            List<Group> groups = new List<Group>();
            foreach (string item in newInput)
            {
                
                if (item == "")
                {
                    groups.Add(group);
                    group = new Group();
                }
                else
                {
                    group.Answers.Add(item);
                }
                
                //group.Answers.Add(item);
                //newString.Append(" " + item);
            }
            groups.Add(group);

            //List<string> trimedAnswer = groupAnswers.Select(z => z.Replace(" ", "")).ToList();
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();


            int AllYesAnswers = 0;

            foreach (Group item in groups)
            {

                for (int i = 0; i < chars.Length; i++)
                {
                    if (item.CombinedAnswers().Count(z => z == chars[i]) == item.Answers.Count)
                    {
                        AllYesAnswers++;
                    }
                    Console.WriteLine(AllYesAnswers);
                }
                
                
            }
            

            



            //List<string> answersPerPerson = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();



            //foreach (var personAnswer in answersPerPerson)
            //{

            //}
            //}
        }
    }
}
