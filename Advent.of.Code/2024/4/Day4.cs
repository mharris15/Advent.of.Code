using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/4
    /// </summary>
    [Advent("Ceres Search", Difficulty.Easy)]
    public class Day4 : Day
    {
        protected override void Part1(string[] input)
        {
            int wordCount = 0;
            int width = input[0].Length;
            int height = 0;
            List<string> lines = new List<string>();

            foreach (var line in input)
            {
                lines.Add(line);
                height++;
            }

            char[,] map = new char[width, height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = lines[j][i];
                }

            }

            string[] targets = { "XMAS", "SAMX" };
            foreach (var target in targets)
            {
                for (int row = 0; row < map.GetLength(0); row++)
                {
                    for (int col = 0; col < map.GetLength(1); col++)
                    {

                        wordCount += GetWordCount(map, row, col, target);

                    }
                }
            }
            Console.WriteLine($"Part 1: {wordCount}");
        }

                  
        protected override void Part2(string[] input)
        {

            int wordCount = 0;
            int width = input[0].Length;
            int height = 0;
            List<string> lines = new List<string>();

            foreach (var line in input)
            {
                lines.Add(line);
                height++;
            }

            char[,] map = new char[width, height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = lines[j][i];
                }

            }

                for (int row = 0; row < map.GetLength(0); row++)
                {
                    for (int col = 0; col < map.GetLength(1); col++)
                    {

                        wordCount += GetXMASCount(map, row, col);

                    }
                }
            Console.WriteLine($"Part 2: {wordCount}");
        }
        public static int GetXMASCount(char[,] grid, int row, int col)
        {
            int count = 0;

            var c0 = CharAt(row, col, grid);
            var c1 = CharAt(row, col + 2, grid);
            var c2 = CharAt(row + 1, col + 1, grid);
            var c3 = CharAt(row + 2, col, grid);
            var c4 = CharAt(row + 2, col + 2, grid);

            if(c0 == 'M' && c1 == 'S' && c2=='A' && c3 =='M' && c4 =='S') {
                count++;
            }
            if(c0 == 'M' && c1 == 'M' && c2 == 'A' && c3 == 'S' && c4 == 'S')
            {
                count++;
            }
             if(c0 == 'S' && c1 == 'S' && c2 == 'A' && c3 == 'M' && c4 == 'M')
            {
                count++;
            }
            if (c0 == 'S' && c1 == 'M' && c2 == 'A' && c3 == 'S' && c4 == 'M')
            {
                count++;
            }
            return count;
        }
        public static int GetWordCount(char[,] grid, int row, int col, string word)
        {
            int count = 0;

            // Origin point
            var c0 = CharAt(row, col, grid);

            // Horizontal chars
            var ch1 = CharAt(row, col + 1, grid);
            var ch2 = CharAt(row, col + 2, grid);
            var ch3 = CharAt(row, col + 3, grid);

            if($"{c0}{ch1}{ch2}{ch3}" == word)
            {
                count++;
            }

            // Vertical chars
            var cv1 = CharAt(row + 1, col, grid);
            var cv2 = CharAt(row + 2, col, grid);
            var cv3 = CharAt(row + 3, col, grid);

            if ($"{c0}{cv1}{cv2}{cv3}" == word)
            {
                count++;
            }

            // Diagonal right chars
            var cdr1 = CharAt(row + 1, col + 1, grid);
            var cdr2 = CharAt(row + 2, col + 2, grid);
            var cdr3 = CharAt(row + 3, col + 3, grid);

            if ($"{c0}{cdr1}{cdr2}{cdr3}" == word)
            {
                count++;
            }

            // Diagonal left chars
            var cdl1 = CharAt(row + 1, col - 1, grid);
            var cdl2 = CharAt(row + 2, col - 2, grid);
            var cdl3 = CharAt(row + 3, col - 3, grid);
            if ($"{c0}{cdl1}{cdl2}{cdl3}" == word)
            {
                count++;
            }
            return count;
        }
        public static char CharAt(int x, int y, char[,] grid)
        {
            if (x < grid.GetLength(0) && x >= 0 && y < grid.GetLength(1) && y >= 0)
            {
                return grid[x,y];
            }
            return '0';
        }
    }


}
