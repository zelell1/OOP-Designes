using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class MimicChestFactory : ICreatureFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        return MimicChest.Build
            .AddHealth(new Health(1))
            .AddAttack(new Attack(1));
    }
}