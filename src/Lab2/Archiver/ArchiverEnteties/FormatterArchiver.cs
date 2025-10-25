using Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver.ArchiverEnteties;

public class FormatterArchiver : IArchiver
{
    private readonly IMessageFormatter _formatter;

    public FormatterArchiver(IMessageFormatter formatter)
    {
        _formatter = formatter;
    }

    public void Archive(Message message)
    {
        _formatter.FormatMessageHeader(message.Header);
        _formatter.FormatMessageBody(message.Body);
    }
}