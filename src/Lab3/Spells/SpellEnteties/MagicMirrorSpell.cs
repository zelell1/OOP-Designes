using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.SpellEnteties;

public class MagicMirrorSpell : ISpell
{
    public ICreature CastSpell(ICreature creature)
    {
        var newAttack = new Attack(creature.Health.Value);
        creature.SetHealth(new Health(creature.Attack.Value));
        creature.SetAttack(newAttack);
        return creature;
    }
}