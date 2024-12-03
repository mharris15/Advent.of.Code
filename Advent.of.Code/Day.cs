using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code
{
    public abstract class Day
    {
        public void Run(string[] input)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Part1(input);
            stopwatch.Stop();
            Console.WriteLine($"Executed in: {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            Part2(input);
            stopwatch.Stop();
            Console.WriteLine($"Executed in: {stopwatch.ElapsedMilliseconds} ms");
        }
        protected virtual void Part1(string[] input) {}

        protected virtual void Part2(string[] input) {}
    }
}
