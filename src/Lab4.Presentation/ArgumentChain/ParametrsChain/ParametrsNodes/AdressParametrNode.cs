using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;

public class AdressParametrNode<T> : BaseParametrChainParser<T> where T : IPathBuilder<T>
{
    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (builder is T adressBuilder)
        {
            adressBuilder.AddPath(iterator.Current);
            iterator.MoveNext();
            return new ArgumentParseResult.Success();
        }

        return CallNext(builder, iterator);
    }
}