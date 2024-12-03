using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/2
    /// </summary>
    [Advent("Red-Nosed Reports", Difficulty.Easy)]
    public class Day2 : Day
    {
        // Check how many lists are monotonic
        protected override void Part1(string[] input)
        {
            int safe = 0;
            foreach (var line in input)
            {
                bool asc = true;
                bool desc = true;
                var list = line.Split(" ");
                for(int i=0; i<list.Length - 1; i++)
                {
                    if(i != 0)
                    {
                        int z = int.Parse(list[i-1]);
                    }
                    int x = int.Parse(list[i]);
                    int y = int.Parse(list[i+1]);
                    if (Math.Abs(x - y) > 3 || Math.Abs(x-y) < 1)
                    {
                        asc = false;
                        desc = false;
                    }
                    if (x > y)
                    {
                        asc = false;
                    }
                    if (x < y)
                    {
                        desc = false;
                    }
                }
                if (asc || desc)
                {
                    safe++;
                }

            }
            Console.WriteLine($"Part 1: {safe}");
        }
        protected override void Part2(string[] input)
        {
            int safe = 0;
            foreach (var line in input)
            {
                var list = line.Split(" ").Select(int.Parse).ToList();

                bool IsMonotonicAndGradual(List<int> lst)
                {
                    bool asc = true;
                    bool desc = true;

                    for (int i = 0; i < lst.Count - 1; i++)
                    {
                        int x = lst[i];
                        int y = lst[i + 1];

                        if (Math.Abs(x - y) > 3 || Math.Abs(x - y) < 1)
                            return false; // Not gradual

                        if (x > y)
                            asc = false;

                        if (x < y)
                            desc = false;
                    }

                    return asc || desc; // Monotonic condition
                }

                if (IsMonotonicAndGradual(list))
                {
                    safe++;
                    continue;
                }

                bool isSafeWithOneRemoval = false;

                for (int i = 0; i < list.Count; i++)
                {
                    var tempList = new List<int>(list);
                    tempList.RemoveAt(i);

                    if (IsMonotonicAndGradual(tempList))
                    {
                        isSafeWithOneRemoval = true;
                        break;
                    }
                }

                if (isSafeWithOneRemoval)
                    safe++;
            }

            Console.WriteLine($"Part 2: {safe}");
        }
    }
}
