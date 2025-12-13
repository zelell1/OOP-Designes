using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public string Path { get; }

    public string Name { get; }

    private readonly IFileSystem _fileSystem;

    public DirectoryFileSystemComponent(string path, IFileSystem fileSystem)
    {
        Path = path;
        _fileSystem = fileSystem;
        Name = _fileSystem.GetFileName(path);
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerable<IFileSystemComponent> GetContent()
    {
        return _fileSystem.GetContent(Path);
    }
}