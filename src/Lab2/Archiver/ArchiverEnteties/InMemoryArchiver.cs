using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archiver.ArchiverEnteties;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages;

    public InMemoryArchiver()
    {
        _messages = new List<Message>();
    }

    public void Archive(Message message)
    {
        _messages.Add(message);
    }
}