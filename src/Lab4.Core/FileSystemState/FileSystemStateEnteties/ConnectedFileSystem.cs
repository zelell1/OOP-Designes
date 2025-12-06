using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.FileSystemStateEnteties;

public sealed class ConnectedFileSystem : IFileSystemState
{
    public ChangeStateResult Connect(FileSystemCore core, string path, IFileSystem system)
    {
        return new ChangeStateResult.Failure("Already connected");
    }

    public ChangeStateResult Disconnect(FileSystemCore core)
    {
        core.SetConnection(new StubFileSystem(), string.Empty);
        core.SetState(new DisconnectedFileSystem());

        return new ChangeStateResult.Success();
    }

    public bool TryChangeDirectory(FileSystemCore core, string path)
    {
        core.SetCurrentPath(path);

        return true;
    }
}