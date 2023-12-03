List<string> input = File.ReadAllLines("3.txt").ToList();
int result = 0;

for (int row = 0; row < input.Count; row++)
{
    string line = input[row];
    int lastColumn = line.Length - 1;
    int start = -1;
    int end = -1;
    string number = string.Empty;
    Console.WriteLine(row + 1);
    for (int column = 0; column < line.Length; column++)
    {
        string character = line[column].ToString();

        if (int.TryParse(character, out _))
        {
            end = column;
            if (number.Equals(string.Empty))
            {
                start = column;
            }
            number += character;
            if (!number.Equals(string.Empty) && column == lastColumn)
            {
                Console.Write($"{number} ");
                if (IsNumberAdjacentToSymbol(start, end, row, lastColumn, number.Length))
                {
                    Console.Write(true);
                    result += int.Parse(number);
                }
                else
                {
                    Console.Write(false);
                }

                Console.WriteLine();
                number = string.Empty;
                start = -1;
                end = -1;
            }
        }
        else if (!number.Equals(string.Empty))
        {
            Console.Write($"{number} ");
            if (IsNumberAdjacentToSymbol(start, end, row, lastColumn, number.Length))
            {
                Console.Write(true);
                result += int.Parse(number);
            }
            else
            {
                Console.Write(false);
            }
            
            Console.WriteLine();
            number = string.Empty;
            start = -1;
            end = -1;
        }
    }
}

Console.WriteLine(result);

bool IsNumberAdjacentToSymbol(int start, int end, int currentRow, int lastColumn, int numberSize)
{
    if (currentRow == 0)
    {
        if (start == 0 && end != lastColumn)
        {
            var checkRight = input[currentRow][end + 1].ToString();
            var checkBottom = input[currentRow + 1].Substring(start, numberSize + 1);

            if (ContainsSymbol(checkRight) || ContainsSymbol(checkBottom))
            {
                return true;
            }
        }
        else if (start != 0 && end == lastColumn)
        {
            var checkLeft = input[currentRow][start - 1].ToString();
            var checkBottom = input[currentRow + 1].Substring(start - 1, numberSize + 1);

            if (ContainsSymbol(checkLeft) || ContainsSymbol(checkBottom))
            {
                return true;
            }
        }
        else if (start != 0 && end != lastColumn)
        {
            var checkLeft = input[currentRow][start - 1].ToString();
            var checkRight = input[currentRow][end + 1].ToString();
            var checkBottom = input[currentRow + 1].Substring(start - 1, numberSize + 2);

            if (ContainsSymbol(checkBottom) 
                || ContainsSymbol(checkLeft) 
                || ContainsSymbol(checkRight))
            {
                return true;
            }
        }
        else if (start == 0 && end == lastColumn)
        {
            var checkBottom = input[currentRow + 1];

            if (ContainsSymbol(checkBottom))
            {
                return true;
            }
        }
    }
    else if (currentRow == input.Count - 1)
    {
        if (start == 0 && end != lastColumn)
        {
            var checkRight = input[currentRow][end + 1].ToString();
            var checkTop = input[currentRow - 1].Substring(start, numberSize + 1);

            if (ContainsSymbol(checkRight) || ContainsSymbol(checkTop))
            {
                return true;
            }
        }
        else if (start != 0 && end == lastColumn)
        {
            var checkLeft = input[currentRow][start - 1].ToString();
            var checkTop = input[currentRow - 1].Substring(start - 1, numberSize + 1);

            if (ContainsSymbol(checkLeft) || ContainsSymbol(checkTop))
            {
                return true;
            }
        }
        else if (start != 0 && end != lastColumn)
        {
            var checkLeft = input[currentRow][start - 1].ToString();
            var checkRight = input[currentRow][end + 1].ToString();
            var checkTop = input[currentRow - 1].Substring(start - 1, numberSize + 2);

            if (ContainsSymbol(checkTop)
                || ContainsSymbol(checkLeft)
                || ContainsSymbol(checkRight))
            {
                return true;
            }
        }
        else if (start == 0 && end == lastColumn)
        {
            var checkTop = input[currentRow - 1];

            if (ContainsSymbol(checkTop))
            {
                return true;
            }
        }
    }
    else
    {
        if (start == 0 && end != lastColumn)
        {
            var checkRight = input[currentRow][end + 1].ToString();
            var checkTop = input[currentRow - 1].Substring(start, numberSize + 1);
            var checkBottom = input[currentRow + 1].Substring(start, numberSize + 1);

            if (ContainsSymbol(checkRight) 
                || ContainsSymbol(checkTop)
                || ContainsSymbol(checkBottom))
            {
                return true;
            }
        }
        else if (start != 0 && end == lastColumn)
        {
            var checkLeft = input[currentRow][start - 1].ToString();
            var checkTop = input[currentRow - 1].Substring(start - 1, numberSize + 1);
            var checkBottom = input[currentRow + 1].Substring(start - 1, numberSize + 1);

            if (ContainsSymbol(checkLeft) 
                || ContainsSymbol(checkTop)
                || ContainsSymbol(checkBottom))
            {
                return true;
            }
        }
        else if (start != 0 && end != lastColumn)
        {
            var checkLeft = input[currentRow][start - 1].ToString();
            var checkRight = input[currentRow][end + 1].ToString();
            var checkTop = input[currentRow - 1].Substring(start - 1, numberSize + 2);
            var checkBottom = input[currentRow + 1].Substring(start - 1, numberSize + 2);

            if (ContainsSymbol(checkTop)
                || ContainsSymbol(checkLeft)
                || ContainsSymbol(checkRight)
                || ContainsSymbol(checkBottom))
            {
                return true;
            }
        }
        else if (start == 0 && end == lastColumn)
        {
            var checkTop = input[currentRow - 1];
            var checkBottom = input[currentRow - 1];

            if (ContainsSymbol(checkTop) || ContainsSymbol(checkBottom))
            {
                return true;
            }
        }
    }

    return false;
}

bool ContainsSymbol(string stringToCheck)
{
    for (int i = 0; i < stringToCheck.Length; i++)
    {
        if (!stringToCheck[i].Equals('.') && !int.TryParse(stringToCheck[i].ToString(), out _))
        {
            return true;
        }
    }

    return false;
}