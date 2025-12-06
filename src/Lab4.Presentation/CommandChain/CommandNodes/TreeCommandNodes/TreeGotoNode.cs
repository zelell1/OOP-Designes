using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.TreeCommandNodes;

public class TreeGotoNode : BaseChainParser
{
    private const string Keyword = "goto";

    public TreeGotoNode(
        ICommandChainSelector chainSelector,
        IParametrsChainSelector parametrsChain,
        IFlagChainSelector flagChain)
        : base(Keyword, chainSelector, parametrsChain, flagChain) { }

    protected override ICommandBuilder CreateCommandBuilder()
    {
        return TreeGotoCommand.Builder;
    }
}