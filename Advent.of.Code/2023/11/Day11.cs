using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2023/day/11
    /// </summary>
    [Advent("Cosmic Expansion", Difficulty.Medium)]
    public class Day11 : Day
    {
        public record GalaxyMap(IList<Vector> Galaxies)
        {
            public long SumOfShortestDistances()
            {
                var pairs = Galaxies.SelectMany((g1, i) => Galaxies.Skip(i + 1).Select(g2 => (g1, g2))).ToArray();
                var sum = 0L;
                foreach (var (g1, g2) in pairs)
                {
                    sum += g1.VectorTo(g2).NumberSteps;
                }

                return sum;
            }

            public static GalaxyMap FromInput(IList<string> lines, long expansionMultiplier = 2)
            {
                var rowsToAdd = Enumerable.Range(0, lines.Count).Where(row => lines[row].All(c => c == '.')).ToArray();
                var colsToAdd = Enumerable.Range(0, lines[0].Length).Where(col => lines.All(l => l[col] == '.')).ToArray();

                var galaxies = new List<Vector>();
                for (var row = 0; row < lines.Count; row++)
                {
                    var rowOffset = rowsToAdd.Count(r => r <= row) * (expansionMultiplier - 1);
                    for (var col = 0; col < lines[0].Length; col++)
                    {
                        if (lines[row][col] != '#') continue;

                        var colOffset = colsToAdd.Count(c => c <= col) * (expansionMultiplier - 1);
                        galaxies.Add(new Vector(row + rowOffset, col + colOffset));
                    }
                }

                return new GalaxyMap(galaxies);
            }
        }
        public record Vector(long Row, long Col)
        {
            public override string ToString() => $"[{Row}, {Col}]";

            public Vector VectorTo(Vector other) => new(other.Row - Row, other.Col - Col);

            public long NumberSteps { get; } = Math.Abs(Row) + Math.Abs(Col);
        }

        protected override void Part1(string[] input)
        {
            var map = GalaxyMap.FromInput(input);
         

            Console.WriteLine("Part 1: " + map.SumOfShortestDistances().ToString());
            
        }
        protected override void Part2(string[] input)
        {
            var map = GalaxyMap.FromInput(input.ToArray(), long.Parse("1000000"));
            Console.WriteLine("Part 2: " + map.SumOfShortestDistances().ToString());
        }
    }
}
