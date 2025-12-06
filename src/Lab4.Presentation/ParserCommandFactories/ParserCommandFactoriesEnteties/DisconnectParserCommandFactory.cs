using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.DisconnectNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;

public class DisconnectParserCommandFactory : IParserCommandFactory
{
    public ICommandChainParser Create()
    {
        return new DisconnectNode(new EmptyNode(), new EmptyParametrNode(), new EmptyFlagNode());
    }
}