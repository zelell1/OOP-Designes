using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;

public abstract class BaseFlagArgumentsChainParser<T> : IFlagArgumentsChainParser where T : ICommandBuilder
{
    private IFlagArgumentsChainParser? _next;

    public abstract ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator);

    public IFlagArgumentsChainParser AddNext(IFlagArgumentsChainParser parser)
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

    protected ArgumentParseResult CallNext(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (_next is null)
        {
            return new ArgumentParseResult.NotFound();
        }

        return _next.Apply(builder, iterator);
    }
}