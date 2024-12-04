using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent.of.Code
{
    public abstract class Day
    {
        public void Run(string[] input)
        {
            Console.WriteLine("======================");
            Console.WriteLine("Solution");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Part1(input);
            stopwatch.Stop();
            var part1Time = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            Part2(input);
            stopwatch.Stop();
            Console.WriteLine("======================");
            Console.WriteLine("Elapsed Time");

            Console.WriteLine($"Part 1 executed in: {part1Time} ms");
            Console.WriteLine($"Part 2 executed in: {stopwatch.ElapsedMilliseconds} ms");
        }
        protected virtual void Part1(string[] input) {}

        protected virtual void Part2(string[] input) {}
    }
}
