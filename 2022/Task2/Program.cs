List<string> data = File.ReadAllLines("2.txt").ToList();

// ROCK         A X
// PAPER        B Y
// SCISSORS     C Z
Dictionary<string, int> gameRules = new()
{
    { "A X", 4 },
    { "A Y", 8 },
    { "A Z", 3 },
    { "B X", 1 },
    { "B Y", 5 },
    { "B Z", 9 },
    { "C X", 7 },
    { "C Y", 2 },
    { "C Z", 6 },
};

int result = 0;

foreach (var item in data)
{
    result += gameRules.GetValueOrDefault(item);
}

Console.WriteLine(result);