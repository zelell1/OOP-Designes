using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders.CreatureBuilderEnteties;

internal sealed class BattleAnalystBuilder : CreatureBuilderBase
{
    private Attack? _buffAttack;

    public BattleAnalystBuilder AddBuffAttack(Attack buffAttack)
    {
        _buffAttack = buffAttack;
        return this;
    }

    protected override ICreature BuildLogic()
    {
        ICreature analyst = new BattleAnalyst(
            health: Health ?? new Health(4),
            attack: Attack ?? new Attack(2),
            buffAttack: _buffAttack ?? new Attack(2));

        return analyst;
    }
}