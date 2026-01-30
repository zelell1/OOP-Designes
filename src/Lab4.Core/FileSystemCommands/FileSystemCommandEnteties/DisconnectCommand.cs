using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class DisconnectCommand : IFileSystemCommand
{
    private DisconnectCommand() { }

    public static ICommandBuilder Builder => new DisconnectCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        ChangeStateResult stateResult = session.Disconnect();

        if (stateResult is ChangeStateResult.Failure result)
        {
            return new FileSystemCommandResult.Failure(result.Error);
        }

        return new FileSystemCommandResult.Success("Disconnected");
    }

    private class DisconnectCommandBuilder : ICommandBuilder
    {
        public BuildCommandResult Build()
        {
            return new BuildCommandResult.Success(new DisconnectCommand());
        }
    }
}