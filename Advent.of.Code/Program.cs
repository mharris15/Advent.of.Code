// See https://aka.ms/new-console-template for more information
using Advent.of.Code._2022;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

class Program
{
    static string Year = "2023";
    static string Day = "1";
    
    static void Main()
    {
        string[] input = ReadText(Year,Day);
        RunDay(Year,Day,input);
    }


    static string[] ReadText(string year, string day)
    {
        string solutionDirectory = GetSolutionDirectory();
        string directoryPath = Path.Combine(solutionDirectory, "Data", year);
        string filePath = Path.Combine(directoryPath, $"day_{day}_input.txt");
        var textlines = File.ReadAllLines(filePath);
        return File.ReadAllText("C:\\Users\\MichaelHarris\\OneDrive - Agility Partners\\Documents\\repos\\Internal\\Advent\\Advent.of.Code\\Advent.of.Code\\Data\\2022\\day_10_input.txt")
               .Split(' ', '\r', '\n').
               Where(x => x != "").ToArray();
    }

    static string GetSolutionDirectory()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        DirectoryInfo directory = new DirectoryInfo(currentDirectory);

        while (directory != null && directory.Name != "Advent.of.Code")
        {
            directory = directory.Parent;
        }

        return directory?.FullName;
    }

    static void RunDay(string year, string day, string[] input)
    {
        string className = $"Day{day}";
        Type type = Type.GetType($"Advent.of.Code._{year}.{className}"); ;
        try
        {
            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod("Run");
                if (methodInfo != null)
                {
                    // Define input parameters
                    object[] parameters = { input }; 

                    // Invoke the method, since it is a static class no instance is needed.
                    methodInfo.Invoke(null, parameters);
                }
                else
                {
                    Console.WriteLine($"Method 'Run' not found in class {className}.");
                }
            }
            else
            {
                Console.WriteLine($"Class {className} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}








