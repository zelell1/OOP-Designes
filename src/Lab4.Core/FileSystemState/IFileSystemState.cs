using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;

public interface IFileSystemState
{
    ChangeStateResult Connect(FileSystemCore core, string path, IFileSystem system);

    ChangeStateResult Disconnect(FileSystemCore core);

    bool TryChangeDirectory(FileSystemCore core, string path);
}