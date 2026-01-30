using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class ViciousFighterFactory : ICreatureFactory
{
    private const int Health = 6;
    private const int Attack = 1;

    public ICreatureBuilder CreateBuilder()
    {
        return ViciousFighter.Build
            .AddHealth(new Health(Health))
            .AddAttack(new Attack(Attack));
    }
}
