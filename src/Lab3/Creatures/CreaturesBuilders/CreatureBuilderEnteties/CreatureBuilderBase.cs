using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders.CreatureBuilderEnteties;

internal abstract class CreatureBuilderBase : ICreatureBuilder
{
    private readonly List<IModifierFactory> _modifiers = [];

    protected Health? Health { get; private set; }

    protected Attack? Attack { get; private set; }

    public ICreatureBuilder AddModifiers(IReadOnlyCollection<IModifierFactory> modifiers)
    {
        _modifiers.AddRange(modifiers);
        return this;
    }

    public ICreatureBuilder AddHealth(Health health)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(health.Value);
        Health = health;
        return this;
    }

    public ICreatureBuilder AddAttack(Attack attack)
    {
        Attack = attack;
        return this;
    }

    public ICreature Build()
    {
        ICreature creature = BuildLogic();

        foreach (IModifierFactory factory in _modifiers)
        {
            creature = factory.Create(creature);
        }

        return creature;
    }

    protected abstract ICreature BuildLogic();
}