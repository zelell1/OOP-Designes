using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class ImmortalHorror : BaseCreature
{
    private bool _isReborn;

    private ImmortalHorror(Health health, Attack attack) : base(health, attack)
    {
        _isReborn = false;
    }

    public static ICreatureHealthSelector Build => new ImmortalHorrorBuilder();

    public override AttackResult GetDamage(Attack damage)
    {
        CurrentHealth = new Health(CurrentHealth.Value - damage.Value);

        if (CurrentHealth.Value <= 0 && _isReborn)
        {
            return new AttackResult.Dead();
        }

        if (CurrentHealth.Value <= 0 && !_isReborn)
        {
            _isReborn = true;
            CurrentHealth = new Health(1);
        }

        return new AttackResult.NotDead();
    }

    private sealed class ImmortalHorrorBuilder : CreatureBuilderBase
    {
        protected override ICreature BuildLogic()
        {
            ICreature immortalHorror = new ImmortalHorror(Health, Attack);
            return immortalHorror;
        }
    }

    public override ICreature Clone()
    {
        return new ImmortalHorror(CurrentHealth, CurrentAttack) { _isReborn = _isReborn };
    }
}