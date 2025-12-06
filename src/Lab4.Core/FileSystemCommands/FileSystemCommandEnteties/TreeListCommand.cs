using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.VisitorsFactory;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemState;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;

public class TreeListCommand : IFileSystemCommand
{
    private readonly IFileSystemComponentVisitor _componentVisitor;

    private TreeListCommand(IFileSystemComponentVisitor componentVisitor)
    {
        _componentVisitor = componentVisitor;
    }

    public static ITreeListCommandBuilder Builder => new TreeListCommandBuilder();

    public FileSystemCommandResult Run(FileSystemSession session)
    {
        IFileSystemComponent comp = session.FileSystem.GetComponents(session.CurrentPath);

        if (comp is DirectoryFileSystemComponent dir)
        {
            _componentVisitor.Visit(dir);
            return new FileSystemCommandResult.Success(_componentVisitor.Value);
        }

        return new FileSystemCommandResult.Failure(string.Empty);
    }

    public interface ITreeListCommandBuilder : IDepthBuilder<ITreeListCommandBuilder>
    {
        ITreeListCommandBuilder AddVisitor(IVisitorFactory componentVisitor);

        ITreeListCommandBuilder AddOutputParametrs(TreeOutputParametrs parametrs);
    }

    private class TreeListCommandBuilder : ITreeListCommandBuilder
    {
        private IVisitorFactory? _visitorFactory;

        private TreeOutputParametrs _parametrs = new TreeOutputParametrs(
                                                string.Empty,
                                                string.Empty,
                                                ' ');

        private int _depth = 1;

        public ITreeListCommandBuilder AddOutputParametrs(TreeOutputParametrs parametrs)
        {
            _parametrs = parametrs;
            return this;
        }

        public ITreeListCommandBuilder AddDepth(int depth)
        {
            _depth = depth;
            return this;
        }

        public ITreeListCommandBuilder AddVisitor(IVisitorFactory visitorFactory)
        {
            _visitorFactory = visitorFactory;
            return this;
        }

        public BuildCommandResult Build()
        {
            if (_visitorFactory is not null)
            {
                IFileSystemComponentVisitor componentVisitor = _visitorFactory.CreateVisitor(_parametrs, _depth);
                return new BuildCommandResult.Success(new TreeListCommand(componentVisitor));
            }

            return new BuildCommandResult.Failure("No depth");
        }
    }
}