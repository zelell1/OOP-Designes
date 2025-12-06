using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.FileSystemComponentVisitorEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.VisitorsFactory.VisitorsFactoryEnteties;

public class TreeListVisitorFactory : IVisitorFactory
{
    public IFileSystemComponentVisitor CreateVisitor(TreeOutputParametrs parametrs, int depth)
    {
        return new TreeListVisitor(parametrs,  depth);
    }
}