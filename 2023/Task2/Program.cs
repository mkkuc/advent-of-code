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
    bool isPossible = true;

    foreach (string set in sets)
    {
        if (!isPossible)
        {
            break;
        }

        string[] splitCubes = set.Split(", ");

        foreach (string cubes in splitCubes)
        {
            string[] cube = cubes.Split(" ");
            int number = int.Parse(cube[0]);
            string color = cube[1];

            if (dictionary.GetValueOrDefault(color) < number)
            {
                isPossible = false;
                break;
            }
        }
    }

    if (isPossible)
    {
        result += gameId;
        isPossible = true;
    } 
}

Console.WriteLine(result);