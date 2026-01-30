using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;

public interface IFlagArgumentsChainSelector
{
    ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator);
}