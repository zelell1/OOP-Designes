namespace Itmo.ObjectOrientedProgramming.Lab2.Messages.MessageStatuses;

public abstract record MessageStatus
{
    private MessageStatus() { }

    public sealed record Read : MessageStatus;

    public sealed record NotRead : MessageStatus;
}
