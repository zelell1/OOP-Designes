using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class TreeGotoCommand : IFileSystemCommand
{
    private readonly string _path;

    private TreeGotoCommand(string path)
    {
        _path = path;
    }

    public static ITreeGotoCommandBuilder Builder => new TreeGotoCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        string newPath = session.FileSystem.CombinePath(session.ConnectionPath, session.CurrentPath, _path);

        if (!session.FileSystem.IsValidPath(session.ConnectionPath, newPath))
            return new FileSystemCommandResult.Failure(string.Empty);

        if (!session.TryChangeDirectory(newPath))
            return new FileSystemCommandResult.Failure("Can't rename");

        return new FileSystemCommandResult.Success("Changed path");
    }

    public interface ITreeGotoCommandBuilder : IPathBuilder<ITreeGotoCommandBuilder> { }

    private class TreeGotoCommandBuilder : ITreeGotoCommandBuilder
    {
        private string _path = string.Empty;

        public ITreeGotoCommandBuilder AddPath(string path)
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

            return new BuildCommandResult.Success(new TreeGotoCommand(_path));
        }
    }
}