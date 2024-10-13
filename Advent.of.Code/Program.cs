using Advent.of.Code.Services;
class Program
{
    private static readonly string year = "2023";
    private static readonly string day = "14";
    static void Main()
    {
        Console.WriteLine("======================");

        Console.WriteLine("Year: " + year);
        Console.WriteLine("Day: " + day);

        AdventOfCodeUtility.Initialize(year, day);
        AdventOfCodeUtility.Execute();

        Console.WriteLine("======================");
    }
}








