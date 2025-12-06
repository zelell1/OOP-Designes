using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.FileSystemCommandEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentsVisitors.VisitorsFactory.VisitorsFactoryEnteties;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagsChain.FlagsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.ConnectNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.TreeCommandNodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ParserCommandFactories.ParserCommandFactoriesEnteties;

public class TreeParserCommandFactory : IParserCommandFactory
{
    public ICommandChainParser Create()
    {
        IParametrsChainParser gotoParametrChain =
            new PathParametrNode<TreeGotoCommand.ITreeGotoCommandBuilder>();

        IFlagArgumentsChainParser treeListFlagArgumentsChain =
            new DepthArgumentNode<TreeListCommand.ITreeListCommandBuilder>();

        IFlagChainParser treeListFlagChain =
            new DepthFlagNode<TreeListCommand.ITreeListCommandBuilder>(treeListFlagArgumentsChain);

        var gotoChain =
            new ConnectNode(new EmptyNode(), gotoParametrChain, new EmptyFlagNode());

        var treeListChain =
           new TreeListNode(
               new EmptyNode(),
               new EmptyParametrNode(),
               treeListFlagChain,
               new TreeListVisitorFactory(),
               new TreeOutputParametrs(
                   string.Empty,
                   string.Empty,
                   ' '));

        ICommandChainParser treeChainSelector = treeListChain.AddNext(gotoChain);

        return new TreeNode(treeChainSelector, new EmptyParametrNode(), new EmptyFlagNode());
    }
}