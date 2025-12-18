using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.CreatureSelector.CreatureSelectorEnteties;

public class RandomSelector : ICreatureSelector
{
    public ICreature? Choose(IReadOnlyList<ICreature> creatures)
    {
        return creatures[RandomNumberGenerator.GetInt32(0, creatures.Count)];
    }
}