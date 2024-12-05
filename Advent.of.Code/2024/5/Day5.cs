using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2024
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2024/day/5
    /// </summary>
    [Advent("Print Queue", Difficulty.Easy)]
    public class Day5 : Day
    {
        protected override void Part1(string[] input)
        {
            int result = 0;
            int result2 = 0;
            List<string> rulesList = new List<string>();
            List<string> updates = new List<string>();
            foreach (var line in input)
            {
                if(line.Length == 5)
                    rulesList.Add(line);
                else
                {
                    updates.Add(line);
                }

            }

            HashSet<(int, int)> rules = new ();
            foreach (var rule in rulesList)
            {
                var parts = rule.Split('|').Select(int.Parse).ToArray();
                int from = parts[0], to = parts[1];
                rules.Add((from, to));
            }

            Comparer comparer = new Comparer(rules);

            foreach(var update in updates)
            {
                bool abidesByRules = true;
                var numbers = update.Split(',').Select(int.Parse).ToList();
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (comparer.Compare(numbers[i], numbers[i + 1]) > 0)
                    {
                        abidesByRules =  false;
                        numbers.Sort(comparer);
                        result2 += numbers[numbers.Count() / 2];

                    }
                }

                if (abidesByRules)
                {
                    result += numbers[numbers.Count() / 2];
                }

            }
            Console.WriteLine($"Part 1: {result}");
            Console.WriteLine($"Part 2: {result2}");
        }

        
        protected override void Part2(string[] input)
        {

        }

        class Comparer : IComparer<int>
        {
            private HashSet<(int, int)> _rules;

            public Comparer(HashSet<(int, int)> rules)
            {
                _rules = rules;
            }

            public int Compare(int x, int y)
            {
                if (_rules.Contains((x, y)))
                    return -1; // x should come before y
                if (_rules.Contains((y, x)))
                    return 1;  // y should come before x
                return 0;     // No rule between x and y
            }
        }
    }



}
