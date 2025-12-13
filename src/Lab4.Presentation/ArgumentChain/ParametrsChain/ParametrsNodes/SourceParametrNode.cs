using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;

public class SourceParametrNode<T> : BaseParametrChainParser<T> where T : ISourceDestinationBuilder<T>
{
    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current is null)
        {
            return new ArgumentParseResult.Failure("Source path parametr missing");
        }

        if (builder is T srcBuilder)
        {
            srcBuilder.AddSrc(iterator.Current);
            iterator.MoveNext();
        }

        return CallNext(builder, iterator);
    }
}