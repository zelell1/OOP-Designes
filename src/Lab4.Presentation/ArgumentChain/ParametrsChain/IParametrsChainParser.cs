namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;

public interface IParametrsChainParser : IParametrsChainSelector
{
    IParametrsChainParser AddNext(IParametrsChainParser parser);
}