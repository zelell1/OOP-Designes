using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;

public class RootParserCommandFactory : IParserCommandFactory
{
    public ICommandChainParser Create()
    {
        return new ConnectParserCommandFactory().Create()
            .AddNext(new DisconnectParserCommandFactory().Create())
            .AddNext(new TreeParserCommandFactory().Create())
            .AddNext(new FileParserCommandFactory().Create());
    }
}