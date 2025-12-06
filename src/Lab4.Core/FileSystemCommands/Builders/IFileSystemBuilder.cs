using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;

public interface IFileSystemBuilder<T> : ICommandBuilder where T : IFileSystemBuilder<T>
{
    T AddMode(IFileSystem fileSystem);
}