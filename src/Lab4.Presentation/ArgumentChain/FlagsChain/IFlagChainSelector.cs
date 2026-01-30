using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;

public interface IFlagChainSelector
{
    ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator);
}