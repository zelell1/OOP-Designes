using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.VisitorsFactory;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.TreeCommandNodes;

public class TreeListNode : BaseChainParser
{
    private const string Keyword = "list";

    private readonly IVisitorFactory _visitorFactory;

    private readonly TreeOutputParametrs _parametrs;

    public TreeListNode(
        ICommandChainSelector chainSelector,
        IParametrsChainSelector parametrsChain,
        IFlagChainSelector flagChain,
        IVisitorFactory factory,
        TreeOutputParametrs parametrs)
        : base(Keyword, chainSelector, parametrsChain, flagChain)
    {
        _visitorFactory = factory;
        _parametrs = parametrs;
    }

    protected override ICommandBuilder CreateCommandBuilder()
    {
        return TreeListCommand.Builder.AddVisitor(_visitorFactory).AddOutputParametrs(_parametrs);
    }
}