using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day 2: Cube Conundrum: https://adventofcode.com/2023/day/2
    /// </summary>

    [Advent("Cube Conundrum", Difficulty.Easy)]
    public class Day2 : Day
    {
        static readonly int Red_Cube_Max  = 12;
        static readonly int Green_Cube_Max = 13;
        static readonly int Blue_Cube_Max = 14;
        protected override void Part1(string[] input)
        {
            int index = 1;
            int sumID = 0;
            foreach(string line in input)
            {
                bool gamePossible = true;
                string Updatedline = line.Replace("Game " + index.ToString() + ":", "").Trim();
                string[] gameArray = Updatedline.Split("; ");
                foreach(string singleGame in gameArray)
                {
                    string[] draw = singleGame.Split(", ");
                    foreach(string pull in draw)
                    {
                        string[] singlePull = pull.Split(" ");
                        switch(singlePull[1])
                        {
                            case "blue":
                                if(Int32.Parse(singlePull[0]) > Blue_Cube_Max)
                                {
                                    gamePossible= false;
                                }
                                break;

                            case "green":
                                if (Int32.Parse(singlePull[0]) > Green_Cube_Max)
                                {
                                    gamePossible = false;
                                }
                                break;

                            case "red":
                                if (Int32.Parse(singlePull[0]) > Red_Cube_Max)
                                {
                                    gamePossible = false;
                                }
                                break;

                        }
                        if(!gamePossible)
                        { break; }
                    }
                    if (!gamePossible)
                    { break; }
                }
                if (gamePossible)
                {
                    sumID += index;
                }
                index++;
            }
   
            Console.WriteLine("Part 1: " + sumID);
        }
        protected override void Part2(string[] input)
        {
            int index = 1;
            int sumPower = 0;
            foreach (string line in input)
            {
                int maxBlue = 0;
                int maxRed = 0;
                int maxGreen = 0;
                string Updatedline = line.Replace("Game " + index.ToString() + ":", "").Trim();
                string[] gameArray = Updatedline.Split("; ");
                foreach (string singleGame in gameArray)
                {
                    string[] draw = singleGame.Split(", ");
                    foreach (string pull in draw)
                    {
                        string[] singlePull = pull.Split(" ");

                        switch (singlePull[1])
                        {
                            case "blue":
                                if (Int32.Parse(singlePull[0]) > maxBlue)
                                {
                                    maxBlue = Int32.Parse(singlePull[0]);
                                }
                                break;

                            case "green":
                                if (Int32.Parse(singlePull[0]) > maxGreen)
                                {
                                    maxGreen = Int32.Parse(singlePull[0]);
                                }
                                break;

                            case "red":
                                if (Int32.Parse(singlePull[0]) > maxRed)
                                {
                                    maxRed = Int32.Parse(singlePull[0]);
                                }
                                break;
                        }

                    }

                }
                    sumPower += (maxBlue * maxRed * maxGreen);
                index++;
            }
            Console.WriteLine("Part 2: " + sumPower);
        }
    }
}
