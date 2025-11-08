using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;

public interface ICreatureBuilder : ICreatureHealthSelector, ICreatureAttackSelector
{
    ICreatureBuilder AddModifiers(IModifierFactory modifiers);

    ICreature Build();
}