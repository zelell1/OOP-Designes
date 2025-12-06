using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;

public class DepthFlagNode<T> : BaseFlagChainParser<T> where T : IDepthBuilder<T>
{
    private const string Keyword = "-d";

    public DepthFlagNode(IFlagArgumentsChainSelector argumentsChainSelector) : base(Keyword, argumentsChainSelector) { }
}