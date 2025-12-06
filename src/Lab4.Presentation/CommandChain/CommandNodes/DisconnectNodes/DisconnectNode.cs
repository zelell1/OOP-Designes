using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.DisconnectNodes;

public class DisconnectNode : BaseChainParser
{
    private const string Keyword = "disconnect";

    public DisconnectNode(
        ICommandChainSelector chainSelector,
        IParametrsChainSelector parametrsChain,
        IFlagChainSelector flagChain)
        : base(Keyword, chainSelector, parametrsChain, flagChain) { }

    protected override ICommandBuilder CreateCommandBuilder()
    {
        return DisconnectCommand.Builder;
    }
}