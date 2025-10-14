using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message
{
    public Header Header { get; }

    public Body Body { get; }

    public ImportanceLevel Importance { get; }

    public Message(Header header, Body body, ImportanceLevel importanceLevel)
    {
        Header = header;
        Body = body;
        Importance = importanceLevel;
    }

    public string GetMessageString()
    {
        return $"[{Importance}] {Header.Value}: {Body.Value}";
    }
}