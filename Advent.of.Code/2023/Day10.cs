using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2023/day/10
    /// </summary>
    [Advent("Pipe Maze", Difficulty.Medium)]
    internal class Day10 : Day
    {
        public struct Node
        {
            public int X { get; set; }
            public int Y { get; set; }


            public Node(int x, int y)
            {
                X = x;
                Y = y;

            }
        }
        enum Direction
        {
            North,
        South,
        West,
         East,
         None
        }

        int _maxWidth;
        int _maxHeight;
        Node _startingPointLocation; 
        Node _north = new Node(0, -1);
        Node _south = new Node(0, 1);
        Node _east = new Node(1, 0);
        Node _west = new Node(-1, 0);
        List<List<char>> CreateMap(string[] input)
        {
            List<List<char>> Map = new List<List<char>>();
            int rowIndex = 0;
            foreach(string line in input)
            {
                List<char> row = new List<char>();
                for(int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToString() == "S")
                    {
                        _startingPointLocation = new Node(rowIndex, i);
                        
                    }
                    row.Add(line[i]);
                }
                rowIndex++;
                Map.Add(row);
            }
            _maxHeight = rowIndex;
            _maxWidth = input[0].Length;
            return Map;
        }

        int FarthestPoint(List<List<char>> Map, int startX, int startY, Enum directionCameFrom)
        {
            
            int total = 0;
            if (CanTraverse(Map, Direction.North, startX, startY) && directionCameFrom.CompareTo(Direction.North) != 0)
                return total += 1 + FarthestPoint(Map, startX - 1, startY, Direction.South);

            if (CanTraverse(Map, Direction.South, startX, startY) && directionCameFrom.CompareTo(Direction.South) != 0)
                return total += 1 + FarthestPoint(Map, startX + 1, startY, Direction.North);

            if (CanTraverse(Map, Direction.East, startX, startY) && directionCameFrom.CompareTo(Direction.East) != 0)
                return total += 1 + FarthestPoint(Map, startX, startY + 1, Direction.West);

            if (CanTraverse(Map, Direction.West, startX, startY) && directionCameFrom.CompareTo(Direction.West) != 0)
                return total += 1 + FarthestPoint(Map, startX, startY - 1, Direction.East);

            return total;
        }

        bool CanTraverse(List<List<char>> Map, Enum direction, int x, int y)
        {
            string previousChar = Map[x][y].ToString();  
            switch (direction)
            {
                case Direction.North:
                    if (x - 1 >= 0)
                        if(previousChar.Contains("L") || previousChar.Contains("J") || previousChar.Contains("|") || previousChar.Contains("S"))
                            if (Map[x-1][y].ToString().Contains("7")|| Map[x-1][y].ToString().Contains("F")|| Map[x-1][y].ToString().Contains("|"))
                                return true;
                    break;
                case Direction.South:
                    if (x + 1 < _maxHeight)
                        if (previousChar.Contains("7") || previousChar.Contains("F") || previousChar.Contains("|") || previousChar.Contains("S"))
                            if (Map[x+1][y].ToString().Contains("L") || Map[x+1][y].ToString().Contains("J") || Map[x+1][y].ToString().Contains("|"))
                            return true;
                    break;
                case Direction.East:
                    if (y + 1 < _maxWidth)
                        if (previousChar.Contains("L") || previousChar.Contains("F") || previousChar.Contains("-") || previousChar.Contains("S"))
                            if (Map[x][y+1].ToString().Contains("J") || Map[x][y+1].ToString().Contains("7") || Map[x][y + 1].ToString().Contains("-"))
                            return true;
                    break;
                case Direction.West:
                    if (y - 1 >= 0)
                        if (previousChar.Contains("J") || previousChar.Contains("7") || previousChar.Contains("-") || previousChar.Contains("S"))
                            if (Map[x][y-1].ToString().Contains("F") || Map[x][y-1].ToString().Contains("L") || Map[x][y - 1].ToString().Contains("-"))
                            return true;
                    break;
            }
            return false;
        }

        List<int> Totals(List<List<char>> PipeMap)
        {
            List<int> totals = new List<int>();
            int northTotal = 0;
            int southTotal = 0;
            int westTotal = 0;
            int eastTotal = 0;
            int startX = _startingPointLocation.X;
            int startY = _startingPointLocation.Y;



            if (CanTraverse(PipeMap, Direction.North, startX, startY))
                northTotal += 1 + FarthestPoint(PipeMap, startX - 1, startY, Direction.South);

            if (CanTraverse(PipeMap, Direction.South, startX, startY))
                southTotal += 1 + FarthestPoint(PipeMap, startX + 1, startY, Direction.North);

            if (CanTraverse(PipeMap, Direction.East, startX, startY))
                eastTotal += 1 + FarthestPoint(PipeMap, startX, startY + 1, Direction.West);

            if (CanTraverse(PipeMap, Direction.West, startX, startY))
                westTotal += 1 + FarthestPoint(PipeMap, startX, startY - 1, Direction.East);


            totals.Add(northTotal);
            totals.Add(southTotal);
            totals.Add(eastTotal);
            totals.Add(westTotal);
            return totals;
        }

        protected override void Part1(string[] input)
        {
            List<List<char>> PipeMap= CreateMap(input);
            List<int> totals = Totals(PipeMap);


            Console.WriteLine("Part 1: " + totals[0] +" "+ totals[1] + " "+totals[2] + " " + totals[3]);
        }
        protected override void Part2(string[] input)
        {

            Console.WriteLine("Part 2: ");
        }
    }
}
