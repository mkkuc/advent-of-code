List<string> data = File.ReadAllLines("1.txt").ToList();

int maximum = 0;
int tempMax = 0;
string lastItem = string.Empty;

foreach (string item in data)
{
    if (item.Equals(string.Empty))
    {
        maximum = maximum < tempMax ? tempMax : maximum;
        tempMax = 0;
        continue;
    }

    tempMax += int.Parse(item);
    lastItem = item;
}

tempMax += int.Parse(lastItem);
maximum = maximum < tempMax ? tempMax : maximum;

Console.WriteLine(maximum);
Console.Read();