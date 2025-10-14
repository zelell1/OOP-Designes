using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

public interface IMessageFormatter
{
    void FormatMessageHeader(Message message);

    void FormatMessageBody(Message message);
}