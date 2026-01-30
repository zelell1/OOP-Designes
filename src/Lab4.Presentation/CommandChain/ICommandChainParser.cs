namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;

public interface ICommandChainParser : ICommandChainSelector
{
    ICommandChainParser AddNext(ICommandChainParser parser);
}