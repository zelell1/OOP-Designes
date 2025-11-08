using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;
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
            var modidiers = new List<IModifierFactory>
            {
                new MagicShieldModifierFactory(),
                new MasteryAttackModifierFactory(),
            };

            ICreature amuletMaster = new AmuletsMaster(Health, Attack);

            foreach (IModifierFactory factory in modidiers)
            {
                amuletMaster = factory.Create(amuletMaster);
            }

            return amuletMaster;
        }
    }

    public override ICreature Clone()
    {
        return new AmuletsMaster(CurrentHealth, CurrentAttack);
    }
}