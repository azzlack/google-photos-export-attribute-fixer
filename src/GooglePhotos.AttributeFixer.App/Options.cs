using CommandLine;

namespace GooglePhotos.AttributeFixer.App;

public class Options
{
    [Option('f', "folder", Required = true, HelpText = "The path where the images are located. The tool will traverse any subfolders underneath this.")]
    public string Folder { get; set; }
    
    [Option('v', "verbose", Required = false, HelpText = "Print all messages to console")]
    public bool Verbose { get; set; }
}