List<string> data = File.ReadAllLines("2.txt").ToList();

// ROCK         A X
// PAPER        B Y
// SCISSORS     C Z


// LOSE     X
// DRAW     Y
// WIN      Z
Dictionary<string, int> gameRules = new()
{
    { "A X", 3 },
    { "A Y", 4 },
    { "A Z", 8 },
    { "B X", 1 },
    { "B Y", 5 },
    { "B Z", 9 },
    { "C X", 2 },
    { "C Y", 6 },
    { "C Z", 7 },
};

int result = 0;

foreach (var item in data)
{
    result += gameRules.GetValueOrDefault(item);
}

Console.WriteLine(result);