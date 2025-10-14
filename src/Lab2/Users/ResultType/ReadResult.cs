namespace Itmo.ObjectOrientedProgramming.Lab2.Users.ResultType;

public abstract record ReadResult
{
    private ReadResult() { }

    public sealed record WasRead : ReadResult;

    public sealed record AlreadyRead : ReadResult;

    public sealed record NotFound : ReadResult;
}