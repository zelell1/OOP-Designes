using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.FileCommandNodes;

public class FileRenameNode : BaseChainParser
{
    private const string Keyword = "rename";

    private readonly IParametrsChainSelector _parametrsChain;

    public FileRenameNode(IParametrsChainSelector parametrsChain)
    {
        _parametrsChain = parametrsChain;
    }

    public override ParseBuildCommandResult Apply(IEnumerator<string> iterator)
    {
        if (iterator.Current != Keyword)
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        ICommandBuilder builder = FileRenameCommand.Builder;

        if (iterator.Current is not null && !iterator.Current.StartsWith('-'))
        {
            ArgumentParseResult parametrParseResult = _parametrsChain.Apply(builder, iterator);

            if (parametrParseResult is ArgumentParseResult.Failure failure)
            {
                return new ParseBuildCommandResult.Failure(failure.Error);
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