using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2015
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2015/day/1
    /// </summary>
    [Advent("Not Quite Lisp", Difficulty.Easy)]
    internal class Day1 : Day
    {
        protected override void Part1(string[] input)
        {
            var floor = 0; 
            var s = input[0];
            foreach(char c in s)
            {
                if(c == '(')
                {
                    floor++;
                }
                if(c == ')')
                {
                    floor--;
                }

            }

            Console.WriteLine("Part 1: " + floor);
        }
        protected override void Part2(string[] input)
        {
            var floor = 0;
            var index = 1;
            var s = input[0];
            foreach (char c in s)
            {
                if (c == '(')
                {
                    floor++;
                }
                if (c == ')')
                {
                    floor--;
                }
                if(floor == -1)
                {
                    break;
                }
                index++;
                

            }
            Console.WriteLine("Part 2: " + index);
        }
    }
}
