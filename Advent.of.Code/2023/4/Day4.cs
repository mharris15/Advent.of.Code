using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day 4: Scratchcards: https://adventofcode.com/2023/day/4
    /// </summary>
    [Advent("Scratchcards", Difficulty.Medium)]
    public class Day4 : Day
    {
        protected override void Part1(string[] input)
        {
            int index = 1;
            int totalPoints = 0;
            foreach (string line in input)
            {
                string UpdatedLine = line.Trim().Replace(index.ToString() + ":", "");
                List<string> ScratchCards = UpdatedLine.Trim().Split("|").ToList();
                List<int> WinningCards = ScratchCards[0].Split(" ").Where(x => x != "").Select(y => Int32.Parse(y)).ToList();
                List<int> ScratchedCards = ScratchCards[1].Split(" ").Where(x => x != "").Select(y => Int32.Parse(y)).ToList();
                int MatchesCount = ScratchedCards.Intersect(WinningCards).Distinct().Count();
                if (MatchesCount > 0)
                {
                    totalPoints += 1 * (int)(Math.Pow(2, (double)MatchesCount - 1));
                }
                index++;

            }
            Console.WriteLine("Part 1: " + totalPoints);
        }
        protected override void Part2(string[] input)
        {
            int[] cardCount = new int[input.Length];
            for (int i = 0; i < cardCount.Length; i++)
            {
                cardCount[i] = 1;
            }

            for (int cardId = 0; cardId < input.Length; cardId++)
            {
                string? line = input[cardId];
                var parts = line.Split(':');
                var numbers = parts[1].Split('|');
                var pickedNumbers = numbers[0]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray();
                var ourNumbers = numbers[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray();

                var matchCount = pickedNumbers.Intersect(ourNumbers).Count();

                for (int i = 0; i < matchCount; i++)
                {
                    cardCount[cardId + 1 + i] += cardCount[cardId];
                }
            }


            Console.WriteLine("Part 2: " + cardCount.Sum());
        }


    }
}

