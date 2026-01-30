using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureSelector;

public interface ICreatureSelector
{
    ICreature? Choose(IReadOnlyList<ICreature> creatures);
}