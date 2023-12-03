List<string> input = File.ReadAllLines("3.txt").ToList();
int result = 0;

for (int row = 0; row < input.Count; row++)
{
    string line = input[row];
    int lastColumn = line.Length - 1;
    string number = string.Empty;
    for (int column = 0; column < line.Length; column++)
    {
        string character = line[column].ToString();

        if (character.Equals("*"))
        {
            List<Number> numbersToMultiplying = FindNumbersToMultiplying(row, column, lastColumn);
            if (numbersToMultiplying.Count == 2)
            {
                Console.WriteLine($"{row + 1}: {numbersToMultiplying[0].ToString()} {numbersToMultiplying[1].ToString()}");
                result += (numbersToMultiplying[0].Value * numbersToMultiplying[1].Value);
            }
        }
    }
}

Console.WriteLine(result);

List<Number> FindNumbersToMultiplying(int row, int column, int lastColumn)
{
    List<Number> numbers = new List<Number>();
    if (row > 0 && column < lastColumn)
    {
        if (int.TryParse(input[row - 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row - 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row - 1][column + 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column + 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row][column + 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column + 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row + 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row + 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row + 1][column + 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column + 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
    }
    else if (row == 0 && column < lastColumn)
    {
        if (int.TryParse(input[row][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row][column + 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column + 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row + 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row + 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row + 1][column + 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column + 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
    }
    else if (row == input.Count - 1 && column < lastColumn)
    {
        if (int.TryParse(input[row - 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row - 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row - 1][column + 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column + 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row][column + 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column + 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
    }
    else if (row > 0 && column == lastColumn)
    {
        if (int.TryParse(input[row - 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row - 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row + 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row + 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
    }
    else if (row == 0 && column == lastColumn)
    {
        if (int.TryParse(input[row][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row + 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row + 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row + 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
    }
    else if (row == input.Count - 1 && column == lastColumn)
    {
        if (int.TryParse(input[row - 1][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
        if (int.TryParse(input[row - 1][column].ToString(), out _))
        {
            Number tempNumber = GetNumber(row - 1, column);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }

        if (int.TryParse(input[row][column - 1].ToString(), out _))
        {
            Number tempNumber = GetNumber(row, column - 1);
            if (!numbers.Exists(n => n.Value == tempNumber.Value && n.X == tempNumber.X && n.Y == tempNumber.Y))
            {
                numbers.Add(tempNumber);
            }
        }
    }

    return numbers;
}

Number GetNumber(int x, int y)
{
    string line = input[x];
    string number = string.Empty;
    int startPosition = y;

    if (startPosition == 0)
    {
        while (int.TryParse(line[y].ToString(), out _))
        {
            number += line[y];
            y++;
        }
        return new Number(int.Parse(number), x, startPosition);
    }

    while (y > 0 && int.TryParse(line[y].ToString(), out _))
    {
        y--;
    }

    if (y == 0 && int.TryParse(line[y].ToString(), out _))
    {
        startPosition = y;
    }
    else
    {
        y++;
        startPosition = y;
    }
    
    while (y < line.Length && int.TryParse(line[y].ToString(), out _))
    {
        number += line[y];
        y++;
    }
    return new Number(int.Parse(number), x, startPosition);
}

record Number(int Value, int X, int Y)
{
    public override string ToString()
    {
        return $"{Value} {X} {Y}";
    }
}
