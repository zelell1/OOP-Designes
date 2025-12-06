using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;

public abstract class BaseFlagChainParser<T> : IFlagChainParser where T : ICommandBuilder
{
    private readonly string _keyword;

    private readonly IFlagArgumentsChainSelector _argumentsChainSelector;

    private IFlagChainParser? _next;

    protected BaseFlagChainParser(string keyword, IFlagArgumentsChainSelector argumentsChainSelector)
    {
        _keyword = keyword;
        _argumentsChainSelector = argumentsChainSelector;
    }

    public ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current == _keyword)
        {
            iterator.MoveNext();
            ArgumentParseResult result = _argumentsChainSelector.Apply(builder, iterator);
            return result;
        }

        return CallNext(builder, iterator);
    }

    public virtual IFlagChainParser AddNext(IFlagChainParser parser)
    {
        if (_next is null)
        {
            _next = parser;
        }
        else
        {
            _next.AddNext(parser);
        }

        return this;
    }

    private ArgumentParseResult CallNext(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (_next is null)
        {
            return new ArgumentParseResult.NotFound();
        }

        return _next.Apply(builder, iterator);
    }
}