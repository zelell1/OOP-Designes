using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;

public class NameParametrNode<T> : BaseParametrChainParser<T> where T : INameBuilder<T>
{
    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (builder is T adressBuilder)
        {
            adressBuilder.AddName(iterator.Current);
            iterator.MoveNext();
        }

        return CallNext(builder, iterator);
    }
}