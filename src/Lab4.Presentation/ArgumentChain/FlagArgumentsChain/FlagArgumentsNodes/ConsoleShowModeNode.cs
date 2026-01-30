using Itmo.ObjectOrientedProgramming.Lab4.Core.FileContentOutput;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;

public class ConsoleShowModeNode<T> : BaseFlagArgumentsChainParser<T> where T : IShowModeBuilder<T>
{
    private const string Keyword = "console";

    private readonly IFileContentOutput _fileContentOutput;

    public ConsoleShowModeNode(IFileContentOutput fileContentOutput)
    {
        _fileContentOutput = fileContentOutput;
    }

    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current is null)
        {
            return new ArgumentParseResult.Failure("File show mode must have a value");
        }

        if (builder is T showModeBuilder && iterator.Current == Keyword)
        {
            showModeBuilder.AddShowMode(_fileContentOutput);
            iterator.MoveNext();
            return new ArgumentParseResult.Success();
        }

        return CallNext(builder, iterator);
    }
}