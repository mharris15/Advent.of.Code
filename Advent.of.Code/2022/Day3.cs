using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent.of.Code._2022
{

    class Day3
    {
        public void Run()
        {

            #region Init
            var textLines = File.ReadAllLines("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_3_input.txt");
            int rucksack = 0;
            char common = ' ';
            #endregion

            #region Part1
            foreach (var line in textLines)
            {
              
                string firstHalf = line.Substring(0, (int)line.Length / 2);
                string secondHalf = line.Substring((int)line.Length / 2, (int)line.Length / 2);
                foreach (char c in firstHalf)
                {
                    if(secondHalf.Contains(c))
                    {
                        common = c;
                        break;
                    }
                }

                if(Char.IsUpper(common))
                {
                    rucksack += Convert.ToInt32(common) - 38;
                }
                else
                {
                    rucksack += Convert.ToInt32(common) - 96;
                }
            }

            Console.WriteLine("Rucksack total: " + rucksack);
            #endregion

            #region Part2
            int index = 0;
            rucksack = 0;
            while (index < textLines.Length)
            {
                string line = textLines[index];
                string line2 = textLines[index + 1];
                string line3 = textLines[index + 2];
                foreach (char c in line)
                {
                    if(line2.Contains(c) && line3.Contains(c))
                    {
                        common = c;
                        break;
                    }
                }
                if (Char.IsUpper(common))
                {
                    rucksack += Convert.ToInt32(common) - 38;
                }
                else
                {
                    rucksack += Convert.ToInt32(common) - 96;
                }

                index = index + 3;
            }
            Console.WriteLine("Group Rucksack total: " + rucksack);
            #endregion
        }
    }
}
