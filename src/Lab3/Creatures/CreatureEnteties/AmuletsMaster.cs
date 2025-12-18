using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class AmuletsMaster : BaseCreature
{
    private AmuletsMaster(Health health, Attack attack) : base(health, attack) { }

    public static ICreatureHealthSelector Builder => new AmuletMasterBuilder();

    private sealed class AmuletMasterBuilder : CreatureBuilderBase
    {
        protected override ICreature BuildLogic()
        {
            return new AmuletsMaster(Health, Attack);
        }
    }

    public override ICreature Clone()
    {
        return new AmuletsMaster(CurrentHealth, CurrentAttack);
    }
}