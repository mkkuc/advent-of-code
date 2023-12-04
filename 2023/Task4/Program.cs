List<string> input = File.ReadAllLines("4.txt").ToList();
int result = 0;
var quantityOfCards = input.Count;

Dictionary<int, int> cardInstances = new();

for (int i = 0; i < quantityOfCards; i++)
{
    cardInstances.Add(i, 1);
}

Dictionary<int, List<int>> quantityOfWinningCard = new();

for (int i = 0; i < quantityOfCards; i++)
{
    quantityOfWinningCard.Add(i, new());
}

foreach (string line in input)
{
    string[] gameSplitted = line.Split(": ");
    int currentCart = GetCardNumber(gameSplitted[0]);
    string[] splittedCards = gameSplitted[1].Split("| ");
    List<int> winningCards = GetNumbers(splittedCards[0]);
    List<int> myCards = GetNumbers(splittedCards[1]);
    var cardNumber = currentCart + 1;
    for (int i = 0; i < myCards.Count; i++)
    {
        int item = myCards[i];
        if (winningCards.Exists(card => card == item))
        {
            quantityOfWinningCard[currentCart].Add(cardNumber);
            cardNumber++;
        }
    }
}

foreach (var item in cardInstances)
{
    for (int i = 0; i < item.Value; i++)
    {
        var list = quantityOfWinningCard[item.Key];
        foreach (var item1 in list)
        {
            cardInstances[item1]++;
        }
    }
}

foreach (var item in cardInstances)
{
    result += item.Value;
}

Console.WriteLine(result);



static int GetCardNumber(string cardNumber)
{
    var number = cardNumber.Split("Card ")[1].ToString();
    return int.Parse(number) - 1;
}

static List<int> GetNumbers(string cards)
{
    List<int> result = new();
    string number = string.Empty;

    for (int i = 0; i < cards.Length; i++)
    {
        string character = cards[i].ToString();
        if (int.TryParse(character, out _))
        {
            number += character;
        }
        else if (character.Equals(" ") && !number.Equals(string.Empty))
        {
            result.Add(int.Parse(number));
            number = string.Empty;
        }
    }

    if (!number.Equals(string.Empty))
    {
        result.Add(int.Parse(number));
    }

    return result;
}