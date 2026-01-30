using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;

public class LocalConnectModeNode<T> : BaseFlagArgumentsChainParser<T> where T : IFileSystemBuilder<T>
{
    private const string Keyword = "local";

    private readonly IFileSystem _fileSystem;

    public LocalConnectModeNode(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current is null)
        {
            return new ArgumentParseResult.Failure("Connect mode must have a value");
        }

        if (builder is T fileSystemBuilder && iterator.Current == Keyword)
        {
            fileSystemBuilder.AddMode(_fileSystem);
            iterator.MoveNext();
            return new ArgumentParseResult.Success();
        }

        return CallNext(builder, iterator);
    }
}