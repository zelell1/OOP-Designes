using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultType;

public abstract record AddCreatureResult
{
    private AddCreatureResult() { }

    public sealed record Success(ICreature Creature) : AddCreatureResult { }

    public sealed record Failure : AddCreatureResult { }
}