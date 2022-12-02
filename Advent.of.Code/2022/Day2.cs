using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Advent.of.Code._2022
{
    class Day2
    {
        public void Run()
        {

            #region Init
            var textLines = File.ReadAllLines("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\day_2_input.txt");
 
            int score = 0;
            int secretScore = 0;




            #endregion

            #region Part1
            foreach (var line in textLines)
            {
                // Win
                if(line.Contains("A Y") || line.Contains("B Z") || line.Contains("C X"))
                {
                    score += 6;
                }

                // Draw
                if (line.Contains("A X") || line.Contains("B Y") || line.Contains("C Z"))
                {
                    score += 3;
                }

                // Rock
                if (line.Contains("X"))
                {
                    score += 1;
                    
                }
                // Paper
                if (line.Contains("Y"))
                {
                    score += 2;
                    secretScore += 3;
                }
                // Scissor
                if (line.Contains("Z"))
                {
                    score += 3;
                    secretScore += 6;
                }
                // Secret X
                if (line.Contains("A Y") || line.Contains("B X") || line.Contains("C Z"))
                {
                    secretScore += 1;
                }
                // Secret Y
                if (line.Contains("A Z") || line.Contains("B Y") || line.Contains("C X"))
                {
                    secretScore += 2;
                }
                // Secret Z
                if (line.Contains("A X") || line.Contains("B Z") || line.Contains("C Y"))
                {
                    secretScore += 3;
                }
            }
            Console.WriteLine("Total Score: " + score);

            #endregion

            #region Part2
            Console.WriteLine("Total Secret Score: " + secretScore);

            #endregion
        }
    }
}
