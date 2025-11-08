using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class ViciousFighterFactory : ICreatureFactory
{
    public ICreatureBuilder CreateBuilder()
    {
        return ViciousFighter.Build
            .AddHealth(new Health(6))
            .AddAttack(new Attack(1));
    }
}
