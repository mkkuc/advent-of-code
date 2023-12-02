List<string> input = File.ReadAllLines("1.txt").ToList();

int result = 0;

List<string> numbersWords = new List<string>
{
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine",
};

Dictionary<string, int> numbersDictionary = new Dictionary<string, int>
{
    { "one", 1 },
    { "two", 2 },
    { "three", 3},
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 }
};

foreach (string line in input)
{
    string firstSide = string.Empty;
    int firstPosition = int.MaxValue;

    string firstWord = string.Empty;
    int firstWordPosition = int.MaxValue;

    string endSide = string.Empty;
    int endPosition = int.MinValue;

    string endWord = string.Empty;
    int endWordPosition = int.MinValue;

    for (int i = 0; i < line.Length; i++)
    {
        char character = line[i];
        if (!int.TryParse(character.ToString(), out _))
        {
            continue;
        }

        firstSide = character.ToString();
        firstPosition = i;
        break;
    }

    numbersWords.ForEach(word =>
    {
        for (int i = 0; i < line.Length - word.Length; i++)
        {
            var partOfLine = line.Substring(i, word.Length);
            
            if (partOfLine != null && partOfLine.Equals(word))
            {       
                if (firstWordPosition > i)
                {
                    firstWordPosition = i;
                    firstWord = word;
                }

                break;
            }
        }
    });

    for (int i = line.Length - 1; i >= 0; i--)
    {
        char character = line[i];
        if (!int.TryParse(character.ToString(), out _))
        {
            continue;
        }

        endSide = character.ToString();
        endPosition = i;
        break;
    }

    numbersWords.ForEach(word =>
    {
        for (int i = line.Length - word.Length; i >= 0; i--)
        {
            var partOfLine = line.Substring(i, word.Length);

            if (partOfLine != null && partOfLine.Equals(word))
            {
                if (endWordPosition < i)
                {
                    endWordPosition = i;
                    endWord = word;
                }  
                
                break;
            }
        }
    });

    var first = string.Empty;
    var end = string.Empty;

    var isFirst = firstPosition != int.MaxValue;
    var isFirstWord = firstWordPosition != int.MaxValue;

    if (isFirst && isFirstWord)
    {
        first = firstPosition > firstWordPosition
            ? numbersDictionary.GetValueOrDefault(firstWord).ToString()
            : firstSide;
    }
    else if (isFirst)
    {
        first = firstSide;
    }
    else if (isFirstWord)
    {
        first = numbersDictionary.GetValueOrDefault(firstWord).ToString();
    }

    var isEnd = endPosition != int.MinValue;
    var isEndWord = endWordPosition != int.MinValue;


    if (isEnd && isEndWord)
    {
        end = endPosition < endWordPosition
            ? numbersDictionary.GetValueOrDefault(endWord).ToString()
            : endSide;
    }
    else if (isEnd)
    {
        end = endSide;
    }
    else if (isEndWord)
    {
        end = numbersDictionary.GetValueOrDefault(endWord).ToString();
    }

    string final = first + end;

    result += int.Parse((final).ToString());
}

Console.WriteLine(result);
Console.ReadKey();