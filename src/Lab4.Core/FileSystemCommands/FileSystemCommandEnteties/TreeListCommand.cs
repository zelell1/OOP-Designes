using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.VisitorsFactory;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
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
        if (session.FileSystem is StubFileSystem)
        {
            return new FileSystemCommandResult.Failure("Disconnected");
        }

        IFileSystemComponent comp = session.FileSystem.GetComponents(session.CurrentPath);

        if (comp is DirectoryFileSystemComponent dir)
        {
            dir.Accept(_componentVisitor);
            return new FileSystemCommandResult.Success(_componentVisitor.Value);
        }

        return new FileSystemCommandResult.Failure("Unknown failure");
    }

    public interface ITreeListCommandBuilder : IDepthBuilder<ITreeListCommandBuilder>
    {
        ITreeListCommandBuilder AddVisitor(IVisitorFactory componentVisitor);

        ITreeListCommandBuilder AddOutputParametrs(TreeOutputParametrs parametrs);
    }

    private class TreeListCommandBuilder : ITreeListCommandBuilder
    {
        private IVisitorFactory? _visitorFactory;

        private int _depth = -1;

        private TreeOutputParametrs _parametrs = TreeOutputParametrs.Empty;

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
            if (_visitorFactory is null)
            {
                return new BuildCommandResult.Failure("VisitorFactory is null");
            }

            if (_depth < 0)
            {
                return new BuildCommandResult.Failure("Depth not set");
            }

            if (_parametrs == TreeOutputParametrs.Empty)
            {
                return new BuildCommandResult.Failure("No parameters set");
            }

            IFileSystemComponentVisitor componentVisitor = _visitorFactory.CreateVisitor(_parametrs, _depth);
            return new BuildCommandResult.Success(new TreeListCommand(componentVisitor));
        }
    }
}