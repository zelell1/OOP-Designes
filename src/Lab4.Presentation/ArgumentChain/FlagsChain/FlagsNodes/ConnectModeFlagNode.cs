using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;

public class ConnectModeFlagNode<T> : BaseFlagChainParser<T> where T : IFileSystemBuilder<T>
{
    private const string Keyword = "-m";

    private readonly IFlagArgumentsChainSelector _argumentsChainSelector;

    public ConnectModeFlagNode(IFlagArgumentsChainSelector argumentsChainSelector)
    {
        _argumentsChainSelector = argumentsChainSelector;
    }

    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current == Keyword)
        {
            iterator.MoveNext();
            ArgumentParseResult result = _argumentsChainSelector.Apply(builder, iterator);
            return result;
        }

        return CallNext(builder, iterator);
    }
}