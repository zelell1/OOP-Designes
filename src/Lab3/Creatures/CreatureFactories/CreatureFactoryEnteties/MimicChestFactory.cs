using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class MimicChestFactory : ICreatureFactory
{
    private const int Health = 1;
    private const int Attack = 1;

    public ICreatureBuilder CreateBuilder()
    {
        return MimicChest.Build
            .AddHealth(new Health(Health))
            .AddAttack(new Attack(Attack));
    }
}