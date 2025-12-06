using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.ConnectNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;

public class ConnectParserCommandFactory : IParserCommandFactory
{
    public ICommandChainParser Create()
    {
        IParametrsChainParser parametrChainSelector = new AdressParametrNode<ConnectCommand.IConnectCommandBuilder>();

        IFlagArgumentsChainParser flagArgumentsChainSelector =
            new LocalConnectModeNode<ConnectCommand.IConnectCommandBuilder>(new LocalFileSystem(), "local");

        IFlagChainParser argumentsChainSelector =
            new ConnectModeFlagNode<ConnectCommand.IConnectCommandBuilder>(flagArgumentsChainSelector);

        return new ConnectNode(new EmptyNode(), parametrChainSelector, argumentsChainSelector);
    }
}