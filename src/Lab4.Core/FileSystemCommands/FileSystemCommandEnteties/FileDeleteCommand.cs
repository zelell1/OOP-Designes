using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class FileDeleteCommand : IFileSystemCommand
{
    private readonly string _path;

    private FileDeleteCommand(string path)
    {
        _path = path;
    }

    public static IFileDeleteCommandBuilder Builder => new FileDeleteCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        if (session.FileSystem is StubFileSystem)
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        string newPath = session.FileSystem.CombinePath(session.ConnectionPath, session.CurrentPath, _path);

        if (!session.FileSystem.IsValidPath(session.ConnectionPath, newPath))
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        if (!session.FileSystem.DeleteFile(newPath))
        {
            return new FileSystemCommandResult.Failure("Can't delete");
        }

        return new FileSystemCommandResult.Success("Deleted");
    }

    public interface IFileDeleteCommandBuilder : IPathBuilder<IFileDeleteCommandBuilder> { }

    private class FileDeleteCommandBuilder : IFileDeleteCommandBuilder
    {
        private string _path = string.Empty;

        public IFileDeleteCommandBuilder AddPath(string path)
        {
            _path = path;
            return this;
        }

        public BuildCommandResult Build()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return new BuildCommandResult.Failure("No path");
            }

            return new BuildCommandResult.Success(new FileDeleteCommand(_path));
        }
    }
}