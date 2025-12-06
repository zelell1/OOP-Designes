using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;

public abstract class BaseParametrChainParser<T> : IParametrsChainParser where T : ICommandBuilder
{
    private IParametrsChainParser? _next;

    public abstract ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator);

    public IParametrsChainParser AddNext(IParametrsChainParser parser)
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
            return new ArgumentParseResult.Success();
        }

        return _next.Apply(builder, iterator);
    }
}