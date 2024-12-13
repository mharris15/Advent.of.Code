using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/6
    /// </summary>
    [Advent("Guard Gallivant", Difficulty.Easy)]
    public class Day6 : Day
    {
        Dictionary<int, (int, int)> directions = new()
        {
            { 0, (0, -1) }, // up
            { 1, (1, 0) }, // right
            { 2, (0, 1) }, // down
            { 3, (-1, 0) } // left
        };
        (int x, int y) dimension = (130, 130);
        protected override void Part1(string[] input)
        {
            //var s= "....#.....\n.........#\n..........\n..#.......\n.......#..\n..........\n.#..^.....\n........#.\n#.........\n......#...";
           // input = s.Split('\n');
            var startingPosition = (0, 0);
            var map = new char[130, 130];
            var visited = new int[130, 130];
            var guard = (0,0,0);

            var rowIndex = 0;
            foreach(var line in input)
            {
                var colIndex = 0;
                foreach(var c in line)
                {
                    map[colIndex, rowIndex] = c;
                    if(c == '^')
                    {
                        startingPosition = (colIndex, rowIndex);    
                        guard = (colIndex, rowIndex, 0);
                        visited[colIndex, rowIndex] = 1;
                    }
                    colIndex++;
                }
                rowIndex++;
            }
            bool canWalk = true;
            while(canWalk)
            {
                // Get next direction
                var direction = directions[guard.Item3];
                var nextPosition = (guard.Item1 + direction.Item1, guard.Item2 + direction.Item2);
                
                if (HasLeftArea(nextPosition.Item1, nextPosition.Item2))
                {
                    canWalk = false;
                    break;
                }

                if (map[nextPosition.Item1, nextPosition.Item2] == '#')
                {
                    // Rotate
                    guard.Item3 = (guard.Item3 + 1) % 4;
                }
                else
                {
                    guard.Item1 = nextPosition.Item1;
                    guard.Item2 = nextPosition.Item2;
                    visited[nextPosition.Item1, nextPosition.Item2] = 1;
                }

            }

            Console.WriteLine($"Part 1: {visited.Cast<int>().Count(x => x == 1)}");
        }
        protected override void Part2(string[] input)
        {
            //var s = "....#.....\n.........#\n..........\n..#.......\n.......#..\n..........\n.#..^.....\n........#.\n#.........\n......#...";
            //input = s.Split('\n');
            var startingPosition = (0, 0);
            var map = new char[130, 130];
            var visited = new int[130, 130];
            var guard = (0, 0, 0);

            var visitListWithDirection = new List<(int, int, int)>();

            var rowIndex = 0;
            foreach (var line in input)
            {
                var colIndex = 0;
                foreach (var c in line)
                {
                    map[colIndex, rowIndex] = c;
                    if (c == '^')
                    {
                        startingPosition = (colIndex, rowIndex);
                        guard = (colIndex, rowIndex, 0);
                        visited[colIndex, rowIndex] = 1;
                    }
                    colIndex++;
                }
                rowIndex++;
            }
            bool canWalk = true;
            while (canWalk)
            {
                // Get next direction
                var direction = directions[guard.Item3];
                var nextPosition = (guard.Item1 + direction.Item1, guard.Item2 + direction.Item2);

                if (HasLeftArea(nextPosition.Item1, nextPosition.Item2))
                {
                    canWalk = false;
                    break;
                }

                if (map[nextPosition.Item1, nextPosition.Item2] == '#')
                {
                    // Rotate
                    guard.Item3 = (guard.Item3 + 1) % 4;
                }
                else
                {
                    guard.Item1 = nextPosition.Item1;
                    guard.Item2 = nextPosition.Item2;
                    visited[nextPosition.Item1, nextPosition.Item2] = 1;
                }

            }



            int count = 0;
            guard = (startingPosition.Item1, startingPosition.Item2, 0);
            for (int i = 0; i < visited.GetLength(0); i++) {
                for (int j = 0; j < visited.GetLength(1); j++)
                {
                    if (visited[i, j] == 1)
                    {
                        if (DoesGuardLoop(guard, map, (i, j)))
                        {
                            count++;
                        }
                    }
                }
            }


            Console.WriteLine($"Part 2: {count}");
        }

        bool DoesGuardLoop((int x,int y, int d) guard, char[,] map, (int,int) block)
        {
            var newGuard = guard;
            var newMap = map;
            var startingPosition = (guard.x, guard.y);
            var visited = new int[130, 130];
            newMap[block.Item1, block.Item2] = '#';


            bool canWalk = true;
            int iteratioCount = 0;
            bool isPrevious = false;
            while (canWalk)
            {
                iteratioCount++;
                // Get next direction
                var direction = directions[guard.Item3];
                var nextPosition = (newGuard.Item1 + direction.Item1, newGuard.Item2 + direction.Item2);

                    if (HasLeftArea(nextPosition.Item1, nextPosition.Item2))
                    {
                        canWalk = false;
                        break;
                    }
                try
                {
                    if(isPrevious)
                    {
                        return true;
                    }
                    if (visited[nextPosition.Item1, nextPosition.Item2] == 1)
                    {
                        return true;
                    }
                    if (newMap[nextPosition.Item1, nextPosition.Item2] == '#')
                    {
                        isPrevious = true;
                        // Rotate
                        newGuard.Item3 = (guard.Item3 + 1) % 4;
                    }
                    else
                    {
                        newGuard.Item1 = nextPosition.Item1;
                        newGuard.Item2 = nextPosition.Item2;
                        visited[nextPosition.Item1, nextPosition.Item2] = 1;
                    }
                }
                catch
                {
                    return true;
                }


                if(iteratioCount > 100)
                {
                    return false;
                }
            }
             return false;
        }
        bool HasLeftArea(int x, int y) => x < 0 || x >= dimension.x || y < 0 || y >= dimension.y;

    }
}
