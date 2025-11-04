using Itmo.ObjectOrientedProgramming.Lab3.Battles;
using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories.CreatureFactoryEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifiersFactories.ModifierssFactoriesEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Spells.SpellEnteties;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.ResultType;
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
        creature.GetDamage(new Damage(10));

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
        ICreature creature = new ViciousFighterFactory().CreateBuilder().AddModifiers(modifiers).Build();
        creature.GetDamage(new Damage(10));
        creature.GetDamage(new Damage(10));

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

        ICreature creature = new BattleAnalystFactory().CreateBuilder().AddModifiers(modifiers).Build();
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
        var creatures = new List<ICreatureBuilder>
        {
            new AmuletMasterFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new ImmortalHorrorFactory().CreateBuilder(), new ImmortalHorrorFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(), new ViciousFighterFactory().CreateBuilder(),
        };

        var table = new PlayerTable();
        table.AddCreature(creatures[0].Build());
        table.AddCreature(creatures[1].Build());
        table.AddCreature(creatures[2].Build());
        table.AddCreature(creatures[3].Build());
        table.AddCreature(creatures[4].Build());
        table.AddCreature(creatures[5].Build());
        table.AddCreature(creatures[6].Build());

        // Act
        AddCreatureResult result = table.AddCreature(creatures[7].Build());

        // Assert
        Assert.True(result is AddCreatureResult.Failure);
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

        var table = new PlayerTable();
        table.AddCreature(creatures[0].Build());
        table.AddCreature(creatures[1].Build());
        table.AddCreature(creatures[2].Build());
        table.AddCreature(creatures[3].Build());
        table.AddCreature(creatures[4].Build());
        table.AddCreature(creatures[5].Build());
        table.AddCreature(creatures[6].Build());

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
        var spellSecond = new BuffAttackSpell();

        var table = new PlayerTable();

        ICreature creatureFirst = creatures[0].Build();
        ICreature creatureSecond = creatures[1].Build();

        table.AddCreature(creatures[0].Build());
        table.AddCreature(creatures[1].Build());

        // Act
        CastSpellResult resultFirst = table.CastSpell(new CreatureIndex(0), spellFisrt);
        CastSpellResult resultSecond = table.CastSpell(new CreatureIndex(1), spellSecond);

        // Assert
        Assert.True(resultFirst is CastSpellResult.Success);
        Assert.True(resultSecond is CastSpellResult.Success);

        if (resultFirst is CastSpellResult.Success successFirst &&
            resultSecond is CastSpellResult.Success successSecond)
        {
            Assert.NotSame(successFirst.Creature, creatureFirst);
            Assert.NotSame(successSecond.Creature, creatureSecond);
        }
    }

    [Fact]
    public void Fight_BattleWithEmptyTables_Draw()
    {
        // Arrange
        var tableFirst = new PlayerTable();
        var tableSecond = new PlayerTable();
        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Fight();

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

        var tableFirst = new PlayerTable();

        var tableSecond = new PlayerTable();
        tableSecond.AddCreature(creatures[0].Build());
        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Fight();

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

        var tableFirst = new PlayerTable();
        tableFirst.AddCreature(creatures[0].Build());

        var tableSecond = new PlayerTable();
        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Fight();

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

        var tableFirst = new PlayerTable();
        tableFirst.AddCreature(catalogFirst[0].Build());
        tableFirst.AddCreature(catalogFirst[1].Build());
        tableFirst.CastSpell(new CreatureIndex(1), magicShieldSpell);

        var catalogSecond = new List<ICreatureBuilder>
        {
            new MimicChestFactory().CreateBuilder(),
            new BattleAnalystFactory().CreateBuilder(),
        };

        var tableSecond = new PlayerTable();
        tableSecond.AddCreature(catalogSecond[0].Build());
        tableSecond.AddCreature(catalogSecond[1].Build());

        var battle = new Battle(tableFirst, tableSecond);

        // Act
        FightResult result = battle.Fight();

        // Assert
        Assert.True(result is FightResult.FirstPlayerWin);
    }
}