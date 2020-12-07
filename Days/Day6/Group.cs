using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day6
{
    class Group
    {
        public Group()
        {
            Answers = new List<string>();
        }
        public List<string> Answers { get; set; }

        public string CombinedAnswers()
        {
            return String.Join("", Answers);
        }
    }
}
