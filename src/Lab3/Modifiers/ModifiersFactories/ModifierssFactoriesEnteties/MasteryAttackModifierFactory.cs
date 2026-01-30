using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.AttackModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;

public sealed class MasteryAttackModifierFactory : IModifierFactory
{
    public ICreature Create(ICreature creature)
    {
        return new MasteryAttackModifier(creature);
    }
}