using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.ConnectNodes;

public class ConnectNode : BaseChainParser
{
    private const string Keyword = "connect";

    private readonly IParametrsChainSelector _parametrsChain;

    private readonly IFlagChainSelector _flagChain;

    private readonly IFileSystem _fileSystem;

    public ConnectNode(
        IParametrsChainSelector parametrsChain,
        IFlagChainSelector flagChain,
        IFileSystem fileSystem)
    {
        _parametrsChain = parametrsChain;
        _flagChain = flagChain;
        _fileSystem = fileSystem;
    }

    public override ParseBuildCommandResult Apply(IEnumerator<string> iterator)
    {
        if (iterator.Current != Keyword)
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        ICommandBuilder builder = ConnectCommand.Builder.AddMode(_fileSystem);

        ArgumentParseResult parametrParseResult = _parametrsChain.Apply(builder, iterator);
        ArgumentParseResult flagsParseResult = _flagChain.Apply(builder, iterator);

        if (parametrParseResult is ArgumentParseResult.Failure parametrFailure)
        {
            return new ParseBuildCommandResult.Failure(parametrFailure.Error);
        }

        if (flagsParseResult is ArgumentParseResult.Failure failure)
        {
            return new ParseBuildCommandResult.Failure(failure.Error);
        }

        if (flagsParseResult is ArgumentParseResult.NotFound)
        {
            return new ParseBuildCommandResult.Failure("Unknown flag");
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