using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2023/day/15
    /// </summary>
    [Advent("Lens Library", Difficulty.Easy)]

    internal class Day15 : Day
    {
        private class Lens
        {
            public string Label { get; set; }
            public int FocalLength { get; set; }
        }
        private static int CalculateHash(string valueToHash)
        {
            return valueToHash.Aggregate(0, PerformHashStep);
        }

        private static int PerformHashStep(int current, char value)
        {
            return (current + value) * 17 % 256;
        }

        private static void PerformInstruction(List<Lens> lenses, string label, string instruction)
        {
            switch (instruction[0])
            {
                case '-':
                    lenses.RemoveAll(lens => lens.Label == label);
                    break;

                case '=':
                    var focalLength = int.Parse(instruction[1..]);
                    var existingLens = lenses.FirstOrDefault(lens => lens.Label == label);
                    if (existingLens != null)
                    {
                        existingLens.FocalLength = focalLength;
                    }
                    else
                    {
                        lenses.Add(new Lens { Label = label, FocalLength = focalLength });
                    }
                    break;

                default:
                    throw new Exception($"Unexpected instruction found: {instruction}");
            }
        }
        private static int GetBoxFocusingPower(KeyValuePair<int, List<Lens>> box)
        {
            var focusingPower = 0;
            for (var i = 0; i < box.Value.Count; ++i)
            {
                focusingPower += (1 + box.Key) * (1 + i) * box.Value[i].FocalLength;
            }

            return focusingPower;
        }
        protected override void Part1(string[] input)
        {
            var resultSum = 0;
            var steps = input[0].Split(",").ToList();
            foreach (string step in steps)
            {
                var currentValue =  0;
                foreach(char c in step)
                {
                    int asciiValue = (int)c;
                    currentValue += asciiValue;
                    currentValue *= 17;
                    currentValue = currentValue % 256;
                }
                resultSum += currentValue;
            }
            Console.WriteLine("Part 1: " + resultSum);
        }
        protected override void Part2(string[] input)
        {
            var labelRegex = new Regex(@"[^-=]+");
            var boxes = Enumerable.Range(0, 256).ToDictionary(n => n, _ => new List<Lens>());

            foreach (var step in input[0].Split(','))
            {
                var label = labelRegex.Match(step).Value;
                var instruction = step[label.Length..];
                var boxId = CalculateHash(label);

                PerformInstruction(boxes[boxId], label, instruction);
            }
            Console.WriteLine("Part 2: " + boxes.Sum(GetBoxFocusingPower));
        }
    }
}
