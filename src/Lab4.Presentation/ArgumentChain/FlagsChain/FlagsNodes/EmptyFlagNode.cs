using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;

public class EmptyFlagNode : IFlagChainSelector
{
    public ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        return new ArgumentParseResult.NotFound();
    }
}