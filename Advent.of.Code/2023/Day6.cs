using Advent.of.Code.Attributes;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2023/day/6
    /// </summary>
    [Advent("Wait for It", Difficulty.Easy)]
    internal class Day6 : Day
    {
        protected override void Part1(string[] input)
        {
            List<int> Times = input[0].Replace("Time:","").Split(" ").Where(x => x != "").Select(y => Int32.Parse(y)).ToList();
            List<int> DistanceRecord = input[1].Replace("Distance:", "").Split(" ").Where(x => x != "").Select(y => Int32.Parse(y)).ToList();
            List<int> WaysToWin = new List<int>();

            for (int i = 0; i < Times.Count; i++)
            {
                int wins = 0;
                for (int j = 0; j < Times[i]; j++)
                {
                    if (j != 0)
                    {
                        int raceTime = (Times[i] -j) * j;
                        if (raceTime > DistanceRecord[i]) {
                            wins++;
                        }
                    }      
                }
                if (wins > 0)
                {
                    WaysToWin.Add(wins);
                }

            }
            int ProductWaysToWin = 1;
            foreach(int win in WaysToWin)
            {
                ProductWaysToWin *= win;
            }
            Console.WriteLine("Part 1: " + ProductWaysToWin);
        }
        protected override void Part2(string[] input)
        {
            var Time = long.Parse(input[0].Replace("Time:", "").Replace(" ", ""));
            var Distance = long.Parse(input[1].Replace("Distance:", "").Replace(" ", ""));

            var wins = 0;
            for (var j = 0; j < Time; j++)
            {
                if (j != 0)
                {
                    var raceTime = (Time - j) * j;
                    if (raceTime > Distance)
                    {
                        wins++;
                    }
                }
            }

            Console.WriteLine("Part 2: " + wins);
        }
    }
}

