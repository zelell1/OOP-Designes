using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class FileCopyCommand : IFileSystemCommand
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    private FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public static IFileCopyCommandBuilder Builder => new FileCopyCommandBuilder();

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

        if (!session.FileSystem.CopyFile(newSourcePath, newDestPath))
        {
            return new FileSystemCommandResult.Failure("Can't copy");
        }

        return new FileSystemCommandResult.Success("Copied");
    }

    public interface IFileCopyCommandBuilder : ISourceDestinationBuilder<IFileCopyCommandBuilder> { }

    private class FileCopyCommandBuilder : IFileCopyCommandBuilder
    {
        private string _sourcePath = string.Empty;

        private string _destinationPath = string.Empty;

        public IFileCopyCommandBuilder AddSrc(string src)
        {
            _sourcePath = src;
            return this;
        }

        public IFileCopyCommandBuilder AddDst(string dst)
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

            return new BuildCommandResult.Success(new FileCopyCommand(_sourcePath, _destinationPath));
        }
    }
}