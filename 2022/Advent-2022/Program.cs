List<string> data = File.ReadAllLines("1.txt").ToList();

List<int> summary = new();
int tempMax = 0;
string lastItem = string.Empty;

foreach (string item in data)
{
    if (item.Equals(string.Empty))
    {
        summary.Add(tempMax);
        tempMax = 0;
        continue;
    }

    tempMax += int.Parse(item);
    lastItem = item;
}

summary.Add(tempMax);

IOrderedEnumerable<int> orderedResults = summary.OrderDescending();

int results = orderedResults.Take(3).Sum();

Console.WriteLine(results);
Console.Read();