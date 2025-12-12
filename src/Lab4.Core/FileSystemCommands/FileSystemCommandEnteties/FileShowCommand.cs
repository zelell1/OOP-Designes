using Itmo.ObjectOrientedProgramming.Lab4.Core.FileContentOutput;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class FileShowCommand : IFileSystemCommand
{
    private readonly IFileContentOutput _fileContentOutput;

    private readonly string _path;

    private FileShowCommand(IFileContentOutput fileContentOutput, string path)
    {
        _fileContentOutput = fileContentOutput;
        _path = path;
    }

    public static IFileShowCommandBuilder Builder => new FileShowCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        if (session.FileSystem is StubFileSystem)
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        string newPath = session.FileSystem.CombinePath(session.ConnectionPath, session.CurrentPath, _path);

        if (!Path.Exists(newPath) || !Path.IsPathRooted(newPath))
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        string text = session.FileSystem.ShowFile(newPath);

        if (string.IsNullOrEmpty(text))
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        _fileContentOutput.Show(text);
        return new FileSystemCommandResult.Success(string.Empty);
    }

    public interface IFileShowCommandBuilder : IShowModeBuilder<IFileShowCommandBuilder>,
                                               IPathBuilder<IFileShowCommandBuilder>
    { }

    private class FileShowCommandBuilder : IFileShowCommandBuilder
    {
        private IFileContentOutput? _fileContentOutput;

        private string _path = string.Empty;

        public IFileShowCommandBuilder AddPath(string path)
        {
            _path = path;
            return this;
        }

        public IFileShowCommandBuilder AddShowMode(IFileContentOutput fileContentOutput)
        {
            _fileContentOutput = fileContentOutput;
            return this;
        }

        public BuildCommandResult Build()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return new BuildCommandResult.Failure("No path");
            }

            if (_fileContentOutput is not null)
            {
                return new BuildCommandResult.Success(new FileShowCommand(_fileContentOutput, _path));
            }

            return new BuildCommandResult.Failure("Neccesary flag missed");
        }
    }
}