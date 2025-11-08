using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class BattleAnalystFactory : ICreatureFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        return BattleAnalyst.Build
            .AddHealth(new Health(4))
            .AddAttack(new Attack(2));
    }
}