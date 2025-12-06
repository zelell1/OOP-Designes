using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemCommands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.ArgumentChain.FlagArgumentsChain.FlagArgumentsNodes;

public class DepthArgumentNode<T> : BaseFlagArgumentsChainParser<T> where T : IDepthBuilder<T>
{
    public override ArgumentParseResult Apply(ICommandBuilder builder, IEnumerator<string> iterator)
    {
        if (!int.TryParse(iterator.Current, out int depth))
        {
            return new ArgumentParseResult.Failure("Depth must be an integer");
        }

        if (builder is T depthBuilder)
        {
            depthBuilder.AddDepth(depth);
            iterator.MoveNext();
            return new ArgumentParseResult.Success();
        }

        return CallNext(builder, iterator);
    }
}