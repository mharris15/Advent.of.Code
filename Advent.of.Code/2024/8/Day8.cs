using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/8
    /// </summary>
    [Advent("Resonant Collinearity", Difficulty.Easy)]
    public class Day8 : Day
    {
        private int width;
        private int height;
        protected override void Part1(string[] input)
        {
            var test = "............\n........0...\n.....0......\n.......0....\n....0.......\n......A.....\n............\n............\n........A...\n.........A..\n............\n............";
            //input = test.Split('\n');
            width = input[0].Length;
            height = input.Count();
            var grid = new char[width, height];
            Dictionary<char, List<(int, int)>> antennas = new();

            // Create antennas list
            for (int y = 0; y < height; y++)
            {
                var line = input[y];
                for(int x = 0; x < width; x++)
                {
                    var c = line[x];
                    grid[x, y] = c;
                    if (c != '.')
                    {
                        if(!antennas.TryGetValue(c, out var list))
                        {
                            list = new List<(int, int)>();
                            antennas[c] = list;
                        }
                        list.Add((x, y));
                    }
                }
            }

            // Calculate antinodes
            var antinodes = new HashSet<(int,int)> ();
            foreach(var antenna in antennas)
            {
                var list = antenna.Value;
                for(int i = 0; i < list.Count; i++)
                {
                    for(int j = i + 1; j < list.Count; j++)
                    {
                        var difference = (list[j].Item1 - list[i].Item1, list[j].Item2 - list[i].Item2);
                        antinodes.Add((list[i].Item1 - difference.Item1, list[i].Item2 - difference.Item2));
                        antinodes.Add((list[j].Item1 + difference.Item1, list[j].Item2 + difference.Item2));
                    }
                }
            }
            var count = 0;
            foreach(var antinode in antinodes)
            {
                if(IsInArea(antinode))
                {
                    count++;
                }
            }

            Console.WriteLine($"Part 1: {count}");
        }
        protected override void Part2(string[] input)
        {
            var test = "............\n........0...\n.....0......\n.......0....\n....0.......\n......A.....\n............\n............\n........A...\n.........A..\n............\n............";
           // input = test.Split('\n');
            width = input[0].Length;
            height = input.Count();
            var grid = new char[width, height];
            Dictionary<char, List<(int, int)>> antennas = new();

            // Create antennas list
            for (int y = 0; y < height; y++)
            {
                var line = input[y];
                for (int x = 0; x < width; x++)
                {
                    var c = line[x];
                    grid[x, y] = c;
                    if (c != '.')
                    {
                        if (!antennas.TryGetValue(c, out var list))
                        {
                            list = new List<(int, int)>();
                            antennas[c] = list;
                        }
                        list.Add((x, y));
                    }
                }
            }

            // Calculate antinodes
            var antinodes = new HashSet<(int, int)>();
            foreach (var antenna in antennas)
            {
                var list = antenna.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        var difference = (list[j].Item1 - list[i].Item1, list[j].Item2 - list[i].Item2);

                        var currentLocation = list[i];
                        do
                        {
                            antinodes.Add(currentLocation);
                            currentLocation = (currentLocation.Item1 - difference.Item1, currentLocation.Item2 - difference.Item2);
                        } while (IsInArea(currentLocation));

                        currentLocation = list[j];
                        do
                        {
                            antinodes.Add(currentLocation);
                            currentLocation = (currentLocation.Item1 + difference.Item1, currentLocation.Item2 + difference.Item2);
                        } while (IsInArea(currentLocation));
                    }
                }
            }
            var count = 0;
            foreach (var antinode in antinodes)
            {
                if (IsInArea(antinode))
                {
                    count++;
                }
            }

            Console.WriteLine($"Part 2: {count}");
        }
        bool IsInArea((int,int) point) => point.Item1 >= 0 && point.Item1 < width && point.Item2 >= 0 && point.Item2 < height;
    }
}
