using Itmo.ObjectOrientedProgramming.Lab2.TextFomatter;

namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter.MessageFormatterEnteties;

public class MessageAndMarkingFormatter : IMessageFormatter
{
    private readonly ITextFormatter _textFormatter;

    private readonly IMessageFormatter _messageFormatter;

    public MessageAndMarkingFormatter(ITextFormatter textFormatter, IMessageFormatter messageFormatter)
    {
        _textFormatter = textFormatter;
        _messageFormatter = messageFormatter;
    }

    public void FormatMessageHeader(string message)
    {
        string formattedMessage = _textFormatter.FormatHeader(message);
        _messageFormatter.FormatMessageHeader(formattedMessage);
    }

    public void FormatMessageBody(string message)
    {
        string formattedMessage = _textFormatter.FormatBody(message);
        _messageFormatter.FormatMessageBody(formattedMessage);
    }
}