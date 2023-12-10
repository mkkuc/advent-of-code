using Task5;

using FileStream inputStream = File.OpenRead("5.txt");
using StreamReader reader = new(inputStream);

string seedsLine = reader.ReadLine()!.Split("seeds:")[1];
long[] seedPairs = seedsLine.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(long.Parse)
    .ToArray();

reader.ReadLine();

List<RangeGroup> mapGroups = new();
CreateRanges();

List<ItemRange> seeds = new();
CreateSeedPairs();

List<ItemRange> seedRanges = seeds;
foreach (RangeGroup group in mapGroups)
{
    List<ItemRange> newSeedRanges = new();

    foreach (ItemRange seedRange in seedRanges)
    {
        ItemRange[] mappedRanges = group.Map(seedRange);
        newSeedRanges.AddRange(mappedRanges);
    }

    seedRanges = newSeedRanges;
}

var result = seedRanges.Select(s => s.Start).Min();
Console.WriteLine(result);

void CreateRanges()
{
    for (long i = 0; i < 7; i++)
    {
        reader.ReadLine();

        List<MapOfRange> maps = new();
        string? line = reader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
            long[] parts = line.Split(' ').Select(long.Parse).ToArray();
            maps.Add(new MapOfRange(parts[0], parts[1], parts[2]));
            line = reader.ReadLine();
        }

        RangeGroup seedRangeGroup = new(maps.ToArray());
        mapGroups.Add(seedRangeGroup);
    }
}
void CreateSeedPairs()
{
    for (int i = 0; i < seedPairs.Length / 2; i++)
    {
        long startingSeed = seedPairs[i * 2];
        long length = seedPairs[i * 2 + 1];
        seeds.Add(new(startingSeed, length));
    }
}
