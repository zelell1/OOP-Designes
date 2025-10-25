using Itmo.ObjectOrientedProgramming.Lab2.TextFomatter;
using Itmo.ObjectOrientedProgramming.Lab2.TextFomatter.TextFormatterEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter.MessageFormatterEnteties;

public class ConsoleMessageFormatter : IMessageFormatter
{
    private readonly ITextFormatter _textFormatter;

    public ConsoleMessageFormatter()
    {
        _textFormatter = new MdFormatter();
    }

    public ConsoleMessageFormatter(ITextFormatter textFormatter)
    {
        _textFormatter = textFormatter;
    }

    public void FormatMessageHeader(string message)
    {
        Console.WriteLine(_textFormatter.FormatHeader(message));
    }

    public void FormatMessageBody(string message)
    {
        Console.WriteLine(_textFormatter.FormatBody(message));
    }
}