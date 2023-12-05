using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using Advent.of.Code.Attributes;

namespace Advent.of.Code._2023
{
    /// <summary>
    /// If You Give A Seed A Fertilizer: https://adventofcode.com/2023/day/5
    /// </summary>
    [Advent("If You Give A Seed A Fertilizer", Difficulty.Hard)]
    public class Day5 : Day
    {

        string ParseMaps(string line)
        {
            return Regex.Replace(line, @"[^0-9 \n]", "");
        }

        List<string> ParseSpecificMaps(string input)
        {
            return ParseMaps(input).Split("\n").Where(x => x != "" && x != " ").Select(y => y).ToList();
        }

        long CalculateMapLocation(long source, List<string> map)
        {
            foreach (string line in map)
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
            for (int i = 0; i < seeds.Count; i += 2)
            {
                var start = seeds[i];
                var end = start + seeds[i + 1];
                for (var j = start; j <= end; j++)
                {
                    output.Add(j);
                }
            }
            return output;
        }
        List<long> GetAllSeedsRange(long start, long end)
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
            List<string> SeedToSoil = ParseSpecificMaps(input[1]);
            List<string> SoilToFertilizer = ParseSpecificMaps(input[2]);
            List<string> FertilizerToWater = ParseSpecificMaps(input[3]);
            List<string> WaterToLight = ParseSpecificMaps(input[4]);
            List<string> LightToTemperature = ParseSpecificMaps(input[5]);
            List<string> TemperatureToHumidity = ParseSpecificMaps(input[6]);
            List<string> HumidityToLocation = ParseSpecificMaps(input[7]);
            List<long> Locations = new List<long>();
            foreach (var seed in Seeds)
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
            List<long> test = new List<long>();
            List<long> Seeds = ParseMaps(input[0]).Split(" ").Where(x => x != "").Select(y => long.Parse(y)).ToList();
            List<string> SeedToSoil = ParseSpecificMaps(input[1]);
            List<string> SoilToFertilizer = ParseSpecificMaps(input[2]);
            List<string> FertilizerToWater = ParseSpecificMaps(input[3]);
            List<string> WaterToLight = ParseSpecificMaps(input[4]);
            List<string> LightToTemperature = ParseSpecificMaps(input[5]);
            List<string> TemperatureToHumidity = ParseSpecificMaps(input[6]);
            List<string> HumidityToLocation = ParseSpecificMaps(input[7]);

            var ranges = new List<(long from, long to)>();
            for (int i = 0; i < Seeds.Count; i += 2)
                ranges.Add((from: Seeds[i], to: Seeds[i] + Seeds[i + 1] - 1));


            foreach (var range in ranges)
            {
                var soil = CalculateMapLocation(range.from, SeedToSoil);
                var fert = CalculateMapLocation(soil, SoilToFertilizer);
                var water = CalculateMapLocation(fert, FertilizerToWater);
                var light = CalculateMapLocation(water, WaterToLight);
                var temp = CalculateMapLocation(light, LightToTemperature);
                var humi = CalculateMapLocation(temp, TemperatureToHumidity);
                var loc = CalculateMapLocation(humi, HumidityToLocation);
                Console.WriteLine("Range from: " + range.from);
                Console.WriteLine("loc " + loc);

                test.Add(loc);
                if (loc < Locations || Locations == 0)
                {
                    Locations = loc;
                }
            }
            Console.WriteLine("Part 2: " + test.Min()); 
        }
          
        }
    }




