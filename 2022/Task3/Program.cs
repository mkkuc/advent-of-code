List<string> data = File.ReadAllLines("3.txt").ToList();

int result = 0;
for (int j = 0; j < data.Count; j += 3)
{
    string line1 = data[j];
    string line2 = data[j + 1];
    string line3 = data[j + 2];

    var firstDictionary = new Dictionary<char, int>();
    var secondDictionary = new Dictionary<char, int>();
    var thirdDictionary = new Dictionary<char, int>();

    for (int i = 0; i < line1.Length; i++)
    {
        char character = line1[i];
        if (firstDictionary.ContainsKey(character))
        {
            continue;
        }

        firstDictionary.Add(character, 1);
    }

    for (int i = 0; i < line2.Length; i++)
    {
        char character = line2[i];
        if (secondDictionary.ContainsKey(character))
        {
            continue;
        }

        secondDictionary.Add(character, 1);
    }

    for (int i = 0; i < line3.Length; i++)
    {
        char character = line3[i];
        if (thirdDictionary.ContainsKey(character))
        {
            continue;
        }

        thirdDictionary.Add(character, 1);
    }

    var commonFirstAndSecond = new Dictionary<char, int>();
    foreach (var item in firstDictionary)
    {
        if (secondDictionary.TryGetValue(item.Key, out _))
        {
            commonFirstAndSecond.Add(item.Key, item.Value);
        }
    }

    var commonSecondAndThird = new Dictionary<char, int>();
    foreach (var item in secondDictionary)
    {
        if (thirdDictionary.TryGetValue(item.Key, out _))
        {
            commonSecondAndThird.Add(item.Key, item.Value);
        }
    }

    foreach (var item in commonFirstAndSecond)
    {
        if (commonSecondAndThird.TryGetValue(item.Key, out _))
        {
            char character = item.Key;
            
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