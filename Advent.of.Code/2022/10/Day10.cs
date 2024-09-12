using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Collections.Specialized;
using Microsoft.Win32;

namespace Advent.of.Code._2022
{
    //var input = File.ReadAllText("input.txt")
    //        .Split(' ', '\r', '\n').
    //        Where(x => x != "").ToArray();
    public static class Day10
    {
        public static void Run(string[] input)
        {
            Part1(input);
            Part2(input);

        }

        private static void Part1(string[] input)
        {
            int cycle = 0;
            int register = 1;
            int signalStrength = 0;
            string previousInstruction = "";
            foreach (string line in input)
            {
                cycle++;
                if (cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220)
                {
                    signalStrength += (register * cycle);

                }

                if ((line.ToString().Contains("addx") && previousInstruction != "addx") || line.ToString().Contains("coop"))
                {
                    previousInstruction = line.ToString();
                }
                else if (previousInstruction == "addx")
                {
                    register += Int32.Parse(line.ToString());
                    previousInstruction = line.ToString();

                }


            }
            Console.WriteLine("Part 1: " + signalStrength);

        }
        private static void Part2(string[] input)
        {

            int cycle = 0;
            int register = 1;
            int signalStrength = 0;
            string previousInstruction = "";
            int pixelPos = 0;
            foreach (var instruction in input)
            {
                cycle++;

                if (pixelPos >= register - 1 && pixelPos <= register + 1)
                    Console.Write('#');
                else
                    Console.Write('.');
                pixelPos++;
                if (pixelPos % 40 == 0)
                {
                    Console.WriteLine();
                    pixelPos = 0;
                }
                if (cycle == 20 || cycle == 60 || cycle == 100
                    || cycle == 140 || cycle == 180 || cycle == 220)
                {
                    signalStrength += cycle * register;
                }
                if ((instruction == "addx" && previousInstruction != "addx") || instruction == "noop")
                {
                    previousInstruction = instruction;
                }
                else if (previousInstruction == "addx")
                {
                    register += int.Parse(instruction);
                    previousInstruction = instruction;
                }

            }
        }

    }


        }






   


