namespace AoC2020.Days.Day2
{
    class Password
    {
        public int RequirementA { get; set; }
        public int RequirementB { get; set; }
        public string RequiredLetter { get; set; }
        public string PasswordString { get; set; }

        public Password(int requirementA, int requirementB, string requiredLetter, string password)
        {
            RequirementA = requirementA;
            RequirementB = requirementB;
            RequiredLetter = requiredLetter;
            PasswordString = password;
        }
    }
}
