using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;

public abstract class BaseChainParser : ICommandChainParser
{
    private ICommandChainParser? _next;

    public abstract ParseBuildCommandResult Apply(IEnumerator<string> iterator);

    public ICommandChainParser AddNext(ICommandChainParser parser)
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

    protected ParseBuildCommandResult CallNext(IEnumerator<string> iterator)
    {
        if (_next is null)
        {
            return new ParseBuildCommandResult.NotFound();
        }

        return _next.Apply(iterator);
    }
}