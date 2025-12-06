using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.FileSystemStateEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

public class FileSystemCore
{
    public IFileSystemState FileSystemState { get; private set; } = new DisconnectedFileSystem();

    public IFileSystem FileSystem { get; private set; } = new StubFileSystem();

    public string ConnectionPath { get; private set; } = string.Empty;

    public string CurrentPath { get; private set; } = string.Empty;

    public void SetConnection(IFileSystem system, string connectionPath)
    {
        FileSystem = system;
        ConnectionPath = connectionPath;
        CurrentPath = connectionPath;
    }

    public void SetState(IFileSystemState fileSystemState)
    {
        FileSystemState = fileSystemState;
    }

    public void SetCurrentPath(string currentPath)
    {
        CurrentPath = currentPath;
    }
}