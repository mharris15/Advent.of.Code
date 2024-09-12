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
        private readonly int _startYear = 2015;
        private readonly int _endYear;


        public AdventOfCodeService(string sessionCookie)
        {
            _httpClient = new HttpClient();
            _sessionCookie = sessionCookie;
            _endYear = DateTime.Now.Month == 12 ? DateTime.Now.Year : DateTime.Now.Year - 1;

        }

        public async Task<string> GetInputForDayAsync(int year, int day)
        {

            if (day < 1 || day > 25) { throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 25."); }
            if(year < _startYear || year > _endYear) { throw new ArgumentOutOfRangeException(nameof(year), "Year must be between " + _startYear + " and " + _endYear);}

            var url = $"https://adventofcode.com/{year}/day/{day}/input";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Cookie", $"session={_sessionCookie}");

            try
            {
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }

            catch (HttpRequestException httpEx) { throw new HttpRequestException($"HTTP Request Error: {httpEx.Message}", httpEx); }
            catch (Exception ex) { throw new Exception($"An error occurred: {ex.Message}", ex);}
        }     
    }
}
