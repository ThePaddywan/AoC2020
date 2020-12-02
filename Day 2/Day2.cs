using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2020.Day2
{
    public static class Day2
    {
        private static List<Password> getPasswords()
        {
            List<Password> passwords = new List<Password>();
            List<string[]> splittedString = new List<string[]>();
            List<string> stringValues = File.ReadAllLines(@"C:\Work\AoC\2020\AoC2020\Day 2\Day2Input.txt").ToList<string>();
            foreach (string item in stringValues)
            {
                splittedString.Add(item.Split(':'));
            }

            foreach (string[] item in splittedString)
            {
                string[] requirements = item[0].Split('-');
                Password password = new Password();

                password.RequirementA = int.Parse(requirements[0]);
                password.RequirementB = int.Parse(requirements[1].Substring(0, requirements[1].Length - 1).Trim());
                password.RequiredLetter = item[0].Substring(item[0].Length - 1);
                password.PasswordString = item[1].Trim();
                passwords.Add(password);
            }

            return passwords;
        }

        public static void SolvePartOne()
        {
            List<Password> passwords = getPasswords();
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
            List<Password> passwords = getPasswords();
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
