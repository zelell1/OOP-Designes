using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;

public class DefaultSystemComponent : IFileSystemComponent
{
    public string Name => string.Empty;

    public string Path => string.Empty;

    public void Accept(IFileSystemComponentVisitor visitor) { }

    public IEnumerable<IFileSystemComponent> GetContent() { return []; }
}