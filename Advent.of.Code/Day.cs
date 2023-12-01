using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code
{
    public abstract class Day
    {
        public void Run(string[] input)
        {
            RunDay(input);
        }
        public void RunDay(string[] input)
        {
            Part1(input);
            Part2(input);
        }
        protected virtual void Part1(string[] input)
        {
            // Common logic for Part1
            // Implement specific Part1 logic here or in derived classes
        }

        protected virtual void Part2(string[] input)
        {
            // Common logic for Part2
            // Implement specific Part2 logic here or in derived classes
        }
    }
}
