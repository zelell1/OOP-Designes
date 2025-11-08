using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureSelector.CreatureSelectorEnteties;

public class SequentiallySelector : ICreatureSelector
{
    public ICreature? Choose(IReadOnlyList<ICreature> creatures)
    {
        return creatures.OrderBy(allCreatures => allCreatures.Health.Value).First();
    }
}