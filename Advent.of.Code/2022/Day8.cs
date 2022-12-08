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

namespace Advent.of.Code._2022
{

    public class Day8
    {
        private static Node[,] nodes;
        private static int totalVisibleCount = 0;
        private static List<int> TotalScenic = new List<int>();
        private static int maxWidth = 0;
        private static int maxHeight = 0;
        public static void Run(string[] input)
        {
            CreateGrid(input);
            DetermineTreevisibility();
            Console.WriteLine("Total trees that are visible: " + totalVisibleCount);
            Console.WriteLine("Scenic total: " + TotalScenic.Max());
            
        }
        public static void CreateGrid(string[] input)
        {;
            maxWidth = input[0].Length;
            maxHeight = input.Length;
            nodes = new Node[maxWidth,maxHeight];

            int heightIndex = 0;
            foreach (string line in input)
            {
                int widthIndex = 0;
                foreach (char tree in line)
                {
                    // Create node
                    nodes[widthIndex, heightIndex] = new Node();
                    nodes[widthIndex, heightIndex].x = widthIndex;
                    nodes[widthIndex, heightIndex].y = heightIndex;
                    nodes[widthIndex, heightIndex].size = Int32.Parse(tree.ToString());
                    widthIndex++;
                }
                heightIndex++;
                widthIndex = 0;
            }
        }

        public static void DetermineTreevisibility()
        {
            for (int i = 0; i < maxHeight; i++)
            {
                for (int j = 0; j < maxWidth; j++)
                {
                    // Total visibillity 
                    bool left = CountVisible(j, i, -1, 0, nodes[i, j].size);
                    bool right = CountVisible(j, i, 1, 0, nodes[i, j].size);
                    bool up = CountVisible(j, i, 0, -1, nodes[i, j].size);
                    bool down = CountVisible(j, i, 0, 1, nodes[i, j].size);
                    if (up || down || left || right)
                        totalVisibleCount++;

                    // Total Scenic 
                    int leftScenic = CountScenicScore(j, i, -1, 0, nodes[i, j].size);
                    int rightScenic = CountScenicScore(j, i, 1, 0, nodes[i, j].size);
                    int upScenic = CountScenicScore(j, i, 0, -1, nodes[i, j].size);
                    int downScenic = CountScenicScore(j, i, 0, 1, nodes[i, j].size);
                    TotalScenic.Add(leftScenic * rightScenic * upScenic * downScenic);
                }
            }

        }


        class Node
        {
            public int x;
            public int y;
            public bool isVisible;
            public int size;
            

        }


        public static bool CountVisible(int x, int y, int xIncrement, int yIncrement, int startValue)
        {
            if (x == 0 || x == maxWidth - 1|| y == 0 || y == maxHeight - 1)
                return true;
            if (startValue <= nodes[y + yIncrement,x + xIncrement].size)
                return false;

            return CountVisible(x + xIncrement, y + yIncrement, xIncrement, yIncrement, startValue);
        }
        public static int CountScenicScore(int x, int y, int xIncrement, int yIncrement, int startValue)
        {
            if (x == 0 || x == maxWidth - 1 || y == 0 || y == maxHeight - 1)
                return 0;
            if (startValue <= nodes[y + yIncrement,x + xIncrement].size)
                return 1;

            return 1 + CountScenicScore(x + xIncrement, y + yIncrement, xIncrement, yIncrement, startValue);
        }
    }
   
}


