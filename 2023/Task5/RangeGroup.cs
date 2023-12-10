namespace Task5;

public class RangeGroup
{
    private readonly MapOfRange[] _maps;

    public RangeGroup(MapOfRange[] maps)
    {
        _maps = maps.OrderBy(s => s.SourceStart).ToArray();
    }

    public ItemRange[] Map(ItemRange range)
    {
        List<ItemRange> results = new();

        ItemRange remainingRange = range;

        foreach (MapOfRange map in _maps)
        {
            if (remainingRange.Start < map.SourceStart)
            {
                long cutOffLength = Math.Min(
                    remainingRange.Length,
                    map.SourceStart - remainingRange.Start);

                ItemRange cutOff = new (remainingRange.Start, cutOffLength);
                results.Add(cutOff);

                remainingRange = new ItemRange(
                    remainingRange.Start + cutOffLength,
                    remainingRange.Length - cutOffLength);
            }

            if (remainingRange.Length <= 0)
            {
                break;
            }

            if (remainingRange.Start >= map.SourceStart &&
                remainingRange.Start < (map.SourceStart + map.Length))
            {
                long intersectionLength = Math.Min(
                    remainingRange.Length,
                    map.SourceStart + map.Length - remainingRange.Start);

                ItemRange intersection = new ItemRange(remainingRange.Start, intersectionLength);
                ItemRange transformedRange = map.Transform(intersection);
                results.Add(transformedRange);

                remainingRange = new ItemRange(
                    remainingRange.Start + intersectionLength,
                    remainingRange.Length - intersectionLength);
            }

            if (remainingRange.Length <= 0)
            {
                break;
            }
        }

        if (remainingRange.Length > 0)
        {
            results.Add(remainingRange);
        }

        return results.ToArray();
    }
}
