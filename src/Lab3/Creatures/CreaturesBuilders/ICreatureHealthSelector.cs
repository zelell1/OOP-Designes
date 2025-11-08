using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;

public interface ICreatureHealthSelector
{
    ICreatureAttackSelector AddHealth(Health health);
}