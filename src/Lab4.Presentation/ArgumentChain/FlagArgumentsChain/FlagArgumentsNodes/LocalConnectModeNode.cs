using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;

public class LocalConnectModeNode<T> : BaseFlagArgumentsChainParser<T> where T : IFileSystemBuilder<T>
{
    private readonly IFileSystem _fileSystem;

    private readonly string _keyword;

    public LocalConnectModeNode(IFileSystem fileSystem, string keyword)
    {
        _fileSystem = fileSystem;
        _keyword = keyword;
    }

    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (builder is T fileSystemBuilder && iterator.Current == _keyword)
        {
            fileSystemBuilder.AddMode(_fileSystem);
            iterator.MoveNext();
            return new ArgumentParseResult.Success();
        }

        return CallNext(builder, iterator);
    }
}