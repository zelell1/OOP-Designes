using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;

public class StubFileSystem : IFileSystem
{
    public string ShowFile(string path)
    {
        return string.Empty;
    }

    public IFileSystemComponent GetComponents(string path)
    {
        return new DefaultSystemComponent();
    }

    public IEnumerable<IFileSystemComponent> GetContent(string path)
    {
        return [];
    }

    public string GetFileName(string path)
    {
        return string.Empty;
    }

    public string GetDirectoryName(string path)
    {
        return string.Empty;
    }

    public bool MoveFile(string src, string dst)
    {
        return false;
    }

    public bool CopyFile(string src, string dst)
    {
        return false;
    }

    public bool DeleteFile(string path)
    {
        return false;
    }

    public bool RenameFile(string path, string name)
    {
        return false;
    }

    public string CombinePath(string connectedPath, string currentPath, string newPath)
    {
        return string.Empty;
    }

    public bool IsValidPath(string connectdPath, string path)
    {
        return false;
    }
}