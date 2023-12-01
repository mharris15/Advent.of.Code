using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    public class Day1 : Day
    {
        protected override void Part1(string[] input)
        {
            int CalibrationValue = 0;
            foreach (string line in input)
            {
                List<char> calibrationValues = line.Where(char.IsDigit).ToList();
                CalibrationValue += (10 * int.Parse(calibrationValues[0].ToString())) + int.Parse(calibrationValues[calibrationValues.Count - 1].ToString());
            }
            Console.WriteLine("Part 1: " + CalibrationValue);
        }
        protected override void Part2(string[] input)
        {
            int CalibrationValue = 0;
            foreach (string line in input)
            {
                string UpdatedLine = line.Replace("one", "o1e").Replace("two", "t2o").Replace("three", "t3e").Replace("four", "f4r").Replace("five", "f5e").Replace("six", "s6x").Replace("seven", "s7n").Replace("eight", "e8t").Replace("nine", "n9e");
                List<char> calibrationValues = UpdatedLine.Where(char.IsDigit).ToList();

                CalibrationValue += (10 * int.Parse(calibrationValues[0].ToString())) + int.Parse(calibrationValues[calibrationValues.Count - 1].ToString());

            }
            Console.WriteLine("Part 2: " + CalibrationValue);        
        }
    }
}
