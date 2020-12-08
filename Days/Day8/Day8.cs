using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Days.Day8
{
    class Day8
    {
        private static List<string> input;

        static Day8() => input = Utilities.Instance.GetInput(nameof(Day8));

        public static void SolvePartOne()
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (string item in input)
            {
                string[] splittedInstruction = item.Split(' ');

                Instruction instruction = new Instruction();
                instruction.Operation = splittedInstruction[0].Trim();
                instruction.Argument = int.Parse(splittedInstruction[1].Trim());
                instructions.Add(instruction);
            }

            RunCodeA(instructions);
        }

        private static void RunCodeA(List<Instruction> instructions)
        {
            int instructionIndexToRunNext = 0;
            int accumulator = 0;
            List<Instruction> executedInstructions = new List<Instruction>();
            int runs = 0;
            while (true)
            {
                Instruction nextInstruction = instructions[instructionIndexToRunNext];
                if (executedInstructions.Contains(nextInstruction))
                {
                    Console.WriteLine("Accumulator: {0}", accumulator);
                }
                switch (nextInstruction.Operation)
                {
                    case "acc":
                        accumulator += nextInstruction.Argument;
                        instructionIndexToRunNext++;
                        break;
                    case "jmp":
                        instructionIndexToRunNext += nextInstruction.Argument;
                        break;
                    case "nop":
                        instructionIndexToRunNext++;
                        break;

                    default:
                        break;
                }

                if (executedInstructions.Count > instructions.Count)
                {
                    
                    
                    break;
                }
                else if (executedInstructions.Count == instructions.Count)
                {
                    Console.WriteLine("Accumulator {0}", accumulator);
                }



                executedInstructions.Add(nextInstruction);



            }
        }

        public static void SolvePartTwo()
        {
            List<Instruction> instructions = new List<Instruction>();
            foreach (string item in input)
            {
                string[] splittedInstruction = item.Split(' ');

                Instruction instruction = new Instruction();
                instruction.Operation = splittedInstruction[0].Trim();
                instruction.Argument = int.Parse(splittedInstruction[1].Trim());
                instructions.Add(instruction);
            }

            RunCodeB(instructions);
        }

        private static void RunCodeB(List<Instruction> instructions)
        {
            int instructionIndexToRunNext = 0;
            int accumulator = 0;
            List<Instruction> executedInstructions = new List<Instruction>();
            List<Instruction> jmps = instructions.FindAll(z => z.Operation == "jmp");
            List<Instruction> nops = instructions.FindAll(z => z.Operation == "nop");

            var test = instructions.Find(z => z == jmps[1]);

            for (int i = 0; i < instructions.Count; i++)
            {
                List<Instruction> originalInstructions = new List<Instruction>();
                foreach (string item in input)
                {
                    string[] splittedInstruction = item.Split(' ');

                    Instruction instruction = new Instruction();
                    instruction.Operation = splittedInstruction[0].Trim();
                    instruction.Argument = int.Parse(splittedInstruction[1].Trim());
                    originalInstructions.Add(instruction);
                }

                instructions = originalInstructions;

                switch (instructions[i].Operation)
                {
                    case "jmp":
                        instructions[i].Operation = instructions[i].Operation.Replace("jmp", "nop");
                        break;
                    case "nop":
                        instructions[i].Operation = instructions[i].Operation.Replace("nop", "jmp");
                        break;
                    default:
                        break;
                }
                RunCodeA(instructions);

            }

            //while (true)
            //{
            //    Instruction nextInstruction = instructions[instructionIndexToRunNext];
                
            //    switch (nextInstruction.Operation)
            //    {
            //        case "acc":
            //            accumulator += nextInstruction.Argument;
            //            instructionIndexToRunNext++;
            //            break;
            //        case "jmp":
            //            instructionIndexToRunNext += nextInstruction.Argument;
            //            break;
            //        case "nop":
            //            instructionIndexToRunNext++;
            //            break;

            //        default:
            //            break;
            //    }



            //    executedInstructions.Add(nextInstruction);



            //}
        }
    }
}
