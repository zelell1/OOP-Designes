using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class FileMoveCommand : IFileSystemCommand
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    private FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public static IFileMoveCommandBuilder Builder => new FileMoveCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        if (session.FileSystem is StubFileSystem)
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        string newSourcePath = session.FileSystem.CombinePath(session.ConnectionPath, session.CurrentPath, _sourcePath);

        string newDestPath = session.FileSystem.CombinePath(
                             session.ConnectionPath, session.CurrentPath, _destinationPath);

        if (!session.FileSystem.IsValidPath(session.ConnectionPath, newSourcePath))
        {
            return new FileSystemCommandResult.Failure(string.Empty);
        }

        if (!session.FileSystem.MoveFile(newSourcePath, newDestPath))
        {
            return new FileSystemCommandResult.Failure("Can't Move");
        }

        return new FileSystemCommandResult.Success("Moved");
    }

    public interface IFileMoveCommandBuilder : ISrcDstBuilder<IFileMoveCommandBuilder> { }

    private class FileMoveCommandBuilder : IFileMoveCommandBuilder
    {
        private string _sourcePath = string.Empty;

        private string _destinationPath = string.Empty;

        public IFileMoveCommandBuilder AddSrc(string src)
        {
            _sourcePath = src;
            return this;
        }

        public IFileMoveCommandBuilder AddDst(string dst)
        {
            _destinationPath = dst;
            return this;
        }

        public BuildCommandResult Build()
        {
            if (string.IsNullOrEmpty(_sourcePath) || string.IsNullOrEmpty(_destinationPath))
            {
                return new BuildCommandResult.Failure("No path");
            }

            return new BuildCommandResult.Success(new FileMoveCommand(_sourcePath, _destinationPath));
        }
    }
}