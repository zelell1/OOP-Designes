using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;

public class ConnectModeFlagNode<T> : BaseFlagChainParser<T> where T : IFileSystemBuilder<T>
{
    private const string Keyword = "-m";

    public ConnectModeFlagNode(IFlagArgumentsChainSelector argumentsChainSelector) : base(Keyword, argumentsChainSelector) { }
}