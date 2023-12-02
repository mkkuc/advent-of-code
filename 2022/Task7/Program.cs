List<string> data = File.ReadAllLines("7.txt").ToList();
List<FileData> files = new();
List<string> history = new();

foreach (var line in data)
{
    var splitted = line.Split(" ");
    for (int i = 0; i < splitted.Length; i++)
    {
        string? split = splitted[i];
        if (split.Equals("$"))
        {
            continue;
        }
        if (split.Equals("cd"))
        {
            var fileName = splitted[i + 1];
            if (!fileName.Equals(".."))
            {
                var file = new FileData(fileName, Type.Directory);

                if (!files.Exists(f => f.Name == file.Name))
                {
                    files.Add(file);
                }

                string directory = history.Last();

                files.Find(f => f.Name.Equals(directory)).FileNames.Add(fileName);
                
                history.Add(fileName);
            }
            else
            {
                history.RemoveAt(history.Count - 1);
            }
            break;
        }
        if (split.Equals("ls"))
        {
            continue;
        }
        if (split.Equals("dir"))
        {
            var fileName = splitted[i + 1];      
            var file = new FileData(fileName, Type.Directory);

            if (!files.Exists(f => f.Name == file.Name))
            {
                files.Add(file);
            }

            string directory = history.Last();

            files.Find(f => f.Name.Equals(directory)).FileNames.Add(fileName);

        }
    }
}