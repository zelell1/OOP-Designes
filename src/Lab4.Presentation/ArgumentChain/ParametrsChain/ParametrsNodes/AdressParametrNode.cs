using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ParametrsChain.ParametrsNodes;

public class AdressParametrNode<T> : BaseParametrChainParser<T> where T : IPathBuilder<T>
{
    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (iterator.Current is null)
        {
            return new ArgumentParseResult.Failure("Adress parametr missing");
        }

        if (builder is T adressBuilder)
        {
            adressBuilder.AddPath(iterator.Current);
            iterator.MoveNext();
        }

        return CallNext(builder, iterator);
    }
}