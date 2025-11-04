using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders.CreatureBuilderEnteties;

internal sealed class ImmortalHorrorBuilder : CreatureBuilderBase
{
    protected override ICreature BuildLogic()
    {
        ICreature immortalHorror = new ImmortalHorror(
            health: Health ?? new Health(4),
            attack: Attack ?? new Attack(4));

        return immortalHorror;
    }
}