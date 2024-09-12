using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2015
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2015/day/2
    /// </summary>
    [Advent("I Was Told There Would Be No Math", Difficulty.Easy)]

    
    internal class Day2 : Day
    {

        private int _part1Answer;
        private int GetSmallestArea(int l, int w, int h)
        {
            int largest = Math.Max(l, Math.Max(w, h));

            if(largest == l) 
            {
                return w * h;
            }
            if(largest == w)
            {
                return l * h;
            }
            if (largest == h) 
            {
                return l * w;
            }


            return 0;
        }

        private int GetSmallestPerimeter(int l, int w, int h)
        {
            return 2 * Math.Min(l+w, Math.Min(w+h, l+ h));
        }
        protected override void Part1(string[] input)
        {
            var surfaceArea = 0;
            foreach (var dim in input)
            {
                var dimArray = dim.Split("x");
                int l = Convert.ToInt32(dimArray[0]);
                int w = Convert.ToInt32(dimArray[1]);
                int h = Convert.ToInt32(dimArray[2]);

                
                var presentSqFt = (2 * l * w) + (2 * w* h) + (2 * h * l) + GetSmallestArea(l,w,h);
                surfaceArea += presentSqFt;
            }
            _part1Answer = surfaceArea;
            Console.WriteLine("Part 1: " + surfaceArea);
        }
        protected override void Part2(string[] input)
        {
            var ribbon = 0;
            foreach (var dim in input)
            {
                var dimArray = dim.Split("x");
                int l = Convert.ToInt32(dimArray[0]);
                int w = Convert.ToInt32(dimArray[1]);
                int h = Convert.ToInt32(dimArray[2]);


                int ribbonFt = GetSmallestPerimeter(l, w, h) + (l*w*h);
                ribbon += ribbonFt;
            }
            Console.WriteLine("Part 2: "+ ribbon);
        }
    }
}
