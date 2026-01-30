using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

public class FileSystemSession
{
    private readonly FileSystemCore _core;

    public FileSystemSession(FileSystemCore core)
    {
        _core = core;
    }

    public IFileSystem FileSystem => _core.FileSystem;

    public string ConnectionPath => _core.ConnectionPath;

    public string CurrentPath => _core.CurrentPath;

    public ChangeStateResult Connect(string connectionPath, IFileSystem system)
    {
        return _core.FileSystemState.Connect(_core, connectionPath, system);
    }

    public ChangeStateResult Disconnect()
    {
        return _core.FileSystemState.Disconnect(_core);
    }

    public bool TryChangeDirectory(string path)
    {
        return _core.FileSystemState.TryChangeDirectory(_core, path);
    }
}