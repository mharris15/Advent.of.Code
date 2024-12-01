using Advent.of.Code.Attributes;
using Advent.of.Code.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/1
    /// </summary>
    [Advent("Historian Hysteria", Difficulty.Easy)]
    public class Day1 : Day
    {
        protected override void Part1(string[] input)
        {
            int totalDistance = 0;
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            foreach (var line in input) 
            {
                var splitLine = line.Split(" ");
                leftList.Add(Int32.Parse(splitLine[0]));
                rightList.Add(Int32.Parse(splitLine[3]));
            }

            leftList.Sort();
            rightList.Sort();
            for (int i = 0; i < leftList.Count(); i++)
            {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);
            }

            Console.WriteLine($"Part 1: {totalDistance}");
            //AdventOfCodeUtility.service.SubmitAnswerAsync("2024", "1", "Answer", "1").GetAwaiter().GetResult();
        }

        protected override void Part2(string[] input)
        {
            int similarityScore = 0;
            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            foreach (var line in input)
            {
                var splitLine = line.Split(" ");
                leftList.Add(Int32.Parse(splitLine[0]));
                rightList.Add(Int32.Parse(splitLine[3]));
            }

            leftList.Sort();
            rightList.Sort();
            for (int i = 0; i < leftList.Count(); i++)
            {
                similarityScore += leftList[i] * rightList.Count(x => x == leftList[i]);
            }

            Console.WriteLine($"Part 2: {similarityScore}");
            //AdventOfCodeUtility.service.SubmitAnswerAsync("2024", "1", "Answer", "1").GetAwaiter().GetResult();
        }
    }
}
