using Advent.of.Code;
using System.Reflection;

class Program
{
    static readonly string Year = "2023";
    static readonly string Day = "1";
    
    static void Main()
    {
        Console.WriteLine("======================");
        Console.WriteLine("Year: "+Year);
        Console.WriteLine("Day: " + Day + Environment.NewLine);
        string[] input = ReadText(Year,Day);
        RunDay(Year,Day,input);
        Console.WriteLine("======================");
    }


    static string[] ReadText(string year, string day)
    {
        string solutionDirectory = GetSolutionDirectory();
        string directoryPath = Path.Combine(solutionDirectory, "Data", year);
        string filePath = Path.Combine(directoryPath, $"day_{day}_input.txt");
        return File.ReadAllText(filePath)
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
        Type type = Type.GetType($"Advent.of.Code._{year}.{className}");
        try
        {
            if (type != null)
            {
                Day dayInstance = (Day)Activator.CreateInstance(type);
                dayInstance.Run(input);
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








