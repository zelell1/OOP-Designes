using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.SpellEnteties;

public class BuffStaminaSpell : ISpell
{
    public ICreature CastSpell(ICreature creature)
    {
        creature.SetHealth(new Health(creature.Health.Value + 5));
        return creature;
    }
}