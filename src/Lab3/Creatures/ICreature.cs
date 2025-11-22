using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    Health Health { get; }

    Attack Attack { get; }

    AttackResult Attacking(ICreature creature);

    AttackResult GetDamage(Attack damage);

    void SetHealth(Health health);

    void SetAttack(Attack attack);

    ICreature Clone();
}