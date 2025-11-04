using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders.CreatureBuilderEnteties;

internal sealed class AmuletMasterBuilder : CreatureBuilderBase
{
    protected override ICreature BuildLogic()
    {
        var modidiers = new List<IModifierFactory>
        {
            new MagicShieldModifierFactory(),
            new MasteryAttackModifierFactory(),
        };

        ICreature amuletMaster = new AmuletsMaster(
                health: Health ?? new Health(2),
                attack: Attack ?? new Attack(5));

        foreach (IModifierFactory factory in modidiers)
        {
            amuletMaster = factory.Create(amuletMaster);
        }

        return amuletMaster;
    }
}