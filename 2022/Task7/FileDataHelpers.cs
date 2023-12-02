internal static class FileDataHelpers
{
    internal static long CountSize(this FileData fileData, List<FileData> files)
    {
        if (fileData.Type.Equals(Type.File))
        {
            return fileData.Size;
        }

        long result = 0;
        foreach (string fileName in fileData.FileNames)
        {
            FileData file = files.Find(f => f.Name == fileName);

            if (file.Type.Equals(Type.Directory))
            {
                result += file.CountSize(files);
            }
            result += file.Size;
        }

        return result;
    }
}