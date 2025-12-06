using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.FileSystemStateEnteties;

public sealed class DisconnectedFileSystem : IFileSystemState
{
    public ChangeStateResult Connect(FileSystemCore core, string path, IFileSystem system)
    {
        core.SetConnection(system, path);
        core.SetState(new ConnectedFileSystem());

        return new ChangeStateResult.Success();
    }

    public ChangeStateResult Disconnect(FileSystemCore core)
    {
        return new ChangeStateResult.Failure("Disconnected");
    }

    public bool TryChangeDirectory(FileSystemCore core, string path)
    {
        return false;
    }
}