using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2015
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2015/day/3
    /// </summary>
    [Advent("Perfectly Spherical Houses in a Vacuum", Difficulty.Easy)]
    internal class Day3 : Day
    {
  
        protected override void Part1(string[] input)
        {
            int x = 0;
            int y = 0;

            List<string> houses = new List<string>();
            houses.Add("0 0");
            string house;

            string line = input[0];
                foreach(char c in line)
                {
                    switch(c)
                    {
                        case '^':
                            y += 1;
                            break;
                        case '>':
                            x += 1;
                            break;
                        case '<':
                            x -= 1;
                            break;
                        case 'v':
                            y -= 1;
                            break;
                    }

                house = String.Format("{0} {1}", x, y);
                if (!houses.Contains(house))
                {
                    houses.Add(house);
                }
                }
            

            Console.WriteLine("Part 1: " + houses.Count);
        }
        protected override void Part2(string[] input)
        {
            int x = 0;
            int y = 0;
            bool isRobot = false;

            int robotX = 0;
            int robotY = 0;

            List<string> houses = new List<string>();
            houses.Add("0 0");
            string house;

            string line = input[0];
            foreach (char c in line)
            {
                if (isRobot)
                {
                    switch (c)
                    {
                        case '^':
                            robotY += 1;
                            break;
                        case '>':
                            robotX += 1;
                            break;
                        case '<':
                            robotX -= 1;
                            break;
                        case 'v':
                            robotY -= 1;
                            break;

                    }
                    house = String.Format("{0} {1}", robotX, robotY);
                }
                else
                {
                    switch (c)
                    {
                        case '^':
                            y += 1;
                            break;
                        case '>':
                            x += 1;
                            break;
                        case '<':
                            x -= 1;
                            break;
                        case 'v':
                            y -= 1;
                            break;

                    }
                    house = String.Format("{0} {1}", x, y);
                }
                    if (!houses.Contains(house))
                    {
                        houses.Add(house);
                    }
                isRobot = !isRobot;
             }
            Console.WriteLine("Part 2: " + houses.Count);
        }
    }
}
