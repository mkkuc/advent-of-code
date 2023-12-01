Console.WriteLine("Hello, World!");
List<string> input = File.ReadAllLines("1.txt").ToList();

int result = 0;

foreach (string line in input)
{
    string firstSide = string.Empty;
    string endSide = string.Empty;

    for (int i = 0; i < line.Length; i++)
    {
        char character = line[i];
        if (!int.TryParse(character.ToString(), out _))
        {
            continue;
        }

        firstSide = character.ToString();
        break;
    }

    for (int i = line.Length - 1; i >= 0; i--)
    {
        char character = line[i];
        if (!int.TryParse(character.ToString(), out _))
        {
            continue;
        }

        endSide = character.ToString();
        break;
    }

    result += int.Parse((firstSide + endSide).ToString());
}

Console.WriteLine(result);
Console.ReadKey();