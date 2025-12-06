using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    string ShowFile(string path);

    IFileSystemComponent GetComponents(string path);

    bool MoveFile(string src, string dst);

    bool CopyFile(string src, string dst);

    bool DeleteFile(string path);

    bool RenameFile(string path, string name);

    string CombinePath(string connectedPath, string currentPath, string newPath);

    bool IsValidPath(string connectdPath, string path);
}