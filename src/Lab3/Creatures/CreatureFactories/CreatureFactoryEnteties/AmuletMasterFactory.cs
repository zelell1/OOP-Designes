using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class AmuletMasterFactory : ICreatureFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        return AmuletsMaster.Builder
            .AddHealth(new Health(2))
            .AddAttack(new Attack(5));
    }
}