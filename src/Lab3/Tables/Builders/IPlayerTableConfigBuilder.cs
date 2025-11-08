using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.CreatureSelector;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;

public interface IPlayerTableConfigBuilder
{
    IPlayerTableBuilder AddCreatureSelector(ICreatureSelector selector);

    IPlayerTableBuilder AddCreature(ICreature creature);
}