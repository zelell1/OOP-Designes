using Itmo.ObjectOrientedProgramming.Lab3.Battles;
using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.CreatureSelector.CreatureSelectorEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.SpellEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.TableFactories.TableFactoriesEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class GameCoreTests
{
    [Fact]
    public void Attacking_BattleAnalystAttackingViciousFighter_ViciousFighterAlive()
    {
        // Arrange
        ICreature battleAnalyst = new BattleAnalystFactory().CreateBuilder().Build();
        ICreature viciousFighter = new ViciousFighterFactory().CreateBuilder().Build();

        // Act
        AttackResult result = battleAnalyst.Attacking(viciousFighter);

        // Assert
        Assert.True(result is AttackResult.NotDead);
        Assert.Equal(2, viciousFighter.Health.Value);
        Assert.Equal(2, viciousFighter.Attack.Value);
    }

    [Fact]
    public void Attacking_ViciousFighterAttackingBattleAnalyst_BattleAnalystFighterAlive()
    {
        // Arrange
        ICreature battleAnalyst = new BattleAnalystFactory().CreateBuilder().Build();
        ICreature viciousFighter = new ViciousFighterFactory().CreateBuilder().Build();

        // Act
        AttackResult result = viciousFighter.Attacking(battleAnalyst);

        // Assert
        Assert.True(result is AttackResult.NotDead);
    }

    [Fact]
    public void Attacking_MimicChestAttackingImmortalHorror_ImmortalHorrorReborn()
    {
        // Arrange
        ICreature mimicChest = new MimicChestFactory().CreateBuilder().Build();
        ICreature immortalHorror = new ImmortalHorrorFactory().CreateBuilder().Build();

        // Act
        AttackResult result = mimicChest.Attacking(immortalHorror);

        // Assert
        Assert.True(result is AttackResult.NotDead);
        Assert.Equal(1, immortalHorror.Health.Value);
        Assert.Equal(4, immortalHorror.Attack.Value);
        Assert.Equal(4, mimicChest.Attack.Value);
        Assert.Equal(4, mimicChest.Health.Value);
    }

    [Fact]
    public void Attacking_MimicChestAttackingImmortalHorror_ImmortalHorrorDead()
    {
        // Arrange
        ICreature mimicChest = new MimicChestFactory().CreateBuilder().Build();
        ICreature immortalHorror = new ImmortalHorrorFactory().CreateBuilder().Build();

        // Act
        AttackResult firstResult = mimicChest.Attacking(immortalHorror);
        AttackResult secondResult = mimicChest.Attacking(immortalHorror);

        // Assert
        Assert.True(firstResult is AttackResult.NotDead);
        Assert.True(secondResult is AttackResult.Dead);
        Assert.Equal(-3, immortalHorror.Health.Value);
        Assert.Equal(4, immortalHorror.Attack.Value);
        Assert.Equal(4, mimicChest.Attack.Value);
        Assert.Equal(4, mimicChest.Health.Value);
    }

    [Fact]
    public void Attacking_ImmortalHorrorAttackingAmuletMaster_AmuletMasterHaveFullHp()
    {
        // Arrange
        ICreature amuletMaster = new AmuletMasterFactory().CreateBuilder().Build();
        ICreature immortalHorror = new ImmortalHorrorFactory().CreateBuilder().Build();

        // Act
        AttackResult result = immortalHorror.Attacking(amuletMaster);

        // Assert
        Assert.True(result is AttackResult.NotDead);
        Assert.Equal(2, amuletMaster.Health.Value);
        Assert.Equal(4, immortalHorror.Health.Value);
    }

    [Fact]
    public void Attacking_AmuletMasterAttackingImmortalHorror_ImmortalHorrorDead()
    {
        // Arrange
        ICreature amuletMaster = new AmuletMasterFactory().CreateBuilder().Build();
        ICreature immortalHorror = new ImmortalHorrorFactory().CreateBuilder().Build();

        // Act
        AttackResult result = amuletMaster.Attacking(immortalHorror);

        // Assert
        Assert.True(result is AttackResult.Dead);
        Assert.Equal(-4, immortalHorror.Health.Value);
    }

    [Fact]
    public void CastSpell_CastBuffAttackSpellOnCreature_AttackBuffed()
    {
        // Arrange
        ICreature creature = new BattleAnalystFactory().CreateBuilder().Build();
        var spell = new BuffAttackSpell();

        // Act
        creature = spell.CastSpell(creature);

        // Assert
        Assert.Equal(7, creature.Attack.Value);
    }

    [Fact]
    public void CastSpell_CastBuffStaminaSpellOnCreature_HealthBuffed()
    {
        // Arrange
        ICreature creature = new BattleAnalystFactory().CreateBuilder().Build();
        var spell = new BuffStaminaSpell();

        // Act
        creature = spell.CastSpell(creature);

        // Assert
        Assert.Equal(9, creature.Health.Value);
    }

    [Fact]
    public void CastSpell_CastShieldAmuletSpellOnCreature_MagicShieldAppliesOnCreature()
    {
        // Arrange
        ICreature creature = new BattleAnalystFactory().CreateBuilder().Build();
        var spell = new ShieldAmuletSpell();

        // Act
        creature = spell.CastSpell(creature);
        creature.GetDamage(new Attack(10));

        // Assert
        Assert.Equal(4, creature.Health.Value);
    }

    [Fact]
    public void CastSpell_CastMagicMirrorOnCreature_HealthAndAttackSwaps()
    {
        // Arrange
        ICreature creature = new BattleAnalystFactory().CreateBuilder().Build();
        var spell = new MagicMirrorSpell();

        // Act
        creature = spell.CastSpell(creature);

        // Assert
        Assert.Equal(2, creature.Health.Value);
        Assert.Equal(4, creature.Attack.Value);
    }

    [Fact]
    public void Build_BuildCreatureWithModifier_CreatureBuilded()
    {
        // Arrange
        var modifiers = new List<IModifierFactory>
        {
            new MagicShieldModifierFactory(), new MagicShieldModifierFactory(),
        };

        // Act
        ICreature creature = new ViciousFighterFactory().CreateBuilder().AddModifiers(modifiers[0]).
            AddModifiers(modifiers[1]).Build();
        creature.GetDamage(new Attack(10));
        creature.GetDamage(new Attack(10));

        // Assert
        Assert.Equal(6, creature.Health.Value);
    }

    [Fact]
    public void CastSpell_CombinatesModifiersAndSpells_Succes()
    {
        // Arrange
        var modifiers = new List<IModifierFactory>
        {
            new MasteryAttackModifierFactory(),
        };

        ICreature creature = new BattleAnalystFactory().CreateBuilder().AddModifiers(modifiers[0]).Build();
        var spell = new MagicMirrorSpell();

        // Act
        creature = spell.CastSpell(creature);

        // Assert
        Assert.Equal(2, creature.Health.Value);
        Assert.Equal(4, creature.Attack.Value);
    }

    [Fact]
    public void Clone_CloneCreature_Success()
    {
        // Arrange
        ICreature creature = new BattleAnalystFactory().CreateBuilder().Build();

        // Act
        ICreature clone = creature.Clone();

        // Assert
        Assert.NotEqual(creature, clone);
        Assert.NotSame(creature, clone);
    }

    [Fact]
    public void AddCreature_WhenHandSizeIsFull_Failure()
    {
        // Arrange
        bool isOverflowed = false;

        var creatures = new List<ICreatureBuilder>
        {
            new AmuletMasterFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new ImmortalHorrorFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
        };

        IPlayerTableBuilder table = new TableWithSequentialSelectorFactory().CreateBuilder()
            .AddCreature(creatures[0].Build())
            .AddCreature(creatures[1].Build())
            .AddCreature(creatures[2].Build())
            .AddCreature(creatures[3].Build())
            .AddCreature(creatures[4].Build())
            .AddCreature(creatures[5].Build())
            .AddCreature(creatures[6].Build());

        // Act
        try
        {
            table.AddCreature(creatures[7].Build());
        }
        catch (InvalidOperationException)
        {
            isOverflowed = true;
        }

        // Assert
        Assert.True(isOverflowed);
    }

    [Fact]
    public void Clone_CloneTable_Success()
    {
        // Arrange
        var creatures = new List<ICreatureBuilder>
        {
            new AmuletMasterFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new ImmortalHorrorFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
        };

        PlayerTable table = new TableWithSequentialSelectorFactory().CreateBuilder()
            .AddCreature(creatures[0].Build())
            .AddCreature(creatures[1].Build())
            .AddCreature(creatures[2].Build())
            .AddCreature(creatures[3].Build())
            .AddCreature(creatures[4].Build())
            .AddCreature(creatures[5].Build())
            .AddCreature(creatures[6].Build())
            .Build();

        // Act
        PlayerTable clone = table.Clone();

        // Assert
        Assert.NotEqual(table, clone);
        Assert.NotSame(table, clone);
    }

    [Fact]
    public void Clone_CloneTableWithSpells_Success()
    {
        // Arrange
        var creatures = new List<ICreatureBuilder>
        {
            new AmuletMasterFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new ImmortalHorrorFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
        };

        var spellFisrt = new ShieldAmuletSpell();

        ICreature creatureFirst = creatures[0].Build();

        PlayerTable table = new TableWithSequentialSelectorFactory().CreateBuilder()
            .AddCreature(creatureFirst)
            .Build();

        // Act
        CastSpellResult resultFirst = table.CastSpell(creatureFirst, spellFisrt);
        PlayerTable table2 = table.Clone();

        // Assert
        Assert.True(resultFirst is CastSpellResult.Success);

        if (resultFirst is CastSpellResult.Success successFirst)
        {
            Assert.NotSame(successFirst.Creature, table2.FindAttackingCreature());
        }
    }

    [Fact]
    public void Fight_BattleWithEmptyTables_Draw()
    {
        // Arrange
        PlayerTable tableFirst = new TableWithSequentialSelectorFactory().CreateBuilder().Build();
        PlayerTable tableSecond = new TableWithSequentialSelectorFactory().CreateBuilder().Build();
        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Round();

        // Assert
        Assert.True(result is FightResult.Draw);
    }

    [Fact]
    public void Fight_BattleWithFisrtEmptyTables_SecondPlayerWin()
    {
        // Arrange
        var creatures = new List<ICreatureBuilder>
        {
            new AmuletMasterFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new ImmortalHorrorFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
        };

        PlayerTable tableFirst = PlayerTable.Builder.AddCreatureSelector(new SequentiallySelector()).Build();

        PlayerTable tableSecond = new TableWithSequentialSelectorFactory().CreateBuilder()
            .AddCreature(creatures[0].Build())
            .Build();

        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Round();

        // Assert
        Assert.True(result is FightResult.SecondPlayerWin);
    }

    [Fact]
    public void Fight_BattleWithSecondEmptyTables_FirstPlayerWin()
    {
        // Arrange
        var creatures = new List<ICreatureBuilder>
        {
            new AmuletMasterFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new ImmortalHorrorFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
        };

        PlayerTable tableFirst = new TableWithSequentialSelectorFactory().CreateBuilder()
            .AddCreature(creatures[0].Build())
            .Build();

        PlayerTable tableSecond = new TableWithSequentialSelectorFactory().CreateBuilder().Build();
        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Round();

        // Assert
        Assert.True(result is FightResult.FirstPlayerWin);
    }

    [Fact]
    public void Fight_StandardBattle_FirstPlayerWin()
    {
        // Arrange
        var catalogFirst = new List<ICreatureBuilder>
        {
            new AmuletMasterFactory().CreateBuilder(),
            new ImmortalHorrorFactory().CreateBuilder(),
        };

        var magicShieldSpell = new ShieldAmuletSpell();

        ICreature firstCreature = catalogFirst[0].Build();
        ICreature secondCreature = catalogFirst[1].Build();

        PlayerTable tableFirst = new TableWithSequentialSelectorFactory().CreateBuilder()
            .AddCreature(firstCreature)
            .AddCreature(secondCreature)
            .Build();

        tableFirst.CastSpell(secondCreature, magicShieldSpell);

        var catalogSecond = new List<ICreatureBuilder>
        {
            new MimicChestFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(),
        };

        PlayerTable tableSecond = new TableWithSequentialSelectorFactory().CreateBuilder()
            .AddCreature(catalogSecond[0].Build())
            .AddCreature(catalogSecond[1].Build())
            .Build();

        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Round();

        // Assert
        Assert.True(result is FightResult.FirstPlayerWin);
    }
}