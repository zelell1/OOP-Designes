using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

public interface IFileSystemComponent
{
    string Name { get; }

    string Path { get; }

    void Accept(IFileSystemComponentVisitor visitor);

    IEnumerable<IFileSystemComponent> GetContent();
}