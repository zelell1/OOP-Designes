using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ProtectiveModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;

public sealed class MagicShieldModifierFactory : IModifierFactory
{
    public ICreature Create(ICreature creature)
    {
        return new MagicShieldModifier(creature);
    }
}