namespace Advent.of.Code.Services
{
    public static class AdventOfCodeUtility
    {
        public static readonly AdventOfCodeService service = new();
        private static string _year;
        private static string _day;
        private static string _filePath;

        public static string GetFilePath(string year, string day)
        {
            string solutionDirectory = GetSolutionDirectory();
            string directoryPath = Path.Combine(solutionDirectory, year, day);
            return Path.Combine(directoryPath, $"input.txt");
        }

        public static async Task WriteNewDayFile(string year, string day, string filePath)
        {
            if (!File.Exists(filePath))
            {
                string day_input = await service.GetInputForDayAsync(int.Parse(year), int.Parse(day));
                await File.WriteAllTextAsync(filePath, day_input);
            }
        }
        public static string[] ReadText(string filePath)
        {
            return File.ReadAllLines(filePath)//.ReadAllText(filePath) // ReadAllLines
                                              // .Split('\n')//.Split("map").
                                              //   .Split(' ', '\r', '\n').
                   .Where(x => x != "").ToArray();
        }

        public static string GetSolutionDirectory()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directory = new(currentDirectory);

            while (directory != null && directory.Name != "Advent.of.Code") { directory = directory.Parent!; }
            return directory?.FullName!;
        }

        public static void Execute() => service.RunDay(_year, _day, ReadText(_filePath));
        public static void Initialize(string year, string day)
        {
            _year = year;
            _day = day;
            _filePath = GetFilePath(year, day);
            WriteNewDayFile(year, day, _filePath).GetAwaiter().GetResult();
        }
    }
}
