using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;

public abstract class BaseChainParser : ICommandChainParser
{
    private readonly string _keyword;

    private readonly ICommandChainSelector _commandSubChain;

    private readonly IParametrsChainSelector _parametrsChain;

    private readonly IFlagChainSelector _flagChain;

    private ICommandChainParser? _next;

    protected BaseChainParser(
        string keyword,
        ICommandChainSelector chainSelector,
        IParametrsChainSelector parametrChain,
        IFlagChainSelector flagChain)
    {
        _keyword = keyword;
        _commandSubChain = chainSelector;
        _parametrsChain = parametrChain;
        _flagChain = flagChain;
    }

    public ParseBuildCommandResult Apply(IEnumerator<string> iterator)
    {
        if (iterator.Current != _keyword)
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        ParseBuildCommandResult result = _commandSubChain.Apply(iterator);

        if (result is ParseBuildCommandResult.Success || result is ParseBuildCommandResult.Failure)
        {
            return result;
        }

        ICommandBuilder builder = CreateCommandBuilder();

        while (iterator.Current is not null && !iterator.Current.StartsWith('-'))
        {
            ArgumentParseResult parametrParseResult = _parametrsChain.Apply(builder, iterator);

            if (parametrParseResult is ArgumentParseResult.Failure failure)
            {
                return new ParseBuildCommandResult.Failure(failure.Error);
            }

            if (parametrParseResult is ArgumentParseResult.NotFound)
            {
                break;
            }
        }

        while (iterator.Current is not null && iterator.Current.StartsWith('-'))
        {
            ArgumentParseResult flagsParseResult = _flagChain.Apply(builder, iterator);

            if (flagsParseResult is ArgumentParseResult.Failure failure)
            {
                return new ParseBuildCommandResult.Failure(failure.Error);
            }

            if (flagsParseResult is ArgumentParseResult.NotFound)
            {
                return new ParseBuildCommandResult.Failure("Unknown flag");
            }
        }

        if (iterator.Current is not null)
        {
            return new ParseBuildCommandResult.Failure("Too many arguments");
        }

        BuildCommandResult builderResult = builder.Build();

        if (builderResult is BuildCommandResult.Success success && success.Command is not NullCommand)
        {
            return new ParseBuildCommandResult.Success(success.Command);
        }

        if (builderResult is BuildCommandResult.Failure fail)
        {
            return new ParseBuildCommandResult.Failure(fail.Error);
        }

        return new ParseBuildCommandResult.Failure("Invalid command");
    }

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

    protected abstract ICommandBuilder CreateCommandBuilder();

    private ParseBuildCommandResult CallNext(IEnumerator<string> iterator)
    {
        if (_next is null)
        {
            return new ParseBuildCommandResult.NotFound();
        }

        return _next.Apply(iterator);
    }
}