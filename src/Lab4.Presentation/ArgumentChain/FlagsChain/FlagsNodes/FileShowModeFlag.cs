using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;

public class FileShowModeFlag<T> : BaseFlagChainParser<T> where T : IShowModeBuilder<T>
{
    private const string Keyword = "-m";

    private readonly IFlagArgumentsChainSelector _argumentsChainSelector;

    public FileShowModeFlag(IFlagArgumentsChainSelector argumentsChainSelector)
    {
        _argumentsChainSelector = argumentsChainSelector;
    }

    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current is null)
        {
            return new ArgumentParseResult.Success();
        }

        if (iterator.Current == Keyword)
        {
            iterator.MoveNext();
            ArgumentParseResult result = _argumentsChainSelector.Apply(builder, iterator);

            if (result is ArgumentParseResult.Success)
            {
                return Apply(builder, iterator);
            }

            return result;
        }

        return CallNext(builder, iterator);
    }
}