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
    [Advent("Red-Nosed Reports", Difficulty.NA)]
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

                // Function to check if the list is monotonic and gradual
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

                // Check if the original list is safe
                if (IsMonotonicAndGradual(list))
                {
                    safe++;
                    continue;
                }

                // Check if removing a single element makes the list safe
                bool isSafeWithOneRemoval = false;

                for (int i = 0; i < list.Count; i++)
                {
                    // Create a temporary list without the current element
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

            // Output the count of safe lines
            Console.WriteLine(safe);
        }



        bool isSafe(List<int> list)
        {
            bool isAscending = true;
            bool isDescending = true;

            for (int i = 0; i < list.Count - 1; i++)
            {
                int diff = Math.Abs(list[i] - list[i + 1]);
                if (diff < 1 || diff > 3) return false;

                if (list[i] > list[i + 1]) isAscending = false;
                if (list[i] < list[i + 1]) isDescending = false;
            }

            return isAscending || isDescending;
        }
    }
}
