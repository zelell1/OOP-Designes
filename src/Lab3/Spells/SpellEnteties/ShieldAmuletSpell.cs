using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells.SpellEnteties;

public class ShieldAmuletSpell : ISpell
{
    public ICreature CastSpell(ICreature creature)
    {
        creature = new MagicShieldModifierFactory().Create(creature);
        return creature;
    }
}