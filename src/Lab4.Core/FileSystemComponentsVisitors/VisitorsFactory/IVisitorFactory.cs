using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.VisitorsFactory;

public interface IVisitorFactory
{
    IFileSystemComponentVisitor CreateVisitor(TreeOutputParametrs parametrs, int depth);
}