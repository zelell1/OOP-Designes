using Itmo.ObjectOrientedProgramming.Lab2.TextFomatter;
using Itmo.ObjectOrientedProgramming.Lab2.TextFomatter.TextFormatterEnteties;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter.MessageFormatterEnteties;

public class FileMessageFormatter : IMessageFormatter
{
    private readonly FilePath _filePath;

    public FileMessageFormatter(FilePath filePath, ITextFormatter textFormatter)
    {
        _filePath = filePath;
    }

    public FileMessageFormatter() : this(new FilePath(Path.GetTempFileName()), new MdFormatter()) { }

    public FileMessageFormatter(string filePath) : this(new FilePath(filePath), new MdFormatter()) { }

    public void FormatMessageHeader(string message)
    {
        File.AppendAllText(_filePath.Value, message);
    }

    public void FormatMessageBody(string message)
    {
        File.AppendAllText(_filePath.Value, message);
    }
}