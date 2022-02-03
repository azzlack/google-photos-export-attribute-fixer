using System.Drawing;
using CommandLine;
using GooglePhotos.AttributeFixer.App;

var supportedFileTypes = new[] { ".jpg", ".jpeg", ".png", ".mp4", ".gif", ".mov", ".heic" };

var pathParser = new PathParser();
var fileProcessor = new FileProcessor();

Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(o =>
    {
        var path = pathParser.GetFullPath(o.Folder);
        if (Directory.Exists(path))
        {
            var success = 0;
            var fail = 0;
            var unsupported = 0;
            
            var filePaths = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            
            Console.WriteLine($"Processing {filePaths.Length} files");
            
            foreach (var filePath in filePaths)
            {
                var extension = Path.GetExtension(filePath);
                if (supportedFileTypes.Contains(extension.ToLower()))
                {
                    try
                    {
                        var file = new FileInfo(filePath);
                        var result = fileProcessor.Process(file, o.Verbose);

                        if (result)
                        {
                            success++;
                        }
                        else
                        {
                            fail++;
                        }
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        Console.WriteLine($"The tool does not have permission to edit {filePath}", Color.Red);

                        fail++;
                    }
                    catch (DirectoryNotFoundException e)
                    {
                        Console.WriteLine(e.Message, Color.Red);

                        fail++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message, Color.Red);

                        fail++;
                    }
                }
                else
                {
                    unsupported++;
                    
                    if (o.Verbose)
                    {
                        Console.WriteLine($"{extension} is not a supported file type", Color.Gray);
                    }
                }
            }
            
            Console.WriteLine($"Success: {success}, Fail: {fail}, Unsupported: {unsupported}");
        }
        else
        {
            Console.WriteLine($"Could not find the path {path}", Color.Red);
        }
    });