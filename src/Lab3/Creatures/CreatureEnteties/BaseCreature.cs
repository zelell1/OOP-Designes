using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public abstract class BaseCreature : ICreature
{
    protected BaseCreature(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public Health Health { get; protected set; }

    public Attack Attack { get; protected set; }

    public virtual AttackResult Attacking(ICreature creature)
    {
        return creature.GetDamage(new Damage(Attack.Value));
    }

    public virtual AttackResult GetDamage(Damage damage)
    {
        if (Health.Value <= 0)
        {
            return new AttackResult.Dead();
        }

        Health = new Health(Health.Value - damage.Value);

        if (Health.Value <= 0)
        {
            Console.WriteLine("ssss");
            return new AttackResult.Dead();
        }

        return new AttackResult.NotDead();
    }

    public void SetHealth(Health health)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(health.Value);
        Health = health;
    }

    public void SetAttack(Attack attack)
    {
        Attack = attack;
    }

    public abstract ICreature Clone();
}