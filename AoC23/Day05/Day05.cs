using AoC23;
public class Day05 : IDay
{
    List<long> seeds = new();
    List<MapRange> seedPair = new();
    List<List<(MapRange, MapRange)>> mappingRange = new();
    public struct MapRange
    {
        public long start;
        public long end;
        public MapRange(long start, long end)
        {
            this.start = start;
            this.end = end;
        }
    }
    public Day05(string file)
    {
        // Set input text file to "LF" instead of "CRLF" to read \n correctly
        string input = File.ReadAllText(file);
        string[] groups = input.Split("\n\n");
        string[] seedStr = groups[0].Split("seeds: ")[1].Split(' ');

        for (int i = 0; i < seedStr.Length; i++)
        {
            // For part 1:
            seeds.Add(long.Parse(seedStr[i]));

            // For part 2:
            if (i % 2 == 0)
                seedPair.Add(new MapRange(long.Parse(seedStr[i]), long.Parse(seedStr[i + 1])));
        }

        List<(MapRange, MapRange)> seed2SoilRange = new();
        foreach (var seed2Soil in groups[1].Split("seed-to-soil map:\n")[1].Split("\n"))
            AddRange(seed2SoilRange, seed2Soil);
        mappingRange.Add(seed2SoilRange);

        List<(MapRange, MapRange)> soil2FertilizerRange = new();
        foreach (var soil2Fertilizer in groups[2].Split("soil-to-fertilizer map:\n")[1].Split("\n"))
            AddRange(soil2FertilizerRange, soil2Fertilizer);
        mappingRange.Add(soil2FertilizerRange);

        List<(MapRange, MapRange)> fertilizer2WaterRange = new();
        foreach (var fertilizer2Water in groups[3].Split("fertilizer-to-water map:\n")[1].Split("\n"))
            AddRange(fertilizer2WaterRange, fertilizer2Water);
        mappingRange.Add(fertilizer2WaterRange);

        List<(MapRange, MapRange)> water2LightRange = new();
        foreach (var water2Light in groups[4].Split("water-to-light map:\n")[1].Split("\n"))
            AddRange(water2LightRange, water2Light);
        mappingRange.Add(water2LightRange);

        List<(MapRange, MapRange)> light2TemperatureRange = new();
        foreach (var light2Temperature in groups[5].Split("light-to-temperature map:\n")[1].Split("\n"))
            AddRange(light2TemperatureRange, light2Temperature);
        mappingRange.Add(light2TemperatureRange);

        List<(MapRange, MapRange)> temperature2HumidityRange = new();
        foreach (var temperature2Humidity in groups[6].Split("temperature-to-humidity map:\n")[1].Split("\n"))
            AddRange(temperature2HumidityRange, temperature2Humidity);
        mappingRange.Add(temperature2HumidityRange);

        List<(MapRange, MapRange)> humidity2LocationRange = new();
        foreach (var humidity2Location in groups[7].Split("humidity-to-location map:\n")[1].Split("\n"))
            AddRange(humidity2LocationRange, humidity2Location);
        mappingRange.Add(humidity2LocationRange);
    }
    void AddRange(List<(MapRange, MapRange)> currentRange, string range)
    {
        // (destinationStart to destinationEnd) | (sourceStart to sourceEnd)
        string[] split = range.Split(' ');
        (MapRange, MapRange) map = new();
        long destinationStart = long.Parse(split[0]);
        long sourceStart = long.Parse(split[1]);
        long rangeLength = long.Parse(split[2]);
        map.Item1 = new MapRange(destinationStart, destinationStart + rangeLength);
        map.Item2 = new MapRange(sourceStart, sourceStart + rangeLength);
        currentRange.Add(map);
    }
    public void PartOne()
    {
        List<long> seed = new();
        seed.AddRange(seeds);
        for (int i = 0; i < seed.Count; i++)
        {
            foreach (var process in mappingRange)
            {
                foreach (var range in process)
                {
                    if (seed[i] >= range.Item2.start && seed[i] < range.Item2.end)
                    {
                        // In range, apply offset and go to next process
                        long offset = range.Item1.start - range.Item2.start;
                        seed[i] += offset;
                        break;
                    }
                }
            }
        }
        //foreach (var item in seed)
        //    Console.WriteLine(item);
        Console.WriteLine("Min: " + seed.Min());
    }

    public void PartTwo()
    {
        List<long> seed = new();
        for (int i = 0; i < seedPair.Count; i++)
        {
            for (long j = 0; j < seedPair[i].end; j++)
                seed.Add(seedPair[i].start + j);
        }

        for (int i = 0; i < seed.Count; i++)
        {
            foreach (var process in mappingRange)
            {
                foreach (var range in process)
                {
                    if (seed[i] >= range.Item2.start && seed[i] < range.Item2.end)
                    {
                        // In range, apply offset and go to next process
                        long offset = range.Item1.start - range.Item2.start;
                        seed[i] += offset;
                        break;
                    }
                }
            }
        }
        Console.WriteLine($"Min: {seed.Min()}");
    }
}