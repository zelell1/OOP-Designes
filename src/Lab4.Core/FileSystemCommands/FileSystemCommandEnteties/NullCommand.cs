using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class NullCommand : IFileSystemCommand
{
    public FileSystemCommandResult Run(FileSystemSession session)
    {
        return new FileSystemCommandResult.Success(string.Empty);
    }
}