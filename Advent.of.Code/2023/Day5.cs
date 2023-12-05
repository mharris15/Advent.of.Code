using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace Advent.of.Code._2023
{
    public class Day5 : Day
    {

        string ParseMaps(string line)
        {
            return Regex.Replace(line, @"[^0-9 \n]", "");
        }

        long CalculateMapLocation(long source, List<string> map)
        {
            foreach(string line in map)
            {
                List<long> Ranges = line.Split(" ").Where(x => x != "").Select(y => long.Parse(y)).ToList();
                // in Range?
                var DestinationRangeStart = Ranges[0];
                var SourceRangeStart = Ranges[1];
                var RangeLength = Ranges[2];
                var max = SourceRangeStart + RangeLength;
                if (SourceRangeStart <= source && source <= max)
                {
                    var destinationRange = DestinationRangeStart - SourceRangeStart;
                    return source + destinationRange;
                }
            }
            return source;
        }
        List<long> GetAllSeeds(List<long> seeds)
        {
            List<long> output = new List<long>();  
            for(int i = 0; i < seeds.Count; i+=2) 
            {
                var start = seeds[i];
                var end = start + seeds[i+1];
                for(var j = start; j <= end; j++)
                {
                    output.Add(j);
                }
            }
            return output;
        }
        List<long> GetAllSeedsRange(List<long> seeds,long start,long end)
        {
            List<long> output = new List<long>();

                for (var j = start; j <= start + end; j++)
                {
                    output.Add(j);
                }
            
            return output;
        }


        protected override void Part1(string[] input)
        {

            List<long> Seeds = ParseMaps(input[0]).Split(" ").Where(x => x != "").Select(y => long.Parse(y)).ToList();
            List<string> SeedToSoil = ParseMaps(input[1]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> SoilToFertilizer = ParseMaps(input[2]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> FertilizerToWater = ParseMaps(input[3]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> WaterToLight = ParseMaps(input[4]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> LightToTemperature = ParseMaps(input[5]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> TemperatureToHumidity = ParseMaps(input[6]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> HumidityToLocation = ParseMaps(input[7]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<long> Locations = new List<long>();
            foreach(var seed in Seeds)
            {
                var soil = CalculateMapLocation(seed, SeedToSoil);
                var fert = CalculateMapLocation(soil, SoilToFertilizer);
                var water = CalculateMapLocation(fert, FertilizerToWater);
                var light = CalculateMapLocation(water, WaterToLight);
                var temp = CalculateMapLocation(light, LightToTemperature);
                var humi = CalculateMapLocation(temp, TemperatureToHumidity);
                var loc = CalculateMapLocation(humi, HumidityToLocation);
                Locations.Add(loc);

            }
            Console.WriteLine("Part 1: " + Locations.Min());


        }
        protected override void Part2(string[] input)
        {
                   
            long Locations = 0;
            List<string> SeedToSoil = ParseMaps(input[1]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> SoilToFertilizer = ParseMaps(input[2]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> FertilizerToWater = ParseMaps(input[3]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> WaterToLight = ParseMaps(input[4]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> LightToTemperature = ParseMaps(input[5]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> TemperatureToHumidity = ParseMaps(input[6]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<string> HumidityToLocation = ParseMaps(input[7]).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
            List<long> Seeds = ParseMaps(input[0]).Split(" ").Where(x => x != "").Select(y => long.Parse(y)).ToList();
            for (int i = 0; i < Seeds.Count; i += 2)
            {
                List<long> AllSeeds = GetAllSeedsRange(Seeds, Seeds[i], Seeds[i + 1]);
                
                foreach (var seed in AllSeeds)
                {
                    var soil = CalculateMapLocation(seed, SeedToSoil);
                    
                    var fert = CalculateMapLocation(soil, SoilToFertilizer);
                    var water = CalculateMapLocation(fert, FertilizerToWater);
                    var light = CalculateMapLocation(water, WaterToLight);
                    var temp = CalculateMapLocation(light, LightToTemperature);
                    var humi = CalculateMapLocation(temp, TemperatureToHumidity);
                    var loc = CalculateMapLocation(humi, HumidityToLocation);
                    if (loc < Locations || Locations ==0)
                    {
                        Locations = loc;
                    }
                }
            }

            Console.WriteLine("Part 2: " + Locations);
        }
    }
}
