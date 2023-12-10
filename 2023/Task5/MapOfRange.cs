namespace Task5;

public class MapOfRange
{
    public MapOfRange(long destinationStart, long sourceStart, long length)
    {
        DestinationStart = destinationStart;
        SourceStart = sourceStart;
        Length = length;
    }

    public long DestinationStart { get; set; } 
    public long SourceStart { get; set; }
    public long Length { get; set; }

    public bool IsInSourceRange(long value) =>
        value >= SourceStart &&
        value <= (SourceStart + Length - 1);

    public long MapSource(long value) =>
        DestinationStart + (value - SourceStart);

    public ItemRange Transform(ItemRange intersection) =>
        new (MapSource(intersection.Start), intersection.Length);
}
