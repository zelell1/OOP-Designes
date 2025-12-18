using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.SpellEnteties;

public class BuffAttackSpell : ISpell
{
    public ICreature CastSpell(ICreature creature)
    {
        creature.SetAttack(new Attack(creature.Attack.Value + 5));
        return creature;
    }
}