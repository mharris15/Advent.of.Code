using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/7
    /// </summary>
    [Advent("Bridge Repair", Difficulty.Easy)]
    internal class Day7 : Day
    {
        protected override void Part1(string[] input)
        {
            long totalCalibration = 0;
            //var test = "190: 10 19\n3267: 81 40 27\n83: 17 5\n156: 15 6\n7290: 6 8 6 15\n161011: 16 10 13\n192: 17 8 14\n21037: 9 7 18 13\n292: 11 6 16 20";
            //input = test.Split('\n');
            foreach (var line in input)
            {
                var values = line.Split(':');
                var target = long.Parse(values[0]);
                var numbers = Array.ConvertAll(values[1].Trim().Split(" "), long.Parse);
                if (CanAchieveTarget(target, numbers, 0, numbers[0], false))
                {
                    totalCalibration += target;
                }
            }   
            Console.WriteLine($"Part 1: {totalCalibration}");
        }
        protected override void Part2(string[] input)
        {
            long totalCalibration = 0;
            foreach (var line in input)
            {
                var values = line.Split(':');
                var target = long.Parse(values[0]);
                var numbers = Array.ConvertAll(values[1].Trim().Split(" "), long.Parse);
                if (CanAchieveTarget(target, numbers, 0, numbers[0], true))
                {
                    totalCalibration += target;
                }
            }
            Console.WriteLine($"Part 2: {totalCalibration}");
        }
        bool CanAchieveTarget(long target, long[] numbers, int index, long currentResult, bool isPart2)
        {
            // Base case: if we've used all numbers, check if the result matches the target
            if (index == numbers.Length - 1)
            {
                return currentResult == target;
            }

            // Try adding the next number
            if (CanAchieveTarget(target, numbers, index + 1, currentResult + numbers[index + 1], isPart2))
            {
                return true;
            }

            // Try multiplying the next number
            if (CanAchieveTarget(target, numbers, index + 1, currentResult * numbers[index + 1], isPart2))
            {
                return true;
            }

            if (isPart2)
            {
                // Try concatenating the next number
                long concatenatedResult = ConcatenateNumbers(currentResult, numbers[index + 1]);
                if (CanAchieveTarget(target, numbers, index + 1, concatenatedResult, isPart2))
                {
                    return true;
                }
            }


            // If neither addition nor multiplication works, return false
            return false;
        }
        // Helper function to concatenate two numbers
        long ConcatenateNumbers(long a, long b)
        {
            return long.Parse(a.ToString() + b.ToString());
        }
    }
}
