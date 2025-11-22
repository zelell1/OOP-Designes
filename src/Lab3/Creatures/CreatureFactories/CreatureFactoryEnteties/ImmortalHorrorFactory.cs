using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class ImmortalHorrorFactory : ICreatureFactory
{
    private const int Health = 4;
    private const int Attack = 4;

    public ICreatureBuilder CreateBuilder()
    {
        return ImmortalHorror.Build
            .AddHealth(new Health(Health))
            .AddAttack(new Attack(Attack));
    }
}