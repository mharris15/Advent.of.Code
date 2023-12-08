using Advent.of.Code.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// Day Link: https://adventofcode.com/2023/day/8
    /// </summary>
    [Advent("Haunted Wasteland", Difficulty.Medium)]
    public class Day8 : Day
    {
       // public static readonly string Instructions = "LR";
         public static readonly string Instructions = "LRRLRRRLRLRLLRRLRLRLLRLRLRLLLLRRRLLRRRLRRRLRRRLLRLLRLRRLRLRLRRRLLLLRRLRLRRLRRLLRRRLRRLRLRRLRRLRRLRRLRLLRRLRRLLLLRLRLRRLLRRLLRRLRLLRLRRLRRLRRLRRRLRRLLLRRLRRRLRLRRRLLRLRRLRRRLRRLLRRRLRRLRLLRRLLRRLRRLRRRLRRLLRRLRRRLRLRLRLRLRLRRLRRLLRRRLRLRRLRRRLRLRLRLRLRLRRRLRRLRRRLLRRLRLLRRRLRRLRLLLLRRRLRRLRRRR";
        public static readonly string StartingNode = "AAA";
        public static readonly string GoalNode = "ZZZ";

        public struct Node
        {
            public string Left { get; set; }
            public string Right { get; set; }

            public Node(string left, string right)
            {
                Left = left;
                Right = right;
            }
        }

        public Dictionary<string, Node> CreateNetwork(string[] input)
        {
            Dictionary<string, Node> Network = new Dictionary<string, Node>();

            foreach (string line in input)
            {
                if (line.Contains("="))
                {
                    List<string> IndivNode = line.Split("=").ToList();
                    List<string> Steps = IndivNode[1].Replace("(", "").Replace(")", "").Trim().Split(",").ToList();
                    string startNode = IndivNode[0].Trim();
                    Network.Add(startNode, new Node(Steps[0].Trim(), Steps[1].Trim()));
                }
            }
            return Network;
        }
        public int StepCount(string startingNode, Dictionary<string, Node> network)
        {
            string node = startingNode;
            int stepCounter = 0;
            while(!node.ElementAt(node.Length - 1).ToString().Contains("Z"))
           // while (node != GoalNode)
            {
                for (int i = 0; i < Instructions.Length; i++)
                {
                    Node Steps = network[node];
                    switch (Instructions[i])
                    {
                        case 'L':
                            node = Steps.Left;
                            break;

                        case 'R':
                            node = Steps.Right;
                            break;
                    }
                    stepCounter++;
                    if (node.ElementAt(node.Length - 1).ToString().Contains("Z"))
                    // if (node == GoalNode)
                    {
                        break;
                    }
                }
                if(node.ElementAt(node.Length - 1).ToString().Contains("Z"))
               // if (node == GoalNode)
                {
                    break;
                }
            }
            return stepCounter;
        }
        // Function to calculate GCD (Greatest Common Divisor) using Euclidean algorithm
        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Function to calculate LCM (Least Common Multiple) using GCD for an array of integers
        static int LCM(List<int> numbers)
        {
            if (numbers.Count == 0)
                throw new ArgumentException("Array should contain at least one element.");

            int result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = (numbers[i] * result) / GCD(numbers[i], result);
            }
            return result;
        }
        protected override void Part1(string[] input)
        {
            Dictionary<string, Node> Network = CreateNetwork(input);
            

         //   Console.WriteLine("Part 1: " + StepCount(StartingNode,Network));
        }
        protected override void Part2(string[] input)
        {
            
            Dictionary<string, Node> Network = CreateNetwork(input);
            List<string> StartingNodes = new List<string>();
            List<int> StepCounts = new List<int>();
            foreach (string node in Network.Keys)
            {
                if(node.ElementAt(node.Length-1).ToString().Contains("A"))
                {
                    StartingNodes.Add(node);
                }
            }
            foreach(string node in StartingNodes)
            {
                StepCounts.Add(StepCount(node, Network));
            }

            Console.WriteLine("Part 2: " + LCM(StepCounts));
        }
    }
}
