using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;

namespace AoC2020.Day2
{
    public static class Day2
    {
        private static List<string> input;
        private static List<Password> passwords;
        static Day2()
        {
            input = Utilities.Instance.GetInput(nameof(Day2));
            getPasswords();
        }
        private static List<Password> getPasswords()
        {
            List<string[]> splittedString = new List<string[]>();
            foreach (string item in input)
            {
                splittedString.Add(item.Split(':'));
            }

            foreach (string[] item in splittedString)
            {
                string[] requirements = item[0].Split('-');
                passwords.Add(new Password(int.Parse(requirements[0]), int.Parse(requirements[1].Substring(0, requirements[1].Length - 1).Trim()), item[0].Substring(item[0].Length - 1), item[1].Trim()));
            }

            return passwords;
        }

        public static void SolvePartOne()
        {
            int validPasswords = 0;
            int invalidPasswords = 0;

            foreach (Password password in passwords)
            {
                int originalPasswordLength = password.PasswordString.Length;
                int newPasswordLength = password.PasswordString.Replace(password.RequiredLetter, "").Length;
                int countOfRequiredLetterInPassword = originalPasswordLength - newPasswordLength;

                if (countOfRequiredLetterInPassword >= password.RequirementA && countOfRequiredLetterInPassword <= password.RequirementB)
                {
                    validPasswords++;
                }
                else
                {
                    invalidPasswords++;
                }
            }

            Console.WriteLine("Number of valid passwords: {0}", validPasswords.ToString());

        }

        public static void SolvePartTwo()
        {
            int validPasswords = 0;
            int invalidPasswords = 0;

            foreach (Password password in passwords)
            {
                if ((password.PasswordString.Substring(password.RequirementA - 1, 1) == password.RequiredLetter && password.PasswordString.Substring(password.RequirementB - 1, 1) != password.RequiredLetter) || (password.PasswordString.Substring(password.RequirementA - 1, 1) != password.RequiredLetter && password.PasswordString.Substring(password.RequirementB - 1, 1) == password.RequiredLetter))
                {
                    validPasswords++;
                }
                else
                {
                    invalidPasswords++;
                }
            }

            Console.WriteLine("Number of valid passwords: {0}", validPasswords.ToString());
        }
    }
}
