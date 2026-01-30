namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter;

public interface IMessageFormatter
{
    void FormatMessageHeader(string message);

    void FormatMessageBody(string message);
}