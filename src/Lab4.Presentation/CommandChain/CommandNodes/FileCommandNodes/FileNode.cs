using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandChain.CommandNodes.FileCommandNodes;

public class FileNode : BaseChainParser
{
    private const string Keyword = "file";

    private readonly ICommandChainSelector _commandSubChain;

    public FileNode(ICommandChainSelector chainSelector)
    {
        _commandSubChain = chainSelector;
    }

    public override ParseBuildCommandResult Apply(IEnumerator<string> iterator)
    {
        if (iterator.Current != Keyword)
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        if (iterator.Current is null)
        {
            return new ParseBuildCommandResult.Failure("Too few arguments");
        }

        return _commandSubChain.Apply(iterator);
    }
}