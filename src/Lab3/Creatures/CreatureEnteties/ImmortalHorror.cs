using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class ImmortalHorror : BaseCreature
{
    private bool _isReborn;

    public ImmortalHorror(Health health, Attack attack) : base(health, attack)
    {
        Health = health;
        Attack = attack;
        _isReborn = false;
    }

    public override AttackResult GetDamage(Damage damage)
    {
        Health = new Health(Health.Value - damage.Value);

        if (Health.Value <= 0 && _isReborn)
        {
            return new AttackResult.Dead();
        }

        if (Health.Value <= 0 && !_isReborn)
        {
            _isReborn = true;
            Health = new Health(1);
        }

        return new AttackResult.NotDead();
    }

    public override ICreature Clone()
    {
        return new ImmortalHorror(Health, Attack);
    }
}