using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;

public class EmptyNode : ICommandChainSelector
{
    public ParseBuildCommandResult Apply(IEnumerator<string> iterator)
    {
        return new ParseBuildCommandResult.Failure("Empty node");
    }
}