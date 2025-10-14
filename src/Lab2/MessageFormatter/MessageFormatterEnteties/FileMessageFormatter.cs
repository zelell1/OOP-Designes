using Itmo.ObjectOrientedProgramming.Lab2.Messages;
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

    public void FormatMessageHeader(Message message)
    {
        File.AppendAllText(_filePath.Value, _textFormatter.FormatHeader(message).Value);
    }

    public void FormatMessageBody(Message message)
    {
        File.AppendAllText(_filePath.Value, _textFormatter.FormatBody(message).Value);
    }
}