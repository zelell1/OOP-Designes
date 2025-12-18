using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public abstract class BaseCreature : ICreature
{
    public Health Health => CurrentHealth;

    public Attack Attack => CurrentAttack;

    protected BaseCreature(Health health, Attack attack)
    {
        CurrentHealth = health;
        CurrentAttack = attack;
    }

    protected Health CurrentHealth { get; set; }

    protected Attack CurrentAttack { get; set; }

    public virtual AttackResult Attacking(ICreature creature)
    {
        return creature.GetDamage(CurrentAttack);
    }

    public virtual AttackResult GetDamage(Attack damage)
    {
        if (CurrentHealth.Value <= 0)
        {
            return new AttackResult.Dead();
        }

        CurrentHealth = new Health(CurrentHealth.Value - damage.Value);

        if (CurrentHealth.Value <= 0)
        {
            return new AttackResult.Dead();
        }

        return new AttackResult.NotDead();
    }

    public void SetHealth(Health health)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(health.Value);
        CurrentHealth = health;
    }

    public void SetAttack(Attack attack)
    {
        CurrentAttack = attack;
    }

    public abstract ICreature Clone();
}