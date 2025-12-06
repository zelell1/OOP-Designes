using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;

public class LocalFileSystem : IFileSystem
{
    public string ShowFile(string path)
    {
        return File.ReadAllText(path);
    }

    public IFileSystemComponent GetComponents(string path)
    {
        return new DirectoryFileSystemComponent(path);
    }

    public bool MoveFile(string src, string dst)
    {
        File.Move(src, dst);

        return true;
    }

    public bool CopyFile(string src, string dst)
    {
        File.Copy(src, dst);

        return true;
    }

    public bool DeleteFile(string path)
    {
        File.Delete(path);

        return true;
    }

    public bool RenameFile(string path, string name)
    {
        string? dirPath = Path.GetDirectoryName(path);

        if (dirPath == null)
        {
            return false;
        }

        File.Move(path, Path.Combine(dirPath, name));

        return true;
    }

    public string CombinePath(string connectedPath, string currentPath, string newPath)
    {
        if (newPath.StartsWith('/') || newPath.StartsWith('\\'))
        {
            return Path.Combine(connectedPath, newPath.TrimStart('/', '\\'));
        }

        return Path.GetFullPath(Path.Combine(currentPath, newPath));
    }

    public bool IsValidPath(string connectdPath, string path)
    {
        return Path.Exists(Path.GetFullPath(path)) && Path.GetFullPath(path).StartsWith(connectdPath);
    }
}