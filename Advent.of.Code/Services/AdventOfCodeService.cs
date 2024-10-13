using Microsoft.Extensions.Configuration;

namespace Advent.of.Code.Services
{
    public class AdventOfCodeService
    {
        private readonly HttpClient _httpClient;
        private readonly int _startYear = 2015;
        private readonly int _endYear;


        public AdventOfCodeService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Cookie", $"session={GetSessionCookie()}");
            _endYear = DateTime.Now.Month == 12 ? DateTime.Now.Year : DateTime.Now.Year - 1;
        }

        public async Task<string> GetInputForDayAsync(int year, int day)
        {

            if (day < 1 || day > 25) { throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 25."); }
            if(year < _startYear || year > _endYear) { throw new ArgumentOutOfRangeException(nameof(year), "Year must be between " + _startYear + " and " + _endYear);}

            var url = $"https://adventofcode.com/{year}/day/{day}/input";

            try
            {

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }

            catch (HttpRequestException httpEx) { throw new HttpRequestException($"HTTP Request Error: {httpEx.Message}", httpEx); }
            catch (Exception ex) { throw new Exception($"An error occurred: {ex.Message}", ex);}
        }

        public async Task<bool> SubmitAnswerAsync(string year, string day, string answer, string part)
        {
            string url = $"https://adventofcode.com/{year}/day/{day}/answer";

            using (HttpClient client = new HttpClient())
            {

                var values = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("level", part),  
                new KeyValuePair<string, string>("answer", answer)
            });

                HttpResponseMessage response = await client.PostAsync(url, values);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Optionally log or analyze the response body for success or failure messages.
                    Console.WriteLine("Response: " + responseBody);

                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return false;
                }
            }
        }
        public static string GetSessionCookie()
        {
            IConfiguration configuration = new ConfigurationBuilder()
         .SetBasePath(AdventOfCodeUtility.GetSolutionDirectory())
         .AddJsonFile("appsettings", optional: false, reloadOnChange: true)
         .Build();

            return configuration["AdventOfCode:SessionCookie"];
        }
        public void RunDay(string year, string day, string[] input)
        {
            string className = $"Day{day}";

            // Attempt to retrieve Type based on provided classs name
            Type type = Type.GetType($"Advent.of.Code._{year}.{className}") ?? throw new Exception($"Class {className} not found.");

            // Attempt to create an instance of type Day
            Day dayInstance = Activator.CreateInstance(type) is Day instance ? instance : throw new Exception($"Failed to create an instance of class {className}");

            try { dayInstance.Run(input); }
            catch (Exception ex) { Console.WriteLine($"An error occurred: {ex.Message}"); }
        }
    }
}
