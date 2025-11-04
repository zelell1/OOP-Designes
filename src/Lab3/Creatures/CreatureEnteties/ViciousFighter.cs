using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class ViciousFighter : BaseCreature
{
    private readonly Attack _buffAttack;

    public ViciousFighter(Health health, Attack attack, Attack buffAttack) : base(health, attack)
    {
        Health = health;
        Attack = attack;
        _buffAttack = buffAttack;
    }

    public override AttackResult GetDamage(Damage damage)
    {
        if (Health.Value <= 0)
        {
            return new AttackResult.Dead();
        }

        Health = new Health(Health.Value - damage.Value);

        if (Health.Value <= 0)
        {
            return new AttackResult.Dead();
        }

        Attack = new Attack(Attack.Value * _buffAttack.Value);

        return new AttackResult.NotDead();
    }

    public override ICreature Clone()
    {
        return new ViciousFighter(Health, Attack, _buffAttack);
    }
}