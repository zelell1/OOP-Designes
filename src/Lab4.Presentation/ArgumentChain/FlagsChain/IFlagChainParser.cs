namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;

public interface IFlagChainParser : IFlagChainSelector
{
    IFlagChainParser AddNext(IFlagChainParser parser);
}