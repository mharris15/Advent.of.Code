using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Advent.of.Code._2022
{

    class Day6
    {
        public void Run()
        {
            var textLines = File.ReadAllLines("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_6_input.txt");

            int startIndex = 0;
            int stringSize = textLines[0].Length;
            int size = 14;
            int marker = 0;
            while(startIndex + size < stringSize)
            {
                string uniqueSubString = textLines[0].ToString().Substring(startIndex, size);
                if(uniqueCharacters(uniqueSubString))
                {
                    marker = startIndex + size;
                    break;
                }
                else
                {
                    startIndex++;
                }

            }
            Console.WriteLine("Marker for 4: " + marker);
        }

        static private bool uniqueCharacters(String str)
        {
            for (int i = 0; i < str.Length; i++)
                for (int j = i + 1; j < str.Length; j++)
                    if (str[i] == str[j])
                        return false;
            return true;
        }
    }
}
