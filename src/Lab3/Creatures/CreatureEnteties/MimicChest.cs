using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;

public sealed class MimicChest : BaseCreature
{
    private MimicChest(Health? health, Attack? attack) : base(health ?? new Health(1), attack ?? new Attack(1)) { }

    public static ICreatureHealthSelector Build => new MimicChestBuilder();

    public override AttackResult Attacking(ICreature creature)
    {
        CurrentAttack = new Attack(Math.Max(CurrentAttack.Value, creature.Attack.Value));
        CurrentHealth = new Health(Math.Max(CurrentHealth.Value, creature.Health.Value));
        return creature.GetDamage(CurrentAttack);
    }

    private sealed class MimicChestBuilder : CreatureBuilderBase
    {
        protected override ICreature BuildLogic()
        {
            ICreature mimic = new MimicChest(Health, Attack);
            return mimic;
        }
    }

    public override ICreature Clone()
    {
        return new MimicChest(CurrentHealth, CurrentAttack);
    }
}