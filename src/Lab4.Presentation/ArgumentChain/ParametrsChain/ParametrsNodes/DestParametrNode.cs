using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;

public class DestParametrNode<T> : BaseParametrChainParser<T> where T : ISrcDstBuilder<T>
{
    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (builder is T dstBuilder)
        {
            dstBuilder.AddDst(iterator.Current);
            iterator.MoveNext();
            return new ArgumentParseResult.Success();
        }

        return CallNext(builder, iterator);
    }
}