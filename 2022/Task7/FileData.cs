internal class FileData(string name, Type type, long size = 0)
{
    public string Name { get; set; } = name;
    public Type Type { get; set; } = type;
    public long Size { get; set; } = size;
    public List<string> FileNames { get; set; } = new();
}
