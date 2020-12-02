using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Day2
{
    class Password
    {
        public int RequirementA { get; set; }
        public int RequirementB { get; set; }
        public string RequiredLetter { get; set; }
        public string PasswordString { get; set; }

        public Password(int requirementA, int requirementB, string requiredLetter, string password)
        {
            this.RequirementA = requirementA;
            this.RequirementB = requirementB;
            this.RequiredLetter = requiredLetter;
            this.PasswordString = password;
        }

        public Password()
        {

        }
    }
}
