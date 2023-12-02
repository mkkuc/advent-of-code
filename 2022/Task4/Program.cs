List<string> data = File.ReadAllLines("4.txt").ToList();

int result = 0;

foreach (string line in data)
{
    string[] ranges = line.Split(',');
    string startRange = ranges[0];
    string endRange = ranges[1];

    int start1 = int.Parse(startRange.Split('-')[0]);
    int start2 = int.Parse(startRange.Split('-')[1]);

    int end1 = int.Parse(endRange.Split('-')[0]);
    int end2 = int.Parse(endRange.Split('-')[1]);

    if (start1 >= end1 && start1 <= end2)
    {
        result++;
    }
    else if (start2 >= end1 && start2 <= end2)
    {
        result++;
    }
    else if (end1 >= start1 && end1 <= start2 )
    {
        result++;
    }
    else if (end2 >= start1 && end2 <= start2)
    {
        result++;
    }
}

Console.WriteLine(result);