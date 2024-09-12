using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent.of.Code._2022
{

    class Day4
    {
        public void Run()
        {


            var textLines = File.ReadAllLines("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_4_input.txt");
            int containedCount = 0;
            int overlap = 0;
 
            foreach (var line in textLines)
            {
                var arraysplit = line.Split(',');
                var firstSplit = arraysplit[0].Split('-');
                var secondSplit = arraysplit[1].Split('-');

                int firstMin = Int32.Parse(firstSplit[0].ToString());
                int firstMax = Int32.Parse(firstSplit[1].ToString());

                int SecondMin = Int32.Parse(secondSplit[0].ToString());
                int SecondMax = Int32.Parse(secondSplit[1].ToString()); ;

                // Are ranges contained in each other?
                if ((firstMin <= SecondMin && firstMax >= SecondMax) || (firstMin >= SecondMin && firstMax <= SecondMax)
                    || (firstMin == SecondMin && firstMax == SecondMin) || (firstMin == SecondMax && firstMax == SecondMax) || (SecondMin == firstMin && SecondMin == firstMax) || (SecondMax == firstMin && SecondMax == firstMax))
                {
                    containedCount++;
                }

                // overlap
                if (firstMin <= SecondMax && SecondMin <= firstMax)
                {
                    overlap++;
                }
            }
            Console.WriteLine("Line coount that fully contain each other: " + containedCount);
            Console.WriteLine("Overlap count: " + overlap);


        }
    }
}
