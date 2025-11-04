using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable
{
    private readonly List<ICreature> _creatures = [];

    public PlayerTable() { }

    private PlayerTable(IReadOnlyCollection<ICreature> creatures)
    {
        _creatures.AddRange(creatures.Select(creature => creature.Clone()));
    }

    public AddCreatureResult AddCreature(ICreature creature)
    {
        if (_creatures.Count >= 7)
        {
            return new AddCreatureResult.Failure();
        }

        _creatures.Add(creature.Clone());

        return new AddCreatureResult.Success(creature);
    }

    public CastSpellResult CastSpell(CreatureIndex index, ISpell spell)
    {
        if (index.Value > _creatures.Count - 1)
        {
            return new CastSpellResult.CreatureNotFound();
        }

        _creatures[index.Value] = spell.CastSpell(_creatures[index.Value]);

        return new CastSpellResult.Success(_creatures[index.Value]);
    }

    public ICreature? FindAttackingCreature()
    {
        List<ICreature> attackingCreatures = _creatures.FindAll(creature =>
            creature.Health.Value > 0 && creature.Attack.Value > 0);

        if (attackingCreatures.Count == 0)
        {
            return null;
        }

        return attackingCreatures[RandomNumberGenerator.GetInt32(0, attackingCreatures.Count)];
    }

    public ICreature? FindDefendingCreature()
    {
        List<ICreature> defendingCreatures = _creatures.FindAll(creature => creature.Health.Value > 0);

        if (defendingCreatures.Count == 0)
        {
            return null;
        }

        return defendingCreatures[RandomNumberGenerator.GetInt32(0, defendingCreatures.Count)];
    }

    public PlayerTable Clone()
    {
        return new PlayerTable(_creatures);
    }
}