using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent.of.Code._2022
{
    class Day1
    {
        public void Run()
        {

            #region Init
            var textLines = File.ReadAllLines("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_1_input.txt");
            // Part 1
            List<int> elves = new List<int>();
            int max = 0;
            int calories = 0;

            // Part 2
            int count = 0;
            int multipleElves = 0;

            #endregion

            #region Part1
            foreach (var line in textLines)
            {
                // is line numeric
                if(int.TryParse(line, out int num))
                {
                    calories += num;

                }
                else
                {
                    elves.Add(calories);
                    // set max value
                    if(max < calories) { max = calories; }
                    calories = 0;
                }
            }

            Console.WriteLine("Max number is: " + max);
            #endregion

            #region Part2
            do
            {
                multipleElves += elves.Max();
                elves.Remove(elves.Max());
                count++;

            } while (count < 3);
            Console.WriteLine("Calories of top 3 elves are: " + multipleElves);
            #endregion
        }
    }
}
