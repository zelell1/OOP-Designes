namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileContentOutput.IFileContentOutputEnteties;

public class FileContentConsoleOutput : IFileContentOutput
{
    public void Show(string? text)
    {
        Console.WriteLine(text);
    }
}