


List<string> input = File.ReadAllLines("5.txt").ToList();

long[] seeds;
long[,] seedsToSoil;
long[,] soilToFertilizer;
long[,] fertilizerToWater;
long[,] waterToLight;
long[,] lightToTemperature;
long[,] temperatureToHumidity;
long[,] humidityToLocation;

long result = long.MaxValue;

seeds = GetSeeds(input);

seedsToSoil = GetAlfaToOmega(input);
soilToFertilizer = GetAlfaToOmega(input);
fertilizerToWater = GetAlfaToOmega(input);
waterToLight = GetAlfaToOmega(input);
lightToTemperature = GetAlfaToOmega(input);
temperatureToHumidity = GetAlfaToOmega(input);
humidityToLocation = GetAlfaToOmega(input);

foreach(var seed in seeds)
{
    result = long.Min(result, CheckSeed(seed));
}

Console.WriteLine(result);

long CheckSeed(long seed)
{
    long destinationValue = GetDestinationValue(seed, seedsToSoil);
    destinationValue = GetDestinationValue(destinationValue, soilToFertilizer);
    destinationValue = GetDestinationValue(destinationValue, fertilizerToWater);
    destinationValue = GetDestinationValue(destinationValue, waterToLight);
    destinationValue = GetDestinationValue(destinationValue, lightToTemperature);
    destinationValue = GetDestinationValue(destinationValue, temperatureToHumidity);
    destinationValue = GetDestinationValue(destinationValue, humidityToLocation);

    return destinationValue;
}

long GetDestinationValue(long seed, long[,] array2D)
{
    long numRows = array2D.GetLength(0);
    long numCols = array2D.GetLength(1);

    for (long i = 0; i < numRows; i++)
    {
        var destination = array2D[i,0];
        var source = array2D[i, 1];
        var length = array2D[i, 2];

        if (seed >= source && seed <= source + length - 1)
        {
            var diff = destination - source;
            var value = seed + diff;

            return value;
        }
    }

    return seed;
}

long[,] GetAlfaToOmega(List<string> input)
{
    int iterator = 0;
    var result = new List<List<long>>();
    input.RemoveAt(iterator);
    while (input.Count != 0 && input[iterator].Length != 0)
    {
        var splitted = input[iterator].Split(" ");
        var list = new List<long>();
        for (long i = 0; i < splitted.Length; i++)
        {
            list.Add(long.Parse(splitted[i]));
        }
        result.Add(list);
        input.RemoveAt(iterator);
    }
    
    if(input.Count != 0)
    {
        input.RemoveAt(iterator);
    }

    return ConvertListToArray2D(result);
}

long[] GetSeeds(List<string> input)
{
    int iterator = 0;
    var splitted = input[0].Split(" ");
 
    var result = new List<long>();
    for (long i = 1; i < splitted.Length; i++)
    {
        result.Add(long.Parse(splitted[i]));
    }
    input.RemoveAt(iterator);
    input.RemoveAt(iterator);

    return result.ToArray();
}

static long[,] ConvertListToArray2D(List<List<long>> list2D)
{
    long numRows = list2D.Count;
    long numCols = list2D[0].Count;

    long[,] array2D = new long[numRows, numCols];

    for (int i = 0; i < numRows; i++)
    {
        for (int j = 0; j < numCols; j++)
        {
            array2D[i, j] = list2D[i][j];
        }
    }

    return array2D;
}

static void Show1DArray(long[] array1D)
{
    for (long i = 0; i < array1D.Length; i++)
    {
        Console.Write(array1D[i] + " ");
    }
    Console.WriteLine();
    Console.WriteLine();
}

static void Show2DArray(long[,] array2D)
{
    long numRows = array2D.GetLength(0);
    long numCols = array2D.GetLength(1);

    for (long i = 0; i < numRows; i++)
    {
        for (long j = 0; j < numCols; j++)
        {
            Console.Write(array2D[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}