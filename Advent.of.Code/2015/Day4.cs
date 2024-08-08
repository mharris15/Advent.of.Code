using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2015
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2015/day/4
    /// </summary>
    [Advent("The Ideal Stocking Stuffer", Difficulty.Hard)]
    internal class Day4 : Day
    {
        protected override void Part1(string[] input)
        {
            MD5 md5 = MD5.Create();
            var key = "iwrupvqb";
            int count = 0;

            bool isSolved = false;

            while(!isSolved)
            {
                var inputBytes = Encoding.ASCII.GetBytes(String.Format(key + count));
                var hash = md5.ComputeHash(inputBytes);
               
                if (hash[0] == 0 && hash[1] == 0 && hash[2] == 0) // Part 1: hash[2] < 10)
                {
                    break;
                }
                    count++;
            }

            Console.WriteLine("Part 1: " + count);
        }
        protected override void Part2(string[] input)
        {

            Console.WriteLine("Part 2: ");
        }
    }
}
