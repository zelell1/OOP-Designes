using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders.CreatureBuilderEnteties;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class AmuletMasterFactory : ICreatureFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        return new AmuletMasterBuilder();
    }
}