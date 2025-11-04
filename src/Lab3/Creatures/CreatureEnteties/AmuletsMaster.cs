using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class AmuletsMaster : BaseCreature
{
    public AmuletsMaster(Health health, Attack attack) : base(health, attack)
    {
        Health = health;
        Attack = attack;
    }

    public override ICreature Clone()
    {
        return new AmuletsMaster(Health, Attack);
    }
}