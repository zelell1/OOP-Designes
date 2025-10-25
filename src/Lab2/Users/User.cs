using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Messages.MessageStatuses;
using Itmo.ObjectOrientedProgramming.Lab2.Users.ResultType;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    private readonly Dictionary<Message, MessageStatus> _userMessages;

    public User()
    {
        _userMessages = new Dictionary<Message, MessageStatus>();
    }

    public void GetMessage(Message message)
    {
        _userMessages.TryAdd(message, new MessageStatus.NotRead());
    }

    public MessageStatus CheckStatus(Message message)
    {
        return _userMessages[message];
    }

    public ReadResult ReadMessage(Message message)
    {
        if (!_userMessages.ContainsKey(message))
        {
            return new ReadResult.NotFound();
        }

        if (!_userMessages.TryGetValue(message, out MessageStatus? value) || value is not MessageStatus.NotRead)
        {
            return new ReadResult.AlreadyRead();
        }

        _userMessages[message] = new MessageStatus.Read();

        return new ReadResult.WasRead();
    }
}