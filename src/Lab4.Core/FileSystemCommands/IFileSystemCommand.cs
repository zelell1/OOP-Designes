using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands;

public interface IFileSystemCommand
{
    FileSystemCommandResult Run(FileSystemSession session);
}