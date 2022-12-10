// See https://aka.ms/new-console-template for more information
using Advent.of.Code._2022;
using System.IO;

var textLines = File.ReadAllLines("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_10_input.txt");


var input = File.ReadAllText("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_10_input.txt")
            .Split(' ', '\r', '\n').
            Where(x => x != "").ToArray();


Day10.Run(input);








