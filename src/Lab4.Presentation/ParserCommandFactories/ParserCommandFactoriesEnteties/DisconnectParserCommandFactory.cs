using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.DisconnectNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;

public class DisconnectParserCommandFactory : IParserCommandFactory
{
    public ICommandChainParser Create()
    {
        return new DisconnectNode();
    }
}