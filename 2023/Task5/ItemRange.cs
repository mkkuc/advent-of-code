namespace Task5;

public class ItemRange
{
    public ItemRange(long start, long length)
    {
        Start = start;
        Length = length;
    }

    public long Start { get; set; }
    public long Length { get; set; }

    public long End => Start + Length - 1;

}