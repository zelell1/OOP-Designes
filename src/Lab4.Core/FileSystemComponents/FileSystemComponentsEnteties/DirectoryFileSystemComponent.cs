using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public string Path { get; }

    public string Name { get; }

    public DirectoryFileSystemComponent(string path)
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
        foreach (string component in Directory.EnumerateFileSystemEntries(Path))
        {
            if (Directory.Exists(component))
            {
                yield return new DirectoryFileSystemComponent(component);
            }

            yield return new FileFileSystemComponent(component);
        }
    }
}