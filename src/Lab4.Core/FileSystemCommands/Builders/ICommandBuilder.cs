using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface ICommandBuilder
{
    BuildCommandResult Build();
}