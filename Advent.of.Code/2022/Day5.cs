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

    class Day5
    {
        public void Run()
        {

            List<Stack<string>> crates = new List<Stack<string>> {
                new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>() };
            List<Stack<string>> crates2 = new List<Stack<string>> {
                new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>(), new Stack<string>() };
            List<List<string>> input = new List<List<string>> {
                new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>() };
            List<string> moveList = new List<string>();
            var textLines = File.ReadAllLines("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_5_input.txt");

            // Create stack objects & move object
            foreach (var line in textLines)
            {
                int columnIndex = 1;
                int listIndex = 0;
                if (line.Contains("["))
                {
                    while(columnIndex < 34)
                    {
                        // is it a letter
                        if(Char.IsLetter(line[columnIndex]))
                        {
                            input[listIndex].Add(line[columnIndex].ToString());
                        }
                        columnIndex += 4;
                        listIndex++;
                    }
                }
                // Add movement
                if(line.Contains("move"))
                {
                    string move = line.Replace("move", "").Replace("from", "").Replace("to", "").Trim();
                    moveList.Add(move);
                }


            }
            // Create stack
            foreach(List<string> inputList in input)
            {
                int index = input.IndexOf(inputList);
                for(int i = inputList.Count - 1; i >= 0; i--)
                {
                    crates[index].Push(inputList[i]);
                    crates2[index].Push(inputList[i]);
                }
            }

            // Do moves
            foreach (string move in moveList)
            {
                var moveArray = move.Split(' ');
                int moveCount = Int32.Parse(moveArray[0].ToString());
                int from = Int32.Parse(moveArray[2].ToString());
                int to = int.Parse(moveArray[4].ToString());
                Stack<string> order = new Stack<string>();
                while(moveCount > 0)
                {
                    string fromCrate = crates[from - 1].Pop();
                    string fromCrate2 = crates2[from - 1].Pop();
                    crates[to - 1].Push(fromCrate);
                    order.Push(fromCrate2);
                    moveCount--;
                }
                foreach( string crate in order)
                {
                    crates2[to - 1].Push(crate);
                }
                
            }
            string endOfStack = "";
            foreach(Stack<string> stack in crates)
            {
                endOfStack += stack.Pop();
            }


            string endOfStack2 = "";
            foreach (Stack<string> stack in crates2)
            {
                endOfStack2 += stack.Pop();
            }

            Console.WriteLine("Top of each stack: " + endOfStack);
            Console.WriteLine("Top of each stack: " + endOfStack2);


        }
    }
}
