List<string> data = File.ReadAllLines("6.txt").ToList();

foreach (var line in data)
{
    string pack = string.Empty;

    for (int i = 0; i < line.Length; i++)
    {
        if (!pack.Contains(line[i]))
        {
            pack += line[i];
            if (pack.Length == 14)
            {
                Console.WriteLine(i + 1);
                break;
            }
            continue;
        }
        else
        {
            var indexOfLetterToRemove = pack.IndexOf(line[i]);
            pack = pack.Substring(indexOfLetterToRemove + 1, pack.Length - (indexOfLetterToRemove + 1));
            pack += line[i];
        }
    }
}