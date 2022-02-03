namespace GooglePhotos.AttributeFixer.App;

public class PathParser
{
    public string GetFullPath(string path)
    {
        if (path.StartsWith("~"))
        {
            return $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}{(path.Length >= 1 ? path.Substring(1) : "")}";
        }

        if (path.StartsWith("."))
        {
            return $"{Directory.GetCurrentDirectory()}{(path.Length >= 1 ? path.Substring(1) : "")}";
        }

        return path;
    }
}