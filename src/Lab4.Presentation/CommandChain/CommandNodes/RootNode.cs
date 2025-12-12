using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;

public class RootNode
{
    private readonly ICommandChainParser _parser;

    public RootNode(ICommandChainParser parser)
    {
        _parser = parser;
    }

    public ParseBuildCommandResult Parse(IEnumerator<string> iterator)
    {
        if (!iterator.MoveNext())
        {
            return new ParseBuildCommandResult.Failure("Empty command");
        }

        ParseBuildCommandResult result = _parser.Apply(iterator);

        if (result is ParseBuildCommandResult.NotFound)
        {
            return new ParseBuildCommandResult.Failure("Command not found");
        }

        return result;
    }
}