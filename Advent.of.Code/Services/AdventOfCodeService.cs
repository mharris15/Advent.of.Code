using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.of.Code.Services
{
    public class AdventOfCodeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _sessionCookie;


        public AdventOfCodeService(string sessionCookie)
        {
            _httpClient = new HttpClient();
            _sessionCookie = sessionCookie;
        }

        public async Task<string> GetInputForDayAsync(int year, int day)
        {
            if (day < 1 || day > 25)
            {
                throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 25.");
            }

            if(year < 2015 || year > 2023)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 2015 and 2023.");
            }

            var url = $"https://adventofcode.com/{year}/day/{day}/input";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Cookie", $"session={_sessionCookie}");

            try
            {
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP Request Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }
        
    }
}
