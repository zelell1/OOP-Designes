namespace Itmo.ObjectOrientedProgramming.Lab2.MessageFormatter.MessageFormatterEnteties;

public class ConsoleMessageFormatter : IMessageFormatter
{
    public void FormatMessageHeader(string message)
    {
        Console.WriteLine(message);
    }

    public void FormatMessageBody(string message)
    {
        Console.WriteLine(message);
    }
}