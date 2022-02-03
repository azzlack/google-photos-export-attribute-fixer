using System.Text.Json;
using ExifLibrary;
using Color = System.Drawing.Color;

namespace GooglePhotos.AttributeFixer.App;

public class FileProcessor
{
    public bool Process(FileInfo file, bool verbose)
    {
        var companionFilePath = $"{file.FullName}.json";
        if (File.Exists(companionFilePath))
        {
            using (var companionFileContent = File.OpenRead(companionFilePath))
            {
                var companionFile = JsonSerializer.Deserialize<GoogleFileInfo>(companionFileContent);
                if (companionFile != null)
                {
                    var photoTaken = DateTimeOffset.FromUnixTimeSeconds(long.Parse(companionFile.photoTakenTime.timestamp));
                    
                    // Set correct file creation timestamp
                    file.CreationTimeUtc = photoTaken.UtcDateTime;
                }
            }

            if (verbose)
            {
                Console.WriteLine($"Processed {file.FullName}", Color.Green);
            }

            return true;
        }

        if (verbose)
        {
            Console.WriteLine($"File {file.FullName} does not have a companion json file. Cannot fix attributes.", Color.Red);   
        }

        return false;
    }
}