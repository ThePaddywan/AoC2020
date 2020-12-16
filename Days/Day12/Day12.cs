using AoC2020.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020.Days.Day12
{
    class Day12
    {
        private static List<string> input;

        static Day12() => input = Utilities.Instance.GetInput(nameof(Day12));

        public static  Vector2 North = new Vector2(1, 0);
        public static  Vector2 East = new Vector2(0, 1);
        public static  Vector2 South = new Vector2(-1, 0);
        public static  Vector2 West = new Vector2(0, -1);



        public static void SolvePartOne()
        {
            List<Instruction> instructions = input.Select(x => new Instruction
            {
                Operation = (Operation)x[0],
                Value = int.Parse(x.Substring(1))
            }).ToList();

            Vector2 direction = East;
            Vector2 movement = new Vector2();

            foreach (Instruction instruction in instructions)
            {
                switch (instruction.Operation)
                {
                    case Operation.North:
                        movement += North * instruction.Value;
                        break;

                    case Operation.South:
                        movement += South * instruction.Value;
                        break;

                    case Operation.East:
                        movement += East * instruction.Value;
                        break;

                    case Operation.West:
                        movement += West * instruction.Value;
                        break;

                    case Operation.Left:
                        {
                            int value = instruction.Value / 90;

                            for (int i = 0; i < value; i++)
                            {
                                Vector2 temp = direction;
                                direction.X = temp.Y;
                                direction.Y = -temp.X;
                            }
                            break;
                        }

                    case Operation.Right:
                        {
                            int value = instruction.Value / 90;

                            for (int i = 0; i < value; i++)
                            {
                                Vector2 temp = direction;
                                direction.X = -temp.Y;
                                direction.Y = temp.X;
                            }
                            break;
                        }

                    case Operation.Forward:
                        movement += direction * instruction.Value;
                        break;
                }
            }
            Console.WriteLine((int)(Math.Abs(movement.X) + Math.Abs(movement.Y)));
        }

        public static void SolvePartTwo()
        {
            List<Instruction> instructions = input.Select(x => new Instruction
            {
                Operation = (Operation)x[0],
                Value = int.Parse(x.Substring(1))
            }).ToList();

            Vector2 waypoint = 10 * East + 1 * North;
            Vector2 ship = new Vector2();

            foreach (Instruction instruction in instructions)
            {
                switch (instruction.Operation)
                {
                    case Operation.North:
                        waypoint += North * instruction.Value;
                        break;

                    case Operation.South:
                        waypoint += South * instruction.Value;
                        break;

                    case Operation.East:
                        waypoint += East * instruction.Value;
                        break;

                    case Operation.West:
                        waypoint += West * instruction.Value;
                        break;

                    case Operation.Left:
                        {
                            int value = instruction.Value / 90;

                            for (int i = 0; i < value; i++)
                            {
                                Vector2 temp = waypoint;
                                waypoint.X = temp.Y;
                                waypoint.Y = -temp.X;
                            }
                            break;
                        }

                    case Operation.Right:
                        {
                            int value = instruction.Value / 90;

                            for (int i = 0; i < value; i++)
                            {
                                Vector2 temp = waypoint;
                                waypoint.X = -temp.Y;
                                waypoint.Y = temp.X;
                            }
                            break;
                        }

                    case Operation.Forward:
                        ship += waypoint * instruction.Value;
                        break;
                }
            }

            int answer = (int)(Math.Abs(ship.X) + Math.Abs(ship.Y));

            Console.WriteLine(answer);
        }
    }
}
