using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Collections.Specialized;

namespace Advent.of.Code._2022
{

    public class Day9
    {
        private static HashSet<(int x, int y)> _visited = new HashSet<(int x, int y)>();
        private static Coordinate headCoordinate = new Coordinate();
        private static Coordinate tailCoordinate = new Coordinate();


        public static void Run(string[] input)
        {
            _visited.Add((tailCoordinate.x, tailCoordinate.y));
            Part1(input,headCoordinate,tailCoordinate);
        }
        private static void Part1(string[] input, Coordinate head, Coordinate tail)
        {
            foreach (string line in input)
            {
                for (int movement = Int32.Parse(line[2].ToString());  movement > 0; movement--)
                {
                    updateHead(head,line);
                    updateTail(head, tail);
                    _visited.Add((tail.x, tail.y));
                }
            }
            Console.WriteLine("Part 1: " + _visited.Count);
        }
        private static void updateHead(Coordinate head,string line)
        {
            if (line[0].ToString().Equals("D"))
            {
                head.y--;
            }
            else if (line[0].ToString().Equals("U"))
            {
                head.y++;
            }
            else if (line[0].ToString().Equals("R"))
            {
                head.x++;
            }
            else if (line[0].ToString().Equals("L"))
            {
                head.x--;
            }
        }
        private static void updateTail(Coordinate head, Coordinate tail)
        {
            if(Math.Abs(head.x - tail.x) > 1 || Math.Abs(head.y - tail.y) > 1)
            { 
                tail.x += Math.Sign(head.x - tail.x);
                tail.y += Math.Sign(head.y - tail.y);
            }
        }


        class Coordinate
        {
            public int x = 0;
            public int y = 0;

        }
    }


}

   


