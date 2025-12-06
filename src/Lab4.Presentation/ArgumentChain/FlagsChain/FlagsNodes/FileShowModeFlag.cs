using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;

public class FileShowModeFlag<T> : BaseFlagChainParser<T> where T : IShowModeBuilder<T>
{
    private const string Keyword = "-m";

    public FileShowModeFlag(IFlagArgumentsChainSelector argumentsChainSelector) : base(Keyword, argumentsChainSelector) { }
}