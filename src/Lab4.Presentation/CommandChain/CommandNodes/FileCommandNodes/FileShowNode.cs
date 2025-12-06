using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.FileCommandNodes;

public class FileShowNode : BaseChainParser
{
    private const string Keyword = "show";

    public FileShowNode(
        ICommandChainSelector chainSelector,
        IParametrsChainSelector parametrsChain,
        IFlagChainSelector flagChain)
        : base(Keyword, chainSelector, parametrsChain, flagChain) { }

    protected override ICommandBuilder CreateCommandBuilder()
    {
        return FileShowCommand.Builder;
    }
}