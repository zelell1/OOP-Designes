using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories;

public interface ICreatureFactory
{
    ICreatureBuilder CreateBuilder();
}