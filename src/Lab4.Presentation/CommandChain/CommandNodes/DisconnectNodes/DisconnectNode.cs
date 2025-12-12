using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.DisconnectNodes;

public class DisconnectNode : BaseChainParser
{
    private const string Keyword = "disconnect";

    public override ParseBuildCommandResult Apply(IEnumerator<string> iterator)
    {
        if (iterator.Current != Keyword)
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        if (iterator.Current is not null)
        {
            return new ParseBuildCommandResult.Failure("Too many arguments");
        }

        BuildCommandResult builderResult = DisconnectCommand.Builder.Build();

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