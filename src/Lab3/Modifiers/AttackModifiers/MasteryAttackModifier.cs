using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.AttackModifiers;

public sealed class MasteryAttackModifier : ICreature
{
    private readonly ICreature _creature;

    public MasteryAttackModifier(ICreature creature)
    {
        _creature = creature;
    }

    public Health Health => _creature.Health;

    public Attack Attack => _creature.Attack;

    public AttackResult Attacking(ICreature creature)
    {
        AttackResult result = creature.GetDamage(_creature.Attack);

        if (result is AttackResult.Dead)
        {
            return result;
        }

        return creature.GetDamage(_creature.Attack);
    }

    public AttackResult GetDamage(Attack damage)
    {
        return _creature.GetDamage(damage);
    }

    public void SetHealth(Health health)
    {
        _creature.SetHealth(health);
    }

    public void SetAttack(Attack attack)
    {
        _creature.SetAttack(attack);
    }

    public ICreature Clone()
    {
        return new MasteryAttackModifier(_creature.Clone());
    }
}