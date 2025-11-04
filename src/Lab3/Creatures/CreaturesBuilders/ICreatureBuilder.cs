using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;

public interface ICreatureBuilder
{
    ICreatureBuilder AddModifiers(IReadOnlyCollection<IModifierFactory> modifiers);

    ICreatureBuilder AddHealth(Health health);

    ICreatureBuilder AddAttack(Attack attack);

    ICreature Build();
}