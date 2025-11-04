using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ProtectiveModifiers;

public sealed class MagicShieldModifier : ICreature
{
    private readonly ICreature _creature;

    private bool _isActive;

    public MagicShieldModifier(ICreature creature)
    {
        _creature = creature;
        _isActive = true;
    }

    private MagicShieldModifier(ICreature creature, bool isActive)
    {
        _creature = creature;
        _isActive = isActive;
    }

    public Health Health => _creature.Health;

    public Attack Attack => _creature.Attack;

    public AttackResult Attacking(ICreature creature)
    {
        return creature.GetDamage(new Damage(Attack.Value));
    }

    public AttackResult GetDamage(Damage damage)
    {
        if (!_isActive)
        {
            return _creature.GetDamage(damage);
        }

        _isActive = false;

        return new AttackResult.NotDead();
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
        return new MagicShieldModifier(_creature.Clone(), _isActive);
    }
}