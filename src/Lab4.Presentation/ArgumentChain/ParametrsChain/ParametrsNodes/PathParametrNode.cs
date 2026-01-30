using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;

public class PathParametrNode<T> : BaseParametrChainParser<T> where T : IPathBuilder<T>
{
    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current is null)
        {
            return new ArgumentParseResult.Failure("Path parametr missing");
        }

        if (builder is T pathBuilder)
        {
            pathBuilder.AddPath(iterator.Current);
            iterator.MoveNext();
        }

        return CallNext(builder, iterator);
    }
}