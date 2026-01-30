using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

public abstract record ParseBuildCommandResult
{
    private ParseBuildCommandResult() { }

    public record Success(IFileSystemCommand Command) : ParseBuildCommandResult { }

    public record NotFound : ParseBuildCommandResult { }

    public record Failure(string Error) : ParseBuildCommandResult { }
}