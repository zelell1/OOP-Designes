using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public interface ISpell
{
    ICreature CastSpell(ICreature creature);
}