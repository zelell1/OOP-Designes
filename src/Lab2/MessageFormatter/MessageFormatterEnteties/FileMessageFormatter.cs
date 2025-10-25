using Itmo.ObjectOrientedProgramming.Lab2.TextFomatter;
using Itmo.ObjectOrientedProgramming.Lab2.TextFomatter.TextFormatterEnteties;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter.MessageFormatterEnteties;

public class FileMessageFormatter : IMessageFormatter
{
    private readonly FilePath _filePath;

    private readonly ITextFormatter _textFormatter;

    public FileMessageFormatter(FilePath filePath, ITextFormatter textFormatter)
    {
        _filePath = filePath;
        _textFormatter = textFormatter;
    }

    public FileMessageFormatter() : this(new FilePath(Path.GetTempFileName()), new MdFormatter()) { }

    public FileMessageFormatter(string filePath) : this(new FilePath(filePath), new MdFormatter()) { }

    public void FormatMessageHeader(string message)
    {
        File.AppendAllText(_filePath.Value, _textFormatter.FormatHeader(message));
    }

    public void FormatMessageBody(string message)
    {
        File.AppendAllText(_filePath.Value, _textFormatter.FormatBody(message));
    }
}