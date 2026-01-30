using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories;

public interface IParserCommandFactory
{
    ICommandChainParser Create();
}