using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders.CreatureBuilderEnteties;

internal sealed class MimicChestBuilder : CreatureBuilderBase
{
    protected override ICreature BuildLogic()
    {
        ICreature mimic = new MimicChest(
            health: Health ?? new Health(1),
            attack: Attack ?? new Attack(1));

        return mimic;
    }
}