namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;

public abstract record BuildCommandResult
{
    private BuildCommandResult() { }

    public sealed record Success(IFileSystemCommand Command) : BuildCommandResult { }

    public sealed record Failure(string Error) : BuildCommandResult { }
}