namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;

public interface IFlagArgumentsChainParser : IFlagArgumentsChainSelector
{
    IFlagArgumentsChainParser AddNext(IFlagArgumentsChainParser parser);
}