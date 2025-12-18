using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;

public class AmuletMasterFactory : ICreatureFactory
{
    private const int Health = 2;
    private const int Attack = 5;

    public ICreatureBuilder CreateBuilder()
    {
        return AmuletsMaster.Builder
            .AddHealth(new Health(Health))
            .AddAttack(new Attack(Attack))
            .AddModifiers(new MagicShieldModifierFactory())
            .AddModifiers(new MasteryAttackModifierFactory());
    }
}