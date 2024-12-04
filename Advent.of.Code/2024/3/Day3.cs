using Advent.of.Code.Attributes;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/3
    /// </summary>
    [Advent("Mull It Over", Difficulty.Easy)]
    public class Day3 : Day
    {
        protected override void Part1(string[] input)
        {
            int result = 0;
            string regexPattern = @"mul\(\d{1,3},\d{1,3}\)";
            Regex regex = new Regex(regexPattern);
            foreach (var line in input)
            {
                MatchCollection matches = regex.Matches(line);
                foreach(Match match in matches)
                {
                    if (match.Success)
                    {
                        var numArray = match.Value.Replace("(", "").Replace(")", "").Replace("mul", "").Split(",");
                        result += int.Parse(numArray[0]) * int.Parse(numArray[1]);
                    }
                }
            }

                Console.WriteLine($"Part 1: {result}");
        }
        protected override void Part2(string[] input)
        {
            int result = 0;
            bool canMultiply = true; 
            string regexPattern = @"(mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\))";
            Regex regex = new Regex(regexPattern);
            foreach (var line in input)
            {
                MatchCollection matches = regex.Matches(line);
                foreach (Match match in matches)
                {

                    if (match.Success)
                    {
                       if(match.Value == "don't()")
                        {
                            canMultiply = false;
                        }
                        if (match.Value == "do()")
                        {
                            canMultiply = true;
                        }
                        else
                        {
                            if (canMultiply)
                            {
                                var numArray = match.Value.Replace("(", "").Replace(")", "").Replace("mul", "").Split(",");
                                result += int.Parse(numArray[0]) * int.Parse(numArray[1]);
                            }
                        }
                    }
                }
            }
                Console.WriteLine($"Part 2: {result}");
        }
    }
}
