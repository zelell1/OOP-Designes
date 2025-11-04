using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class BattleAnalyst : BaseCreature
{
    private readonly Attack _buffAttack;

    public BattleAnalyst(Health health, Attack attack, Attack buffAttack) : base(health, attack)
    {
        Health = health;
        Attack = attack;
        _buffAttack = buffAttack;
    }

    public override AttackResult Attacking(ICreature creature)
    {
        Attack = new Attack(Attack.Value + _buffAttack.Value);
        return creature.GetDamage(new Damage(Attack.Value));
    }

    public override ICreature Clone()
    {
        return new BattleAnalyst(Health, Attack, _buffAttack);
    }
}