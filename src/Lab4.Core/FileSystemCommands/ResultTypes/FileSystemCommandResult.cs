namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;

public abstract record FileSystemCommandResult
{
    private FileSystemCommandResult() { }

    public sealed record Success(string Text) : FileSystemCommandResult { }

    public sealed record Failure(string Error) : FileSystemCommandResult { }
}