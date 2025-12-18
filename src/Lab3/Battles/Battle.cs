using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battles;

public class Battle
{
    private readonly PlayerTable _firstPlayer;

    private readonly PlayerTable _secondPlayer;

    public Battle(PlayerTable firstPlayer, PlayerTable secondPlayer)
    {
        _firstPlayer = firstPlayer.Clone();
        _secondPlayer = secondPlayer.Clone();
    }

    public FightResult Round()
    {
        PlayerTable attackingTable = _firstPlayer;
        PlayerTable defendingTable = _secondPlayer;

        while (true)
        {
            ICreature? attackingCreature = attackingTable.FindAttackingCreature();
            ICreature? defendingCreature = defendingTable.FindDefendingCreature();

            if (attackingCreature is null && defendingTable.FindAttackingCreature() is null)
            {
                return new FightResult.Draw();
            }

            if (attackingCreature is not null && defendingCreature is null)
            {
                if (attackingTable == _firstPlayer)
                {
                    return new FightResult.FirstPlayerWin();
                }

                return new FightResult.SecondPlayerWin();
            }

            if (attackingCreature is not null && defendingCreature is not null)
            {
                attackingCreature.Attacking(defendingCreature);
            }

            (attackingTable, defendingTable) = (defendingTable, attackingTable);
        }
    }
}