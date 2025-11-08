using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.CreatureSelector;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable
{
    private readonly List<ICreature> _creatures = [];

    private readonly ICreatureSelector _creatureSelector;

    private PlayerTable(IReadOnlyCollection<ICreature> creatures, ICreatureSelector creatureSelector)
    {
        _creatures.AddRange(creatures.Select(creature => creature.Clone()));
        _creatureSelector = creatureSelector;
    }

    public static IPlayerTableConfigBuilder Builder => new PlayerTableBuilder();

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

        return _creatureSelector.Choose(attackingCreatures);
    }

    public ICreature? FindDefendingCreature()
    {
        List<ICreature> defendingCreatures = _creatures.FindAll(creature => creature.Health.Value > 0);

        if (defendingCreatures.Count == 0)
        {
            return null;
        }

        return _creatureSelector.Choose(defendingCreatures);
    }

    private sealed class PlayerTableBuilder : IPlayerTableBuilder
    {
        private readonly List<ICreature> _creatures = [];

        private ICreatureSelector? _creatureSelector;

        public IPlayerTableBuilder AddCreature(ICreature creature)
        {
            if (_creatures.Count >= 7)
            {
                throw new InvalidOperationException();
            }

            _creatures.Add(creature.Clone());
            return this;
        }

        public IPlayerTableBuilder AddCreatureSelector(ICreatureSelector creatureSelector)
        {
            _creatureSelector = creatureSelector;
            return this;
        }

        public PlayerTable Build()
        {
            if (_creatureSelector is null)
            {
                throw new InvalidOperationException();
            }

            return new PlayerTable(_creatures, _creatureSelector);
        }
    }

    public PlayerTable Clone()
    {
        return new PlayerTable(_creatures, _creatureSelector);
    }
}