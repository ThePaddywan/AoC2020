using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020.Days.Day4
{
    public static class Day4
    {
        private static List<string> input;

        static Day4() => input = Utilities.Instance.GetInput(nameof(Day4));
        private static List<Identification> identifications = new List<Identification>();

        public static void SolvePartOne()
        {
            List<string> NewIds = new List<string>();
            List<string> ids = new List<string>();
            List<string> newInput = File.ReadAllText(@"C:\Work\AoC\2020\AoC2020\Days\Day4\Day4Input.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>();
            


            StringBuilder newString = new StringBuilder();
            foreach (string item in newInput)
            {
                if (item == "")
                {
                    ids.Add(newString.ToString());
                    newString = new StringBuilder();
                }

                newString.Append(" " + item);
            }
            ids.Add(newString.ToString());

            foreach (string item in ids)
            {
                Identification identification = new Identification();
                foreach (string newItem in item.Replace("  ", " ").Split(new char[] { ' ' }, StringSplitOptions.None).ToList<string>())
                {

                    string[] idValues = newItem.Split(':');
                    switch (idValues[0])
                    {
                        case "byr":
                            identification.byr = idValues[1];
                            break;
                        case "iyr":
                            identification.iyr = idValues[1];
                            break;
                        case "eyr":
                            identification.eyr = idValues[1];
                            break;
                        case "hgt":
                            identification.hgt = idValues[1];
                            break;
                        case "hcl":
                            identification.hcl = idValues[1];
                            break;
                        case "ecl":
                            identification.ecl = idValues[1];
                            break;
                        case "pid":
                            identification.pid = idValues[1];
                            break;
                        case "cid":
                            identification.cid = idValues[1];
                            break;

                        default:
                            break;
                    }


                }
                identifications.Add(identification);


            }
            int validIdentifications = 0;
            foreach (Identification item in identifications)
            {

                if (item.isValid())
                {
                    validIdentifications++;
                }

            }
            Console.WriteLine(validIdentifications);



        }

        public static void SolvePartTwo()
        {
            int validIdentifications = 0;
            List<Identification> validIds = new List<Identification>();
            foreach (Identification item in identifications)
            {

                if (item.isValidEnhanced())
                {
                    validIdentifications++;

                }

            }
            Console.WriteLine(validIdentifications);
        }
    }



    public class Identification
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public bool isValid()
        {
            bool isValid = false;

            List<string> identificationValues = new List<string>();
            identificationValues.Add(byr);
            identificationValues.Add(iyr);
            identificationValues.Add(eyr);
            identificationValues.Add(hgt);
            identificationValues.Add(hcl);
            identificationValues.Add(ecl);
            identificationValues.Add(pid);

            if (!identificationValues.Any(z => string.IsNullOrWhiteSpace(z)))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine();
            }
            return isValid;
        }

        public bool isValidEnhanced()
        {
            if (string.IsNullOrEmpty(byr) || string.IsNullOrEmpty(iyr) || string.IsNullOrEmpty(eyr) || string.IsNullOrEmpty(hgt) || string.IsNullOrEmpty(hcl) || string.IsNullOrEmpty(ecl) || string.IsNullOrEmpty(pid))
            {
                return false;
            }
            bool isValid = true;
            if (byr.Length == 4)
            {
                if (int.Parse(byr) < 1920 || int.Parse(byr) > 2002)
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            if (iyr.Length == 4)
            {
                if (int.Parse(iyr) < 2010 || int.Parse(iyr) > 2020)
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            if (eyr.Length == 4)
            {
                if (int.Parse(eyr) < 2020 || int.Parse(eyr) > 2030)
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            if (hgt.Contains("cm") || hgt.Contains("in"))
            {
                if (hgt.Substring(hgt.Length - 2, 2) == "cm")
                {
                    if (int.Parse(hgt.Substring(0, hgt.Length - 2)) < 150 || int.Parse(hgt.Substring(0, hgt.Length - 2)) > 193)
                    {
                        isValid = false;
                    }
                }
                else
                {
                    if (int.Parse(hgt.Substring(0, hgt.Length - 2)) < 59 || int.Parse(hgt.Substring(0, hgt.Length - 2)) > 76)
                    {
                        isValid = false;
                    }
                }

            }
            else
            {
                return false;
            }


            if (!Regex.IsMatch(hcl, "^#[0-9a-f]{6}$"))
            {
                isValid = false;
            }

            if (!Regex.IsMatch(ecl, "^amb|blu|brn|gry|grn|hzl|oth$"))
            {
                isValid = false;
            }

            if (pid.Length != 9 || !int.TryParse(pid, out int n))
            {
                isValid = false;
            }



            return isValid;
        }
    }
}
