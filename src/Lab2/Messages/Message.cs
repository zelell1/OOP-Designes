using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message
{
    public string Header { get; }

    public string Body { get; }

    public ImportanceLevel Importance { get; }

    public Message(string header, string body, ImportanceLevel importanceLevel)
    {
        Header = header;
        Body = body;
        Importance = importanceLevel;
    }

    public string GetMessageString()
    {
        return $"[{Importance}] {Header}: {Body}";
    }
}