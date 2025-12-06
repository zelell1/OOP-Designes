using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;

public class FileFileSystemComponent : IFileSystemComponent
{
    public string Path { get; }

    public string Name { get; }

    public FileFileSystemComponent(string path)
    {
        Path = path;
        Name = System.IO.Path.GetFileName(path);
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerable<IFileSystemComponent> GetContent()
    {
        yield break;
    }
}