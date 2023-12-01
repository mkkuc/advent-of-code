Console.WriteLine("Hello, World!");
List<string> data = File.ReadAllLines("3.txt").ToList();

int result = 0;
foreach (string line in data)
{
    var firstHalf = line.Substring(0, line.Length / 2);
    var secondHalf = line.Substring(line.Length / 2);

    var firstDictionary = new Dictionary<char, int>();

    for (int i = 0; i < firstHalf.Length; i++)
    {
        char character = firstHalf[i];
        if (firstDictionary.ContainsKey(character))
        {
            continue;
        }

        firstDictionary.Add(character, 1);
    }

    for (int i = 0; i < secondHalf.Length; i++)
    {
        char character = secondHalf[i];
        if (firstDictionary.ContainsKey(character))
        {
            if ((int)character >= 97)
            {
                result += (int)character - 96;
            }
            else
            {
                result += (int)character - 38;
            }
            break;
        }
    }
}

Console.WriteLine(result);