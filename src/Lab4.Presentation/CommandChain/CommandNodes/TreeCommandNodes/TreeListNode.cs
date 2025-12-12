using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.VisitorsFactory;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.TreeCommandNodes;

public class TreeListNode : BaseChainParser
{
    private const string Keyword = "list";

    private readonly IFlagChainSelector _flagChain;

    private readonly IVisitorFactory _visitorFactory;

    private readonly TreeOutputParametrs _parametrs;

    private readonly int _depth;

    public TreeListNode(
        IFlagChainSelector flagChain,
        IVisitorFactory factory,
        TreeOutputParametrs parametrs,
        int depth)
    {
        _flagChain = flagChain;
        _visitorFactory = factory;
        _parametrs = parametrs;
        _depth = depth;
    }

    public override ParseBuildCommandResult Apply(IEnumerator<string> iterator)
    {
        if (iterator.Current != Keyword)
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        ICommandBuilder builder = TreeListCommand.Builder
            .AddVisitor(_visitorFactory)
            .AddOutputParametrs(_parametrs)
            .AddDepth(_depth);

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

        if (builderResult is BuildCommandResult.Success success)
        {
            return new ParseBuildCommandResult.Success(success.Command);
        }

        if (builderResult is BuildCommandResult.Failure fail)
        {
            return new ParseBuildCommandResult.Failure(fail.Error);
        }

        return new ParseBuildCommandResult.Failure("Invalid command");
    }
}