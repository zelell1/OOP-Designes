using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;

public interface IModifierFactory
{
    ICreature Create(ICreature creature);
}