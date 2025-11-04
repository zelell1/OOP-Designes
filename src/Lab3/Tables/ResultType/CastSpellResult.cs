using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultType;

public abstract record CastSpellResult
{
    private CastSpellResult() { }

    public sealed record Success(ICreature Creature) : CastSpellResult { }

    public sealed record CreatureNotFound : CastSpellResult { }
}