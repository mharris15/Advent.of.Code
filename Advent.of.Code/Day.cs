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
            Part1(input);
            Part2(input);
        }
        protected virtual void Part1(string[] input) {}

        protected virtual void Part2(string[] input) {}
    }
}
