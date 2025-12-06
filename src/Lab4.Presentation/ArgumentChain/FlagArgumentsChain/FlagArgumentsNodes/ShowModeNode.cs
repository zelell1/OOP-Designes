using Itmo.ObjectOrientedProgramming.Lab4.Core.FileContentOutput;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;

public class ShowModeNode<T> : BaseFlagArgumentsChainParser<T> where T : IShowModeBuilder<T>
{
    private readonly IFileContentOutput _fileContentOutput;

    private readonly string _keyword;

    public ShowModeNode(IFileContentOutput fileContentOutput, string keyword)
    {
        _fileContentOutput = fileContentOutput;
        _keyword = keyword;
    }

    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (builder is T showModeBuilder && iterator.Current == _keyword)
        {
            showModeBuilder.AddShowMode(_fileContentOutput);
            iterator.MoveNext();
            return new ArgumentParseResult.Success();
        }

        return CallNext(builder, iterator);
    }
}