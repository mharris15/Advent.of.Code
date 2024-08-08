using Advent.of.Code;
using Advent.of.Code.Services;

class Program
{
    static readonly string SessionCookie = "*";
    static readonly string Year = "2015";
    static readonly string Day = "5";


    static void Main()
    {
        Console.WriteLine("======================");

        string filePath = GetFilePath(Year, Day);
        WriteNewDayFile(Year, Day, filePath).GetAwaiter().GetResult();
 
        Console.WriteLine("Year: "+Year);
        Console.WriteLine("Day: " + Day);

        string[] input = ReadText(filePath);
        RunDay(Year,Day,input);

        Console.WriteLine("======================");
    }

    static string GetFilePath(string year, string day)
    {
        string solutionDirectory = GetSolutionDirectory();
        string directoryPath = Path.Combine(solutionDirectory, "Data", year);
        return Path.Combine(directoryPath, $"day_{day}_input.txt");
    }

    static async Task WriteNewDayFile(string year, string day, string filePath)
    {
        if (!File.Exists(filePath)) 
        {
            AdventOfCodeService adventOfCodeService = new AdventOfCodeService(SessionCookie);
            string day_input = await adventOfCodeService.GetInputForDayAsync(int.Parse(year), int.Parse(day));
            await File.WriteAllTextAsync(filePath, day_input);
         }    
    }

    static string[] ReadText(string filePath)
    {
        return File.ReadAllLines(filePath)//.ReadAllText(filePath) // ReadAllLines
              // .Split('\n')//.Split("map").
             //   .Split(' ', '\r', '\n').
               .Where(x => x != "").ToArray();
    }

    static string GetSolutionDirectory()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        DirectoryInfo directory = new DirectoryInfo(currentDirectory);

        while (directory != null && directory.Name != "Advent.of.Code")
        {
            directory = directory.Parent!;
        }

        return directory?.FullName!;
    }

    static void RunDay(string year, string day, string[] input)
    {
        string className = $"Day{day}";

        // Attempt to retrieve Type based on provided classs name
        Type type = Type.GetType($"Advent.of.Code._{year}.{className}") ?? throw new Exception($"Class {className} not found.");

        // Attempt to create an instance of type Day
        Day dayInstance = Activator.CreateInstance(type) is Day instance ? instance : throw new Exception($"Failed to create an instance of class {className}");

        try
        { 
            dayInstance.Run(input);      
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}








