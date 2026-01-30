namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.ResultTypes;

public abstract record ChangeStateResult
{
    private ChangeStateResult() { }

    public sealed record Success() : ChangeStateResult { }

    public sealed record Failure(string Error) : ChangeStateResult { }
}