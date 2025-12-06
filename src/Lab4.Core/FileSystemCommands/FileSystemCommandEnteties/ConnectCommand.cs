using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class ConnectCommand : IFileSystemCommand
{
    private readonly IFileSystem _fileSystem;

    private readonly string _path;

    private ConnectCommand(IFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        _path = path;
    }

    public static IConnectCommandBuilder Builder => new ConnectCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        if (!Path.Exists(_path) || !Path.IsPathRooted(_path))
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        ChangeStateResult stateResult = session.Connect(_path, _fileSystem);

        if (stateResult is ChangeStateResult.Failure result)
        {
            return new FileSystemCommandResult.Failure(result.Error);
        }

        return new FileSystemCommandResult.Success("Connected");
    }

    public interface IConnectCommandBuilder : IFileSystemBuilder<IConnectCommandBuilder>,
                                              IPathBuilder<IConnectCommandBuilder>
    { }

    private class ConnectCommandBuilder : IConnectCommandBuilder
    {
        private IFileSystem _fileSystem = new LocalFileSystem();

        private string _path = string.Empty;

        public IConnectCommandBuilder AddPath(string path)
        {
            _path = path;
            return this;
        }

        public IConnectCommandBuilder AddMode(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            return this;
        }

        public BuildCommandResult Build()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return new BuildCommandResult.Failure("No path");
            }

            if (_fileSystem is StubFileSystem)
            {
                return new BuildCommandResult.Failure("No file system");
            }

            return new BuildCommandResult.Success(new ConnectCommand(_fileSystem, _path));
        }
    }
}