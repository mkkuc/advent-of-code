List<string> data = File.ReadAllLines("5.txt").ToList();

string result = string.Empty;
bool isFirstStepLoad = false;
bool isFirstLine = true;
List<string> positions = new();
int size = 0;

foreach (string line in data)
{
    int iterator = 0;
    if (line.Equals(string.Empty))
    {
        continue;
    }
    if (isFirstLine)
    {
        int length = line.Length;
        while (length > 0)
        {
            size++;
            length -= 4;
        }

        isFirstLine = false;

        for (int i = 0; i < size; i++)
        {
            positions.Add(string.Empty);
        }
    }
    if (isFirstStepLoad)
    {
        string[] split = line.Split(' ');
        int move = int.Parse(split[1]);
        int from = int.Parse(split[3]) - 1;
        int to = int.Parse(split[5]) - 1;

        string candidateToMove = positions[from].Substring(0, move);
        positions[to] = candidateToMove + positions[to];
        positions[from] = positions[from].Substring(move, positions[from].Length - move);
    }
    else
    {
        for (int i = 1; i < line.Length; i += 4)
        {
            if (line[i] == ' ')
            {
                iterator++;
                continue;
            }
            if (int.TryParse(line[i].ToString(), out _))
            {
                isFirstStepLoad = true;
                break;
            }
            
            positions[iterator] += line[i];
            iterator++;
        }
    }
}

for (int i = 0; i < size; i++)
{
    Console.Write(positions[i][0]);
}
