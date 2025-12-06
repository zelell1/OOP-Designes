using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.CategoryBuilders;

public class TreeBuilder : ICommandBuilder
{
    public BuildCommandResult Build()
    {
        return new BuildCommandResult.Success(new NullCommand());
    }
}