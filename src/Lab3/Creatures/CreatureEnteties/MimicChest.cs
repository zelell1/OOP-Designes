using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class MimicChest : BaseCreature
{
    public MimicChest(Health health, Attack attack) : base(health, attack)
    {
        Health = health;
        Attack = attack;
    }

    public override AttackResult Attacking(ICreature creature)
    {
        Attack = new Attack(Math.Max(Attack.Value, creature.Attack.Value));
        Health = new Health(Math.Max(Health.Value, creature.Health.Value));
        return creature.GetDamage(new Damage(Attack.Value));
    }

    public override ICreature Clone()
    {
        return new MimicChest(Health, Attack);
    }
}