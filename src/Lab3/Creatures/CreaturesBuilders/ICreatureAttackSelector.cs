using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;

public interface ICreatureAttackSelector
{
    ICreatureBuilder AddAttack(Attack attack);
}