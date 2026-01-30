using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;

public interface ICommandChainSelector
{
    ParseBuildCommandResult Apply(IEnumerator<string> iterator);
}