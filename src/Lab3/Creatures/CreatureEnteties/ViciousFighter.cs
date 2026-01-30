using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class ViciousFighter : BaseCreature
{
    private readonly Attack _buffAttack;

    public ViciousFighter(Health health, Attack attack) : base(health, attack)
    {
        _buffAttack = new Attack(2);
    }

    public static ICreatureHealthSelector Build => new ViciousFighterBuilder();

    public override AttackResult GetDamage(Attack damage)
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

        CurrentAttack = new Attack(CurrentAttack.Value * _buffAttack.Value);

        return new AttackResult.NotDead();
    }

    private sealed class ViciousFighterBuilder : CreatureBuilderBase
    {
        protected override ICreature BuildLogic()
        {
            ICreature fighter = new ViciousFighter(Health, Attack);
            return fighter;
        }
    }

    public override ICreature Clone()
    {
        return new ViciousFighter(CurrentHealth, CurrentAttack);
    }
}