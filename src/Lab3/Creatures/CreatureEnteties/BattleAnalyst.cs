using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class BattleAnalyst : BaseCreature
{
    private readonly Attack _buffAttack;

    private BattleAnalyst(Health health, Attack attack) : base(health, attack)
    {
        _buffAttack = new Attack(2);
    }

    public static ICreatureHealthSelector Build => new BattleAnalystBuilder();

    public override AttackResult Attacking(ICreature creature)
    {
        CurrentAttack = new Attack(CurrentAttack.Value + _buffAttack.Value);
        return creature.GetDamage(new Damage(CurrentAttack.Value));
    }

    private sealed class BattleAnalystBuilder : CreatureBuilderBase
    {
        protected override ICreature BuildLogic()
        {
            ICreature analyst = new BattleAnalyst(Health, Attack);
            return analyst;
        }
    }

    public override ICreature Clone()
    {
        return new BattleAnalyst(CurrentHealth, CurrentAttack);
    }
}