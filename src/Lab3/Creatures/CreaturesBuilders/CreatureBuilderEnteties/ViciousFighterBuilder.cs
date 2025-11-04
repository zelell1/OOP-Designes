using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders.CreatureBuilderEnteties;

internal sealed class ViciousFighterBuilder : CreatureBuilderBase
{
    private Attack? _buffAttack;

    public ViciousFighterBuilder AddBuffAttack(Attack buffAttack)
    {
        _buffAttack = buffAttack;
        return this;
    }

    protected override ICreature BuildLogic()
    {
        ICreature fighter = new ViciousFighter(
            health: Health ?? new Health(6),
            attack: Attack ?? new Attack(1),
            buffAttack: _buffAttack ?? new Attack(2));

        return fighter;
    }
}