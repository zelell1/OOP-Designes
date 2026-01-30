using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class FileRenameCommand : IFileSystemCommand
{
    private readonly string _path;

    private readonly string _name;

    private FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public static IFileRenameCommandBuilder Builder => new FileRenameCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        if (session.FileSystem is StubFileSystem)
        {
            return new FileSystemCommandResult.Failure("Disconnected");
        }

        string newPath = session.FileSystem.CombinePath(session.ConnectionPath, session.CurrentPath, _path);

        if (!session.FileSystem.IsValidPath(session.ConnectionPath, newPath))
        {
            return new FileSystemCommandResult.Failure("Invalid path");
        }

        if (!session.FileSystem.RenameFile(newPath, _name))
        {
            return new FileSystemCommandResult.Failure("Can't rename");
        }

        return new FileSystemCommandResult.Success("Renamed");
    }

    public interface IFileRenameCommandBuilder : IPathBuilder<IFileRenameCommandBuilder>,
                                                 INameBuilder<IFileRenameCommandBuilder>
    { }

    private class FileRenameCommandBuilder : IFileRenameCommandBuilder
    {
        private string _path = string.Empty;

        private string _name = string.Empty;

        public IFileRenameCommandBuilder AddPath(string path)
        {
            _path = path;
            return this;
        }

        public IFileRenameCommandBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public BuildCommandResult Build()
        {
            if (string.IsNullOrEmpty(_path) || string.IsNullOrEmpty(_name))
            {
                return new BuildCommandResult.Failure("No path or name");
            }

            if (_name.Contains('/', StringComparison.Ordinal) || _name.Contains('\\', StringComparison.Ordinal))
            {
                return new BuildCommandResult.Failure("Invalid name");
            }

            return new BuildCommandResult.Success(new FileRenameCommand(_path, _name));
        }
    }
}