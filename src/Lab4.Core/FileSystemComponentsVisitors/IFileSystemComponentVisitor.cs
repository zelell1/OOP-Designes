using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;

public interface IFileSystemComponentVisitor
{
    string Value { get; }

    void Visit(FileFileSystemComponent components);

    void Visit(DirectoryFileSystemComponent component);
}