using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2023/day/9
    /// </summary>
    [Advent("Mirage Maintenance", Difficulty.Easy)]
    public class Day9 : Day
    {

        static int NextTerm(IEnumerable<int> arr)
        {
            var reduced = arr.Zip(arr.Skip(1), (a, b) => b - a);

            if (reduced.Distinct().Count() == 1)
                return reduced.First();

            return reduced.Last() + NextTerm(reduced);
        }

        protected override void Part1(string[] input)
        {
            var arrs = File.ReadAllLines("C:\\Users\\micha\\Desktop\\Programming\\.repo\\Advent.of.Code\\Advent.of.Code\\Data\\2023\\day_9_input.txt")
                      .Select(l => l.Trim().Split(' ').Select(n => int.Parse(n)).ToArray()).ToList();

            Console.WriteLine($"P1: {arrs.Select(arr => arr.Last() + NextTerm(arr)).Sum()}");
            Console.WriteLine($"P2: {arrs.Select(a => a.Reverse()).Select(arr => arr.Last() + NextTerm(arr)).Sum()}");
        }
        protected override void Part2(string[] input)
        {

            Console.WriteLine("Part 2: ");
        }
    }
}
