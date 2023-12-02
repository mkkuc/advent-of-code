List<string> input = File.ReadAllLines("2.txt").ToList();

Dictionary<string, int> dictionary = new()
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 }
};

int result = 0;

foreach (string line in input)
{
    string[] splittedLine = line.Split(':');
    string[] game = splittedLine[0].Split(' ');
    int gameId = int.Parse(game[1]);
    string[] sets = splittedLine[1].Remove(0, 1).Split("; ");

    Dictionary<string, int> gameDictionary = new()
    {
        { "red", 0 },
        { "green", 0 },
        { "blue", 0 }
    };

    foreach (string set in sets)
    {
        string[] splitCubes = set.Split(", ");

        foreach (string cubes in splitCubes)
        {
            string[] cube = cubes.Split(" ");
            int number = int.Parse(cube[0]);
            string color = cube[1];

            int maximum = int.Max(gameDictionary.GetValueOrDefault(color), number);

            gameDictionary.Remove(color);
            gameDictionary.Add(color, maximum);
        }
    }

    var red = gameDictionary["red"];
    var green = gameDictionary["green"];
    var blue = gameDictionary["blue"];

    result += (red * green * blue);
}

Console.WriteLine(result);