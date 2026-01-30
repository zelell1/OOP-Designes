using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.FileSystemComponentsEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.FileSystemComponentVisitorEnteties;

public sealed class TreeListVisitor : IFileSystemComponentVisitor
{
    public string Value => _builder.ToString();

    public TreeListVisitor(TreeOutputParametrs parameters, int depth)
    {
        _parameters = parameters;
        _builder = new StringBuilder();
        _padding = 0;
        _maxDepth = depth;
    }

    private readonly TreeOutputParametrs _parameters;

    private readonly StringBuilder _builder;

    private int _maxDepth;

    private int _padding;

    public void Visit(FileFileSystemComponent component)
    {
        _builder.Append(_parameters.PaddingIcon, _padding * 3);
        _builder.Append(_parameters.FileIcon);
        _builder.AppendLine(component.Name);
    }

    public void SetDepth(int depth)
    {
        _maxDepth = depth;
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        _builder.Append(_parameters.PaddingIcon, _padding * 3);
        _builder.Append(_parameters.DirectoryIcon);
        _builder.AppendLine(component.Name);

        if (_padding == _maxDepth)
        {
            return;
        }

        _padding += 1;

        foreach (IFileSystemComponent comp in component.GetContent())
        {
            comp.Accept(this);
        }

        _padding -= 1;
    }
}