using Advent.of.Code.Attributes;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2023/day/12
    /// </summary>
    [Advent("Hot Springs", Difficulty.Medium)]
    internal class Day12 : Day
    {
        protected override void Part1(string[] input)
        {
            foreach(string line in input)
            {
                var parts = line.Split(" ");

                var damagedSprings = parts[1].Split(",").Select(a => int.Parse(a)).ToArray(); ;
                Console.WriteLine("Part 1: ");
            }

            Console.WriteLine("Part 1: ");
        }
        protected override void Part2(string[] input)
        {

            Console.WriteLine("Part 2: ");
        }
    }
}
